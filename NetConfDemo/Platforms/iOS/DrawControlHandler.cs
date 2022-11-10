using Microsoft.Maui.Handlers;
using IDrawControl = NetConfDemo.Controls.IDrawControl;
using NetConfDemo.Controls;

namespace NetConfDemo.Handlers
{
    public partial class DrawControlHandler : 
        ViewHandler<IDrawControl, DrawViewControliOS>
    {
        DrawViewControliOS? _drawView;

        protected override DrawViewControliOS CreatePlatformView()
        {
            if (_drawView == null)
            {
                _drawView = new DrawViewControliOS();
            }

            return _drawView;
        }
    }
}