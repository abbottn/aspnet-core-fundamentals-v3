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
            Customer cust = _customerData.Get(id);
            if (cust == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(cust);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Create(CustomerEditViewModel model)
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

            return View("Details", customer);

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
