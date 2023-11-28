using Microsoft.EntityFrameworkCore;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;

namespace Prod_Manger.Services.GetCategories
{
    public interface IGetcatagories
    {
        public DbSet<CategoryModel> GetAllcategories();
        public SubCatagoryResponse GetSubcategory1ForCategory(string categoryName);
    }
}
