using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNetMauiOnlineShop.Models;
using DotNetMauiOnlineShop.Services;
using System.Collections.ObjectModel;

namespace DotNetMauiOnlineShop.ViewModels;

public partial class ProductsViewModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private bool _isLoading;

    public ObservableCollection<Product> Products { get; } = new();

    public ProductsViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [RelayCommand]
    private async Task LoadProductsAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var products = await _apiService.GetProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task AddToCartAsync(Product product)
    {
        if (product == null) return;
        await _apiService.AddToCartAsync(product);
        await Shell.Current.DisplayAlert("Success", $"{product.Name} added to cart", "OK");
    }

    [RelayCommand]
    private async Task GoToCartAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.CartPage));
    }
}
