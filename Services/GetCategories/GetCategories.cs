using Microsoft.EntityFrameworkCore;
using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel.CategoryViewModel.Primarycategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;
using Prod_Manger.ViewModel.CategoryViewModel.SubSubCategory;

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

            // Fetch subcategories for the specified category name
            var selectedCategory = _context.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (selectedCategory != null && !string.IsNullOrEmpty(selectedCategory.SubCategory))
            {
                var subcategoryList = selectedCategory.SubCategory
                    .Split(',', StringSplitOptions.RemoveEmptyEntries) // Split subcategories and remove empty entries
                    .Select(x => new SubCategoryViewModel { SubCategory = x.Trim() }) // Create SubCategoryViewModel objects
                    .ToList();

                response.subCategory = subcategoryList;
            }

            return response;
        }

        public SubSubCategoryResponse GetSubSubCategoryForCategory(string categoryName, string subCategory)
        {
            var response = new SubSubCategoryResponse();

            // Retrieve a record matching both category and subcategory names
            var selectedSubSubCategory = _context.Categories
                .FirstOrDefault(c => c.Name == categoryName && c.SubCategory == subCategory);

            if (selectedSubSubCategory != null && !string.IsNullOrEmpty(selectedSubSubCategory.SubSubCategory))
            {
                var subSubcategoryList = selectedSubSubCategory.SubSubCategory
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new SubSubCategoryViewModel { SubSubCategory = x.Trim() })
                    .ToList();

                response.subSubCategory = subSubcategoryList;
            }

            return response;
        }

        //public SubSubCategoryResponse GetSubSubcategoryForCategory(string categoryName, string subCategory)
        //{
        //    var response = new SubSubCategoryResponse();

        //    var selectedSubSubCatagory = _context.Categories
        //        .FirstOrDefault(c => c.Name == categoryName && c.SubCategory == subCategory);

        //    if (selectedSubSubCatagory != null && !string.IsNullOrEmpty(selectedSubSubCatagory.SubSubCategory))
        //    {
        //        var subsubcategoryList = selectedSubSubCatagory.SubSubCategory.Split(',').ToList();

        //        // Populate the SubSubCategoryViewModel list in the SubSubCategoryResponse
        //        response.subSubCategory = subsubcategoryList.Select(x => new SubSubCategoryViewModel
        //        {
        //            SubSubCategory = x
        //        }).ToList();
        //    }

        //    return response;
        //}


    }
}
