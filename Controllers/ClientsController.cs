using Microsoft.AspNetCore.Mvc;
using Prod_Manger.Models.Domain;
using Prod_Manger.Services.CRUD;


namespace Prod_Manger.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ICRUD<ClientModel> _clients;
        public ClientsController(ICRUD<ClientModel> clients)
        {
            _clients = clients;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var clients = _clients.GetAll();


            var clientViewList = new List<ClientViewModel>();

            foreach (var client in clients)
            {
                var clientViewModel = new ClientViewModel()
                {
                    Id = client.Id,
                    Name = client.Name,
                    LastName = client.LastName,
                    Phone = client.Phone,
                    County = client.County,
                    City = client.City,
                    Street = client.Street,
                    StreetNo = client.StreetNo,
                    Building = client.Building,
                    BuildingNo = client.BuildingNo,
                    Floor = client.Floor,
                    Ap = client.Ap,
                    PersonType = client.PersonType,
                    CNP = client.CNP,
                    CUI = client.CUI,
                    RegistrationNumber = client.RegistrationNumber,
                    DeliveryCounty = client.DeliveryCounty,
                    DeliveryCity = client.DeliveryCity,
                    DeliveryStreet = client.DeliveryStreet,
                    DeliveryStreetNo = client.DeliveryStreetNo,
                    DeliveryBuilding = client.DeliveryBuilding,
                    DeliveryBuildingNo = client.DeliveryBuildingNo,
                    DeliveryFloor = client.DeliveryFloor,
                    DeliveryAp = client.DeliveryAp,
                    Description = client.Description,
                    DateCreated = client.DateCreated,
                };
                clientViewList.Add(clientViewModel);
            }
            return View("Index", clientViewList);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection colletions)
        {
            ClientModel clients = new ClientModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(clients);
                _clients.Add(clients);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ClientModel clients = _clients.GetById(id);
            return View("Edit", clients);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            ClientModel clients = new();
            TryUpdateModelAsync(clients);
            _clients.Update(clients);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ClientModel clients = _clients.GetById(id);
            return View("Details", clients);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ClientModel clients = _clients.GetById(id);
            return View("Delete", clients);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _clients.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
