using System.ComponentModel.DataAnnotations;

namespace MyEShop.Models
{
    public class Users
    {
        [Key]
        public int UserTd { get; set; }
        [Required]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password  { get; set; }
        [Required]
        public DateTime RegisterData { get; set; }
        public bool IsAdmin {  get; set; }  

        public List<Order> orders { get; set; } 
    }
}
