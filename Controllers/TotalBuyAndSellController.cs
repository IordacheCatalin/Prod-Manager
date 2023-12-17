using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;

namespace Prod_Manger.Controllers
{
    public class TotalBuyAndSellController : Controller
    {
        private readonly ICRUD<TotalBuyAndSellModel> _totalBuyAndSell;

        public TotalBuyAndSellController(ICRUD<TotalBuyAndSellModel> totalBuyAndSell)
        {
            _totalBuyAndSell = totalBuyAndSell;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var totalValue = _totalBuyAndSell.GetAll();

            return View("Index", totalValue);
        }

        //public IActionResult Create()
        //{
        //    return View("Create");
        //}

        //[HttpPost]

        //public IActionResult Create(IFormCollection colletions)
        //{
        //    TotalBuyAndSellModel totalValue = new TotalBuyAndSellModel();
        //    if (ModelState.IsValid)
        //    {
        //        TryUpdateModelAsync(totalValue);
        //        _totalBuyAndSell.Add(totalValue);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    TotalBuyAndSellModel totalValue = _totalBuyAndSell.GetById(id);
        //    return View("Edit", totalValue);
        //}
        //[HttpPost]

        //public IActionResult Edit(int id, IFormCollection colletion)
        //{
        //    TotalBuyAndSellModel totalValue = new();
        //    TryUpdateModelAsync(totalValue);
        //    _totalBuyAndSell.Update(totalValue);

        //    return RedirectToAction("Index");
        //}

    }
}
