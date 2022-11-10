#if IOS || MACCATALYST
using PlatformView = NetConfDemo.Controls.DrawViewControliOS;
#elif ANDROID
using PlatformView = NetConfDemo.Controls.DrawViewControlAndroid;
#elif WINDOWS
using PlatformView = NetConfDemo.Controls.DrawViewWindows;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using IDrawControl = NetConfDemo.Controls.IDrawControl;

namespace NetConfDemo.Handlers
{
    public interface IDrawControlHandler : IViewHandler
    {
        new IDrawControl VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}
