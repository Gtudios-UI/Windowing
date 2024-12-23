using System.Threading.Tasks;
using Windows.Internal;
using Windows.UI.Core;
using Windows.UI.WindowManagement;
using WinRT;

namespace Gtudios.UI.Windowing;

partial class Window
{
#if NET9_0_OR_GREATER
    static unsafe void* GetWindowContext(XamlRoot root)
    {
        void* reference;
        unsafe
        {
            root.UIContext.As<IUIContextPartner>().get_WindowContext(&reference);
        }
        return reference;
    }
    public static unsafe Window GetFromXamlRoot(XamlRoot root)
    {
        var platformWindow = (nint)GetWindowContext(root);
        try
        {
            var cw = CoreWindow.FromAbi(platformWindow);
            return new WindowCoreWindow(cw, root);
        } catch
        {
            try
            {
                var aw = AppWindow.FromAbi(platformWindow);
                return new WindowAppWindow(aw, root);
            } catch
            {
                throw new NotSupportedException();
            }
        }
    }
#else
    static object GetWindowContext(XamlRoot root)
    {
        return root.UIContext.As<IUIContextPartner>().WindowContext;
    }
    public static Window GetFromXamlRoot(XamlRoot root)
    {
        var platformWindow = GetWindowContext(root);
        if (platformWindow is CoreWindow cw)
            return new WindowCoreWindow(cw, root);
        else if (platformWindow is AppWindow aw)
            return new WindowAppWindow(aw, root);
        else
            throw new NotSupportedException();
    }
#endif
    public static async Task<Window> CreateAsync()
    {
        return await CreateAppWindowAsync();
    }
    public static async Task<WindowAppWindow> CreateAppWindowAsync()
    {
        var appwindow = await AppWindow.TryCreateAsync();
        ElementCompositionPreview.SetAppWindowContent(appwindow, new Grid { });
        return new(appwindow, ElementCompositionPreview.GetAppWindowContent(appwindow).XamlRoot);
    }
}