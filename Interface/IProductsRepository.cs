using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel;

namespace Prod_Manger.Interface
{
    public interface IProductsRepository
    {
        public IEnumerable<ProductModel> GetProducts();
        public ProductModel GetProductById(int id);
        public void AddProduct(ProductModel product);

        public void UpdateProduct(ProductModel product);
        public void DeleteProduct(int id);
    }
}
