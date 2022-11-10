namespace NetConfDemo.Interfaces
{
    public interface IPhotoPicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
