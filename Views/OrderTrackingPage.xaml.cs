using DotNetMauiOnlineShop.ViewModels;

namespace DotNetMauiOnlineShop.Views;

public partial class OrderTrackingPage : ContentPage
{
	public OrderTrackingPage(CartViewModel viewModel) // Reusing CartViewModel for simplicity as it has orders
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
