using Microsoft.AspNetCore.Mvc;
using SimpleCrm.Web.Models;
using SimpleCrm.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        // [Description("This is a property")]
        private readonly ICustomerData _customerData;
        private readonly IGreeter _greeter;

        public HomeController(ICustomerData customerData, IGreeter greeter)
        {
            _customerData = customerData;
            _greeter = greeter;
        }

        public IActionResult Details(int id) 
        {
            var customer = _customerData.Get(id);
            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Create(CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    OptInNewsletter = model.OptInNewsletter,
                    Type = model.Type
                };
                _customerData.Save(customer);

                return RedirectToAction(nameof(Details), new { id = customer.Id });
            }
            return View();
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                CurrentMessage = _greeter.GetGreeting(),
                Customers = _customerData.GetAll()
            };
            return View(model);
        }
    }
}
