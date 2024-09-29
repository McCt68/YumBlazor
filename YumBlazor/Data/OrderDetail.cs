using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; } 

        public int ProductId { get; set; } // In the MOdel for Prodcut this is just called Id

        public Product Product { get; set; } // Navigation Property

        [Required]
        public int Count { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}
