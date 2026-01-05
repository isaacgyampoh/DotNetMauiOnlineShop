namespace DotNetMauiOnlineShop.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public List<CartItem> Items { get; set; } = new();
}
