using System.ComponentModel.DataAnnotations;

namespace MyEShop.Models
{
    public class Order
    {
        [Key]
        public int OrderId{ get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }
        [Required]
        public int UserId { get; set; }
        public Users user { get; set; }
        public List<OrderDetail> orderDetails { get; set; } 
    }
}
