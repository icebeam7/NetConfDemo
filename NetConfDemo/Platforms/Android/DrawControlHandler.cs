using NetConfDemo.Controls;
using Microsoft.Maui.Handlers;
using IDrawControl = NetConfDemo.Controls.IDrawControl;

namespace NetConfDemo.Handlers
{
    public partial class DrawControlHandler : 
        ViewHandler<IDrawControl, DrawViewControlAndroid>
    {
        DrawViewControlAndroid? _drawView;

        protected override DrawViewControlAndroid CreatePlatformView()
        {
            if (_drawView == null)
            {
                _drawView = new DrawViewControlAndroid(Context);
            }

            return _drawView;
        }
    }
}
