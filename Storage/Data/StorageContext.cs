using Microsoft.EntityFrameworkCore;

namespace Storage.Data
{
    public class StorageContext(DbContextOptions<StorageContext> options)
        : DbContext(options)
    {
        public DbSet<Storage.Models.Product> Product { get; set; } = default!;
    }
}
