using System.Diagnostics.Contracts;

namespace MyEShop.Models
{
    public class DetailsViewModel
    {
        public Product product {  get; set; }
        public List<Category> categories { get; set; }   
    }
}
