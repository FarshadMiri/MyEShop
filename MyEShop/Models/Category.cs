namespace MyEShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CtegoryName { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
