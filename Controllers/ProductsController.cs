using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;
using Prod_Manger.Services.Sell;
using Prod_Manger.ViewModel;


namespace Prod_Manger.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICRUD<ProductModel> _products;
        private readonly ISellMethods _sellMethods;

        public ProductsController(ICRUD<ProductModel> products,
               ISellMethods sellMethods)
        {
            _products = products;
            _sellMethods = sellMethods;
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
                _products.Add(product);
            }
            return RedirectToAction("Index");
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
        public IActionResult Sell(int id, IFormCollection collection)
        {
            // Call the Sell method from SellMethods service to sell a product
            _sellMethods.Sold(id);

            return RedirectToAction("Index");
        }

    }
}
