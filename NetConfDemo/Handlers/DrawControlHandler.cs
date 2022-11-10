#if IOS || MACCATALYST
using PlatformView = NetConfDemo.Controls.DrawViewControliOS;
#elif ANDROID
using PlatformView = NetConfDemo.Controls.DrawViewControlAndroid;
#elif WINDOWS
using PlatformView = NetConfDemo.Controls.DrawViewControlWindows;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif

using Microsoft.Maui.Platform;
using Microsoft.Maui.Handlers;

using NetConfDemo.Controls;
using IDrawControl = NetConfDemo.Controls.IDrawControl;

namespace NetConfDemo.Handlers
{
    public partial class DrawControlHandler : IDrawControlHandler
    {
        public static IPropertyMapper<IDrawControl, IDrawControlHandler> Mapper =
            new PropertyMapper<IDrawControl, IDrawControlHandler>(ViewHandler.ViewMapper) {
                [nameof(IDrawControl.DrawColor)] = DrawColor,
            };

        IDrawControl IDrawControlHandler.VirtualView => VirtualView;

        PlatformView IDrawControlHandler.PlatformView => PlatformView;

        public DrawControlHandler() : base(Mapper) { }

        static void DrawColor(IDrawControlHandler handler, IDrawControl draw)
        {
            handler.PlatformView.PaintColor = draw.DrawColor.ToPlatform();
        }

        protected override void ConnectHandler(PlatformView platformView)
        {
            base.ConnectHandler(platformView);

            MessagingCenter.Subscribe<DrawControl>(this, "Clear", OnMessageClear);
            MessagingCenter.Subscribe<DrawControl>(this, "Save", OnMessageSave);
        }

        protected override void DisconnectHandler(PlatformView platformView)
        {
            MessagingCenter.Unsubscribe<DrawControl>(this, "Clear");
            MessagingCenter.Unsubscribe<DrawControl>(this, "Save");

            PlatformView?.Dispose();

            base.DisconnectHandler(platformView);
        }

        void OnMessageClear(IDrawControl sender)
        {
            if (sender == VirtualView)
                PlatformView.Clear();
        }

        void OnMessageSave(IDrawControl sender)
        {
            if (sender == VirtualView)
                PlatformView.Save();
        }
    }
}