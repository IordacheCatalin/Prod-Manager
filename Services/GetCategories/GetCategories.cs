using Microsoft.EntityFrameworkCore;
using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel.CategoryViewModel.Primarycategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubCategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubSubCategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubSubSubCategory;

namespace Prod_Manger.Services.GetCategories
{
    public class GetCategories : IGetcatagories
    {
        private readonly ProdManagerDbContext _context;
        public GetCategories(ProdManagerDbContext context)
        {
            _context = context;
        }

        public DbSet<CategoryModel> GetAllcategories()
        {
            return _context.Categories;
        }


        public SubCategoryResponse GetSubCategoryForCategory(string categoryName)
        {
            var response = new SubCategoryResponse();

            // Fetch all categories that match the specified category name
            var selectedSubCategory = _context.Categories.Where(c => c.Name == categoryName).ToList();

            if (selectedSubCategory != null && selectedSubCategory.Any())
            {
                var subcategoryList = selectedSubCategory
                    .SelectMany(c => (c.SubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => new SubCategoryViewModel { SubCategory = x.Trim() }))
                    .ToList();

                response.subCategory = subcategoryList;
            }

            return response;
        }
        public SubSubCategoryResponse GetSubSubCategoryForCategory(string categoryName, string subCategory)
        {
            var response = new SubSubCategoryResponse();

            // Retrieve all records matching both category and subcategory names
            var selectedSubSubCategories = _context.Categories
                .Where(c => c.Name == categoryName && c.SubCategory == subCategory)
                .ToList(); // Fetch data from the database

            if (selectedSubSubCategories != null && selectedSubSubCategories.Any())
            {
                var subSubcategoryList = selectedSubSubCategories
                    .SelectMany(c => (c.SubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => new SubSubCategoryViewModel { SubSubCategory = x.Trim() })
                    .ToList();

                response.subSubCategory = subSubcategoryList;
            }

            return response;
        }

        public SubSubSubCategoryResponse GetSubSubSubCategoryForCategory(string categoryName, string subCategory, string subSubCategory)
        {
            var response = new SubSubSubCategoryResponse();

            // Retrieve all records matching both category and subcategory names
            var selectedSubSubSubCategories = _context.Categories
                .Where(c => c.Name == categoryName && c.SubCategory == subCategory && c.SubSubCategory == subSubCategory)
                .ToList(); // Fetch data from the database

            if (selectedSubSubSubCategories != null && selectedSubSubSubCategories.Any())
            {
                var subSubSubcategoryList = selectedSubSubSubCategories
                    .SelectMany(c => (c.SubSubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => new SubSubSubCategoryViewModel { SubSubSubCategory = x.Trim() })
                    .ToList();

                response.subSubSubCategory = subSubSubcategoryList;
            }

            return response;
        }

        public SubSubSubSubCategoryResponse GetSubSubSubSubCategoryForCategory(string categoryName, string subCategory, string subSubCategory, string subSubSubCategory)
        {
            var response = new SubSubSubSubCategoryResponse();

            // Retrieve all records matching both category and subcategory names
            var selectedSubSubSubSubCategories = _context.Categories
                .Where(c => c.Name == categoryName && c.SubCategory == subCategory && c.SubSubCategory == subSubCategory && c.SubSubSubCategory == subSubSubCategory) 
                .ToList(); // Fetch data from the database

            if (selectedSubSubSubSubCategories != null && selectedSubSubSubSubCategories.Any())
            {
                var subSubSubSubcategoryList = selectedSubSubSubSubCategories
                    .SelectMany(c => (c.SubSubSubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => new SubSubSubSubCategoryViewModel { SubSubSubSubCategory = x.Trim() })
                    .ToList();

                response.subSubSubSubCategory = subSubSubSubcategoryList;
            }

            return response;
        }

    }
}
