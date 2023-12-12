using Microsoft.EntityFrameworkCore;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubCategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubSubCategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubSubSubCategory;

namespace Prod_Manger.Services.GetCategories
{
    public interface IGetcatagories
    {
        public DbSet<CategoryModel> GetAllcategories();
        public SubCategoryResponse GetSubCategoryForCategory(string categoryName);
        public SubSubCategoryResponse GetSubSubCategoryForCategory(string categoryName, string subCategory);
        public SubSubSubCategoryResponse GetSubSubSubCategoryForCategory(string categoryName, string subCategory, string subSubCategory);
        public SubSubSubSubCategoryResponse GetSubSubSubSubCategoryForCategory(string categoryName, string subCategory, string subSubCategory, string subSubSubCategory);
    }
}
