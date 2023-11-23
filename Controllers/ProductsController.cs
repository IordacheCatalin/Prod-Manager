using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Interface;
using Prod_Manger.Models.Domain;
using Prod_Manger.Repository;
using Prod_Manger.ViewModel;
using System.Drawing.Drawing2D;


namespace Prod_Manger.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();


            var productViewList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {     
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Buc = product.Buc,
                    BuyPriceVAT = product.BuyPriceVAT,
                    BuyPriceNoVAT = product.BuyPriceNoVAT,
                    SellPriceVAT = product.SellPriceVAT,
                    SellPriceNoVAT = product.SellPriceNoVAT,
                    BuyDate = product.BuyDate,
                    SellDate = product.SellDate
                };
                productViewList.Add(productViewModel);
            }

            return View("Index", productViewList);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection colletions)
        {
            ProductModel product = new ProductModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(product);
                _productsRepository.AddProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Edit", product);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            ProductModel product = new();
            TryUpdateModelAsync(product);
            _productsRepository.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Details", product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Delete", product);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _productsRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
