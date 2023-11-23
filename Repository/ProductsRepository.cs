using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel;
using Prod_Manger.Models;
using Prod_Manger.Interface;

namespace Prod_Manger.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProdManagerDbContext _prodManagerDbContext;      

        public ProductsRepository(ProdManagerDbContext prodManagerDbContext)
        {
            _prodManagerDbContext = prodManagerDbContext;          
        }

        public IEnumerable<ProductModel> GetProducts() 
        {
            return _prodManagerDbContext.Product.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel product = _prodManagerDbContext.Product.Find(id);
            return product;
        }

        public void AddProduct(ProductModel product)
        {
            product.Id = new();
            _prodManagerDbContext.Product.Add(product);
            _prodManagerDbContext.SaveChanges();
        }

        public void UpdateProduct(ProductModel product)
        {
            _prodManagerDbContext.Product.Update(product);
            _prodManagerDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            ProductModel product = GetProductById(id);
            if (product != null)
            {
                _prodManagerDbContext.Product.Remove(product);
                _prodManagerDbContext.SaveChanges();
            }
        }

    }
}
