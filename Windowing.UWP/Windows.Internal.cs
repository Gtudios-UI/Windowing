using System.Runtime.InteropServices;
namespace Windows.Internal;
[Guid("f21e14c1-e669-52af-99cd-171eee8e940d")]
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
public interface IUIContextPartner
{
    public UIContentRoot UIContentRoot { get; }
    public object WindowContext { [return: MarshalAs(UnmanagedType.IInspectable)] get; } // WindowContext is either CoreWindow, AppWindow, or DesktopWindowContentBridge (or anything that implements Windows.UI.IWindowContextPartner)
}
[ComImport, Guid("45D64A29-A63E-4CB6-B498-5781D298CB4F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface ICoreWindowInterop
{
    IntPtr WindowHandle { get; }
    bool MessageHandled { set; }
}
[ComImport, Guid("B74EA3BC-43C1-521F-9C75-E5C15054D78C"), InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
interface IApplicationWindow_HwndInterop
{
    Windows.UI.WindowId WindowHandle { get; }
}