
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreLAB6_EF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        
        public string Image {  get; set; }

        public string Description { get; set; }
        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
