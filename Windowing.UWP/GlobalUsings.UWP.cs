global using Windows.Foundation;
global using Windows.Foundation.Collections;
global using Microsoft.UI;
global using Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Controls;
global using Microsoft.UI.Xaml.Controls.Primitives;
global using Microsoft.UI.Xaml.Media;
global using Windows.UI;
global using Windows.UI.Xaml;
global using Windows.UI.Xaml.Controls;
global using Windows.UI.Xaml.Controls.Primitives;
global using Windows.UI.Xaml.Data;
global using Windows.UI.Xaml.Input;
global using Windows.UI.Xaml.Media;
global using Windows.UI.Xaml.Navigation;
global using Windows.UI.Xaml.Media.Animation;
global using IconSource = Microsoft.UI.Xaml.Controls.IconSource;
global using Windows.System;
global using Windows.UI.Xaml.Markup;
global using Windows.UI.Input;
global using Windows.UI.Xaml.Hosting;
global using Platform = Windows;
using System.Runtime.InteropServices;
using Windows.UI.Core;

struct Nothing { }
namespace System.Threading.Tasks
{
    class TaskCompletionSource : TaskCompletionSource<Nothing>
    {
        public void SetResult() => SetResult(default);
    }
}
namespace WinRT
{
    static class Extension
    {
        public static T As<T>(this object obj)
        {
            Guid guid = typeof(T).GUID;
            Marshal.QueryInterface(Marshal.GetIUnknownForObject(obj),
                ref guid,
                out var corewindowinterop
            );
            return (T)Marshal.GetObjectForIUnknown(corewindowinterop);
        }
    }
}