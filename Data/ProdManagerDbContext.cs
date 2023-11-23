using Microsoft.EntityFrameworkCore;
using Prod_Manger.Models.Domain;

namespace Prod_Manger.Data
{
    public class ProdManagerDbContext : DbContext
    {
        public ProdManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }


    }
}
