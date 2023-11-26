using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;
using Prod_Manger.ViewModel;

namespace Prod_Manger.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICRUD<CategoryModel> _categories;
        public CategoriesController(ICRUD<CategoryModel> categories)
        {
            _categories = categories;
        }

        public IActionResult Index()
        {
            var category = _categories.GetAll();

            return View("Index", category);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection colletions)
        {
            CategoryModel category = new CategoryModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(category);
                _categories.Add(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            CategoryModel category = _categories.GetById(id);
            return View("Edit", category);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            CategoryModel category = new();
            TryUpdateModelAsync(category);
            _categories.Update(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            CategoryModel category = _categories.GetById(id);
            return View("Details", category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryModel category = _categories.GetById(id);
            return View("Delete", category);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _categories.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
