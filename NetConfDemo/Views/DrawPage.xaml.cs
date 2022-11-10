namespace NetConfDemo.Views;

public partial class DrawPage : ContentPage
{
	public DrawPage()
	{
		InitializeComponent();
	}

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        drawView.Clear();
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        drawView.Save();

        await DisplayAlert("Great!", 
            "Signature saved, check Pictures folder!", 
            "OK");
    }
}