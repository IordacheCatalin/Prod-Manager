using Microsoft.EntityFrameworkCore;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel;

namespace Prod_Manger.Data
{
    public class ProdManagerDbContext : DbContext
    {
        public ProdManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<SoldProductModel> SoldProducts { get; set; }

    }
}
