using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;

namespace Prod_Manger.Services.Sell
{
    public class SellMethods : ISellMethods
    {
        private readonly ProdManagerDbContext _context;
        private readonly ICRUD<ProductModel> _products;
        public SellMethods(ProdManagerDbContext context, ICRUD<ProductModel> products)
        {
            _context = context;
            _products = products;
        }

        public void SellItem(int id, int ItemQuantity)
        {
            // Retrieve the client from the current table
            var soldProduct = _products.GetById(id);

            if (soldProduct != null && ItemQuantity > 0 && ItemQuantity <= soldProduct.Buc)
            {
                // Remove the client from the current table


                // Assuming SoldProducts is another DbSet in your context
                // Create a SoldProduct instance and populate it with client data

                var soldItem = new SoldProductModel()
                {
                    // Assign properties from the sold client to the SoldProduct entity
                    // Adjust property assignments based on your SoldProduct entity structure
                    Id = new(),
                    Name = soldProduct.Name,
                    Description = soldProduct.Description,
                    Category = soldProduct.Category,
                    Buc = soldProduct.Buc,
                    BuyPriceVAT = soldProduct.BuyPriceVAT,
                    BuyPriceNoVAT = soldProduct.BuyPriceNoVAT,
                    SellPriceVAT = soldProduct.SellPriceVAT,
                    SellPriceNoVAT = soldProduct.SellPriceNoVAT,
                    BuyDate = soldProduct.BuyDate,
                    SellDate = soldProduct.SellDate

                };

                if (ItemQuantity == 1)
                {                 
                    _context.SoldProducts.Add(soldItem);
                    _context.Product.Remove(soldProduct);
                }
                else if (soldProduct.Buc > 1)
                {
                    soldProduct.Buc -= ItemQuantity;
                    soldItem.Buc = ItemQuantity;
                    _context.Product.Update(soldProduct);
                    _context.SoldProducts.Add(soldItem);
                }
                _context.SaveChanges();
            }
        }

    }
}
