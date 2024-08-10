namespace MyEShop.Models
{
    public class Product
    {
        public Product()
        {
           
            
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
       
        public Item Item { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public List<OrderDetail> orderDetails { get; set; } 
    }
}
