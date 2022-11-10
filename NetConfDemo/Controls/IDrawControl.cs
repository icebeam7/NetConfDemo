namespace NetConfDemo.Controls
{
    public interface IDrawControl : IView
    {
        Color DrawColor { get; }

        void Clear();

        void Save();
    }
}
