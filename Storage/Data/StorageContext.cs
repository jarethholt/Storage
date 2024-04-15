using Microsoft.EntityFrameworkCore;

namespace Storage.Data
{
    public class StorageContext(DbContextOptions<StorageContext> options)
        : DbContext(options)
    {
        public DbSet<Models.Product> Products { get; set; } = default!;
        public DbSet<Models.Category> Categories { get; set; } = default!;
    }
}
