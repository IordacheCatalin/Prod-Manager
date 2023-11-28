using Microsoft.EntityFrameworkCore;
using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel.CategoryViewModel.Primarycategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;

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


        public SubCatagoryResponse GetSubcategory1ForCategory(string categoryName)
        {
            var response = new SubCatagoryResponse();
            var category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category != null && !string.IsNullOrEmpty(category.SubCategory1))
            {
                var subcategory1List = category.SubCategory1.Split(',').ToList();

                // Populate the CategoryViewModel list in the PrimaryCategoryResponse
                response.subCategory1 = subcategory1List.Select(x => new SubCategoryViewModel
                {
                    SubCategory1 = x // Assuming CategoryViewModel has a property 'Name' for subcategory names
                }).ToList();
            }

            return response;
        }

    }
}
