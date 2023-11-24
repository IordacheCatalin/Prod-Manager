﻿using Prod_Manger.Data;
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

        public void Sold(int id)
        {
            // Retrieve the client from the current table
            var soldProduct = _products.GetById(id);

            if (soldProduct != null)
            {
                // Remove the client from the current table


                // Assuming SoldProducts is another DbSet in your context
                // Create a SoldProduct instance and populate it with client data

                var soldItem = new SoldProductModel()
                {
                    // Assign properties from the sold client to the SoldProduct entity
                    // Adjust property assignments based on your SoldProduct entity structure
                    Id = soldProduct.Id,
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

                // Add the client data to the SoldProducts table
                _context.SoldProducts.Add(soldItem);
                _context.SaveChanges();

                // Remove the sold product from the Products table
                _context.Product.Remove(soldProduct); // Ensure this matches the name of the Products DbSet
                _context.SaveChanges();
            }
        }


    }
}
