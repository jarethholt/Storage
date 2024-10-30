using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    [Index(nameof(Name), IsUnique=true)]
    public class Category
    {
        [Key]
        public string Name { get; set; } = String.Empty;
    }
}
