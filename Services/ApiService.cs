using DotNetMauiOnlineShop.Models;

namespace DotNetMauiOnlineShop.Services;

public class ApiService
{
    private readonly List<Product> _products;
    private readonly List<CartItem> _cart;
    private readonly List<Order> _orders;

    public ApiService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "High performance laptop", ImageUrl = "laptop.png" },
            new Product { Id = 2, Name = "Smartphone", Price = 699.99m, Description = "Latest smartphone", ImageUrl = "phone.png" },
            new Product { Id = 3, Name = "Headphones", Price = 199.99m, Description = "Noise cancelling headphones", ImageUrl = "headphones.png" },
            new Product { Id = 4, Name = "Smart Watch", Price = 249.99m, Description = "Fitness tracker and smart watch", ImageUrl = "watch.png" }
        };
        _cart = new List<CartItem>();
        _orders = new List<Order>();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        // Simulate network delay
        await Task.Delay(500);
        return _products;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        await Task.Delay(200);
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public async Task AddToCartAsync(Product product)
    {
        await Task.Delay(200);
        var existingItem = _cart.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            _cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1
            });
        }
    }

    public async Task<List<CartItem>> GetCartAsync()
    {
        await Task.Delay(200);
        return _cart;
    }

    public async Task PlaceOrderAsync()
    {
        await Task.Delay(500);
        if (_cart.Any())
        {
            var order = new Order
            {
                Id = _orders.Count + 1,
                OrderDate = DateTime.Now,
                Status = "Processing",
                Items = new List<CartItem>(_cart),
                TotalAmount = _cart.Sum(i => i.Total)
            };
            _orders.Add(order);
            _cart.Clear();
        }
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        await Task.Delay(200);
        return _orders;
    }
}
