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


        public SubCatagoryResponse GetSubcategoryForCategory(string categoryName)
        {
            var response = new SubCatagoryResponse();
            var selectedSubCatagory = _context.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (selectedSubCatagory != null && !string.IsNullOrEmpty(selectedSubCatagory.SubCategory))
            {
                var subcategoryList = selectedSubCatagory.SubCategory.Split(',').ToList();

                // Populate the CategoryViewModel list in the PrimaryCategoryResponse
                response.subCategory = subcategoryList.Select(x => new SubCategoryViewModel
                {
                    SubCategory = x
                }).ToList();
            }
            return response;
        }

        public SubSubCategoryResponse GetSubSubcategoryForCategory(string categoryName, string subCategory)
        {
            var response = new SubSubCategoryResponse();

            var selectedSubSubCatagory = _context.Categories
                .FirstOrDefault(c => c.Name == categoryName && c.SubCategory == subCategory);

            if (selectedSubSubCatagory != null && !string.IsNullOrEmpty(selectedSubSubCatagory.SubSubCategory))
            {
                var subsubcategoryList = selectedSubSubCatagory.SubSubCategory.Split(',').ToList();

                // Populate the SubSubCategoryViewModel list in the SubSubCategoryResponse
                response.subSubCategory = subsubcategoryList.Select(x => new SubSubCategoryViewModel
                {
                    SubSubCategory = x
                }).ToList();
            }

            return response;
        }



    }
}
