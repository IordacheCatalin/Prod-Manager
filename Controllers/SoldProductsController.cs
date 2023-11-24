using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;

namespace Prod_Manger.Controllers
{
    public class SoldProductsController : Controller
    {
        private readonly ICRUD<SoldProductModel> _soldProductRepository;

        public SoldProductsController(ICRUD<SoldProductModel> soldProductRepository)
        {
            _soldProductRepository = soldProductRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var soldProducts = _soldProductRepository.GetAll();

            return View("Index", soldProducts);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection colletions)
        {
            SoldProductModel soldProducts = new SoldProductModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(soldProducts);
                _soldProductRepository.Add(soldProducts);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            SoldProductModel soldProducts = _soldProductRepository.GetById(id);
            return View("Edit", soldProducts);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            SoldProductModel soldProducts = new();
            TryUpdateModelAsync(soldProducts);
            _soldProductRepository.Update(soldProducts);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            SoldProductModel soldProducts = _soldProductRepository.GetById(id);
            return View("Details", soldProducts);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            SoldProductModel soldProducts = _soldProductRepository.GetById(id);
            return View("Delete", soldProducts);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _soldProductRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
