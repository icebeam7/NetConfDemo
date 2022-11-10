using NetConfDemo.Controls;
using NetConfDemo.Handlers;
using NetConfDemo.Interfaces;
using NetConfDemo.Platforms;
using NetConfDemo.Views;

namespace NetConfDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
			{
                handlers.AddHandler(typeof(DrawControl), typeof(DrawControlHandler));
            });

        builder.Services.AddSingleton<IPhotoPicker, PhotoPicker>();

		builder.Services.AddTransient<PhotoPage>();

        return builder.Build();
	}
}
