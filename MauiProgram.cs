using Microsoft.Extensions.Logging;
using Lab1_maui.Entities;
using Lab1_maui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab1_maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();

		builder.Services.AddTransient<IDbService, SQLiteService>();
		builder.Services.AddTransient<DataBasePage>();
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
