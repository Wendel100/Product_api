using Microsoft.EntityFrameworkCore;
using Product_api.Model;

namespace Product_api.Db
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
public DbSet<Product> Produtos { get; set; }
    }
}