using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
namespace Windows.Internal;
[GeneratedComInterface]
[Guid("f21e14c1-e669-52af-99cd-171eee8e940d")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public unsafe partial interface IUIContextPartner
{
    void Padding1();
    void Padding2();
    void Padding3();
    void get_UIContentRoot(void* reference); // UIContentRoot
    void get_WindowContext(void** reference); // WindowContext is either CoreWindow, AppWindow, or DesktopWindowContentBridge (or anything that implements Windows.UI.IWindowContextPartner)
}
[GeneratedComInterface]
[Guid("45D64A29-A63E-4CB6-B498-5781D298CB4F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
unsafe partial interface ICoreWindowInterop
{
    void get_WindowHandle(nint* reference);
    void put_MessageHandled([MarshalAs(UnmanagedType.Bool)] bool value);
}

[GeneratedComInterface]
[Guid("B74EA3BC-43C1-521F-9C75-E5C15054D78C")]
unsafe partial interface IApplicationWindow_HwndInterop
{
    void Padding1();
    void Padding2();
    void Padding3();
    void get_WindowHandle(Windows.UI.WindowId* reference);
}

