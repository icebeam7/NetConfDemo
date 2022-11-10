namespace NetConfDemo.Controls
{
    public partial class DrawControl : View, IDrawControl
    {
        public static readonly BindableProperty DrawColorProperty =
            BindableProperty.Create(nameof(DrawColor), typeof(Color), 
                typeof(DrawControl), Colors.Black);

        public Color DrawColor
        {
            get => (Color)GetValue(DrawColorProperty);
            set { SetValue(DrawColorProperty, value); }
        }

        public void Clear()
        {
            MessagingCenter.Send(this, "Clear");
        }

        public void Save()
        {
            MessagingCenter.Send(this, "Save");
        }
    }
}
