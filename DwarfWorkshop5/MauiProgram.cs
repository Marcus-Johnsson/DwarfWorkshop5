using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.Models;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Core;

namespace DwarfWorkshop5;

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
			});
		
			builder.Services.AddSingleton<MyDbContext>();
			builder.UseMauiApp<App>().UseMauiCommunityToolkitCore();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
