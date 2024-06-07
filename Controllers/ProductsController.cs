using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;
using Prod_Manger.Services.GetCategories;
using Prod_Manger.Services.Sell;
using Prod_Manger.ViewModel;
using Prod_Manger.ViewModel.CategoryViewModel.Primarycategory;
using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;


namespace Prod_Manger.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICRUD<ProductModel> _products;
        private readonly ISellMethods _sellMethods;
        private readonly ICRUD<CategoryModel> _categories;
        private readonly IGetcatagories _getcategories;

        public ProductsController(ICRUD<ProductModel> products,
                                  ISellMethods sellMethods,
                                  ICRUD<CategoryModel> categories,
                                  IGetcatagories getcategories)
        {
            _products = products;
            _sellMethods = sellMethods;
            _categories = categories;
            _getcategories = getcategories;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _products.GetAll();


            var productViewList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    SubCategory = product.SubCategory,
                    SubSubCategory = product.SubSubCategory,
                    SubSubSubCategory = product.SubSubSubCategory,
                    SubSubSubSubCategory = product.SubSubSubSubCategory,
                    Buc = product.Buc,
                    BuyPriceVAT = product.BuyPriceVAT,
                    BuyPriceNoVAT = product.BuyPriceNoVAT,
                    SellPriceVAT = product.SellPriceVAT,
                    SellPriceNoVAT = product.SellPriceNoVAT,
                    BuyDate = product.BuyDate,
                    SellDate = product.SellDate,
                    TotalBuyPriceVAT = product.TotalBuyPriceVAT,
                    TotalBuyPriceNoVAT = product.TotalBuyPriceNoVAT,
                    TotalSellPriceVAT = product.TotalSellPriceVAT,
                    TotalSellPriceNoVAT = product.TotalSellPriceNoVAT,
                    BuyInvoice = product.BuyInvoice,
                    InvoiceManagement = product.InvoiceManagement

    };
                productViewList.Add(productViewModel);
            }

            return View("Index", productViewList);
        }

        public IActionResult Create()
        {
            //var categories = _categories.GetAll().Select(category => new SelectListItem
            //{
            //    Value = category.Id.ToString(),
            //    Text = category.Name
            //}).ToList() ?? new List<SelectListItem>();

            //ViewBag.Categories = categories;

            var categories = _categories.GetAll();

            var uniqueCategoryNames = categories.Select(category => category.Name).Distinct();

            var categoriesList = new PrimaryCategoryResponse();

            foreach (var categoryName in uniqueCategoryNames)
            {
                var categoryViewModel = new CategoryViewModel
                {
                    Name = categoryName
                };
                categoriesList.CategoryName.Add(categoryViewModel);
            }

            ViewBag.dataCategory = categoriesList;

            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection colletions)
        {
            ProductModel product = new ProductModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(product);
                _products.Add(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetSubCategory(string categoryName)
        {
            var subCategoryResponse = _getcategories.GetSubCategoryForCategory(categoryName);
            return Json(subCategoryResponse);
        }


        [HttpGet]
        public IActionResult GetSubSubCategory(string categoryName, string subCategory)
        {
            var subSubCategoryResponse = _getcategories.GetSubSubCategoryForCategory(categoryName, subCategory);
            return Json(subSubCategoryResponse);
        }

        [HttpGet]
        public IActionResult GetSubSubSubCategory(string categoryName, string subCategory, string subSubCategory)
        {
            var subSubSubCategoryResponse = _getcategories.GetSubSubSubCategoryForCategory(categoryName, subCategory, subSubCategory);
            return Json(subSubSubCategoryResponse);
        }

        [HttpGet]
        public IActionResult GetSubSubSubSubCategory(string categoryName, string subCategory, string subSubCategory, string subSubSubCategory)
        {
            var subSubSubSubCategoryResponse = _getcategories.GetSubSubSubSubCategoryForCategory(categoryName, subCategory, subSubCategory, subSubSubCategory);
            return Json(subSubSubSubCategoryResponse);
        }



        public IActionResult Edit(int id)
        {
            ProductModel product = _products.GetById(id);
            return View("Edit", product);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            ProductModel product = new();
            TryUpdateModelAsync(product);
            _products.Update(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ProductModel product = _products.GetById(id);
            return View("Details", product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductModel product = _products.GetById(id);
            return View("Delete", product);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _products.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sell(int id, int ItemQuantity, string InvoiceNumber)
        {
            try
            {
                _sellMethods.SellItem(id, ItemQuantity, InvoiceNumber);

                return Json(new { success = true }); ;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while selling the product: {ex.Message}");

            
                return Json(new { success = false, errorMessage = "An error occurred while selling the product." });
            }
        }

    }
}
