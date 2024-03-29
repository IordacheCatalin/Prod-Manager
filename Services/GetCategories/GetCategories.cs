﻿using Microsoft.EntityFrameworkCore;
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
                var distinctSubcategories = selectedSubCategory
                    .SelectMany(c => (c.SubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()))
                    .Distinct()
                    .ToList();

                var subcategoryList = distinctSubcategories
                    .Select(x => new SubCategoryViewModel { SubCategory = x })
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
                var distinctSubSubcategories = selectedSubSubCategories
                    .SelectMany(c => (c.SubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()))
                    .Distinct()
                    .ToList();

                var subSubcategoryList = distinctSubSubcategories
                    .Select(x => new SubSubCategoryViewModel { SubSubCategory = x })
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

                var distinctSubSubSubcategories = selectedSubSubSubCategories
                    .SelectMany(c => (c.SubSubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()))
                    .Distinct()
                    .ToList();

                var subSubSubcategoryList = distinctSubSubSubcategories
                    .Select(x => new SubSubSubCategoryViewModel { SubSubSubCategory = x })
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
                var distinctSubSubSubSubcategories = selectedSubSubSubSubCategories
                   .SelectMany(c => (c.SubSubSubSubCategory ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => x.Trim()))
                   .Distinct()
                   .ToList();

                var subSubSubSubcategoryList = distinctSubSubSubSubcategories
                    .Select(x => new SubSubSubSubCategoryViewModel { SubSubSubSubCategory = x })
                    .ToList();              

                response.subSubSubSubCategory = subSubSubSubcategoryList;
            }

            return response;
        }

    }
}
