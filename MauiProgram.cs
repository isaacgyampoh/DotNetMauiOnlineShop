namespace DotNetMauiOnlineShop;

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

        // Services
        builder.Services.AddSingleton<Services.ApiService>();

        // ViewModels
        builder.Services.AddTransient<ViewModels.ProductsViewModel>();
        builder.Services.AddTransient<ViewModels.CartViewModel>();

        // Views
        builder.Services.AddTransient<Views.ProductsPage>();
        builder.Services.AddTransient<Views.CartPage>();
        builder.Services.AddTransient<Views.CheckoutPage>();
        builder.Services.AddTransient<Views.OrderTrackingPage>();

		return builder.Build();
	}
}
