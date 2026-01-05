using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNetMauiOnlineShop.Models;
using DotNetMauiOnlineShop.Services;
using System.Collections.ObjectModel;

namespace DotNetMauiOnlineShop.ViewModels;

public partial class CartViewModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private decimal _totalAmount;

    public ObservableCollection<CartItem> CartItems { get; } = new();

    public CartViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [RelayCommand]
    private async Task LoadCartAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var items = await _apiService.GetCartAsync();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(item);
            }
            UpdateTotal();
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void UpdateTotal()
    {
        TotalAmount = CartItems.Sum(i => i.Total);
    }

    public ObservableCollection<Order> Orders { get; } = new();

    [RelayCommand]
    private async Task LoadOrdersAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            var orders = await _apiService.GetOrdersAsync();
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task PlaceOrderAsync()
    {
        if (CartItems.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "Cart is empty", "OK");
            return;
        }

        IsLoading = true;
        await _apiService.PlaceOrderAsync();
        CartItems.Clear();
        UpdateTotal();
        IsLoading = false;
        await Shell.Current.DisplayAlert("Success", "Order placed successfully!", "OK");
        await LoadOrdersAsync(); // Refresh orders
    }
}
