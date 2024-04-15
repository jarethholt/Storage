using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, 1_000_000)]
        public int Price { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Orderdate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        [StringLength(128, MinimumLength = 2)]
        public Category Category { get; set; } = default!;
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Shelf { get; set; } = string.Empty;
        [Range(0, 1_000_000)]
        public int Count { get; set; }
        [StringLength(256)]
        public string Description { get; set; } = string.Empty;
    }
}
