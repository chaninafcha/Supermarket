
using Microsoft.EntityFrameworkCore;
namespace SuperMS.Domain
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext()
        {
                
        }
        public CategoriesContext(DbContextOptions<CategoriesContext> options):base(options) { }
        
        public virtual DbSet<ProductEntity> products { get; set; }
        public virtual DbSet<CategoriesEntity> categories { get; set; }

        public void SeedData()
        {
            if (!categories.Any())
            {
                // Seed categories
                var categories = new List<CategoriesEntity>
            {
                new CategoriesEntity { name = "מוצרי ניקיון" },
                new CategoriesEntity { name = "גבינות" },
                new CategoriesEntity { name = "ירקות ופירות" },
                new CategoriesEntity { name = "בשר ודגים" },
                new CategoriesEntity { name = "מאפים" },
                // Add more categories as needed
            };

                categories.AddRange(categories);
                SaveChanges();
            }

        }

    }
}
