using NetConfDemo.Interfaces;

namespace NetConfDemo.Views;

public partial class PhotoPage : ContentPage
{
    IPhotoPicker photoPicker;

    public PhotoPage(IPhotoPicker photoPicker)
	{
		InitializeComponent();

		this.photoPicker = photoPicker;
	}

    async void OnPickPhotoButtonClicked(object sender, EventArgs e)
    {
        (sender as Button).IsEnabled = false;

        Stream stream = await photoPicker.GetImageStreamAsync();

        if (stream != null)
            image.Source = ImageSource.FromStream(() => stream);

        (sender as Button).IsEnabled = true;
    }
}