using NetConfDemo.Services;

namespace NetConfDemo.Views;

public partial class PhotoServicePage : ContentPage
{
    PhotoService photoService;

	public PhotoServicePage()
	{
		InitializeComponent();

        photoService = new PhotoService();
	}

    async void OnPickPhotoButtonClicked(object sender, EventArgs e)
    {
        (sender as Button).IsEnabled = false;

        Stream stream = await photoService.GetImageStreamAsync();

        if (stream != null)
            image.Source = ImageSource.FromStream(() => stream);

        (sender as Button).IsEnabled = true;
    }

}