using Microsoft.Extensions.Logging;
using MyMauiApp.Services;

namespace MyMauiApp;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


		// Register HttpClient (needed for API calls)
		//add "dotnet add package Microsoft.Extensions.Http" if not already added
		builder.Services.AddHttpClient();

		// ========================================
		// OPTION 1: Use LOCAL data (UserService)
		// Uncomment the line below to use in-memory data
		// ========================================
		//builder.Services.AddSingleton<IUserService, UserService>();

		// ========================================
		// OPTION 2: Use API data (TestUserService)
		// Uncomment the line below to use real API data
		// ========================================
		builder.Services.AddSingleton<IUserService, TestUserService>();

		return builder.Build();
	}
}
