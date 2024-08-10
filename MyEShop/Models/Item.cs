namespace MyEShop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product product { get; set; }
    }
}
