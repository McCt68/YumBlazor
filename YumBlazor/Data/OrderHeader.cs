using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class OrderHeader
    {
        public int OrderHeaderId { get; set; }

        [Required]
        public string UserId { get; set; } // Who is Placing the Order

        [Required]
        [Display(Name = "Order Total")] // I Think I had this as an integer - maybe do new migration
        public double OrderTotal { get; set; }       // Or change back to int  

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")] // this was it will be displayed with a space bettwen Phone and Number
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Navigation Property - I can use this if i want to get details about an order using the OrderDetails Model
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); 
    }
}
