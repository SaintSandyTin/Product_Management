using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int product_id { get; set; }

        [Display(Name = "Product")]
        [Required]
        public required string product_name { get; set; }

        [Display(Name = "Description")]
        public string? product_desc { get; set; }

        [Display(Name = "Price")]
        public decimal product_price { get; set; }
        public required DateTime createdDate { get; set; }

    }
}
