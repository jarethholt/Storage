using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    [Index(nameof(Name), IsUnique=true)]
    public class Category
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; } = String.Empty;
    }
}
