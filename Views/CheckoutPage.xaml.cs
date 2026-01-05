using DotNetMauiOnlineShop.ViewModels;

namespace DotNetMauiOnlineShop.Views;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage(CartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
