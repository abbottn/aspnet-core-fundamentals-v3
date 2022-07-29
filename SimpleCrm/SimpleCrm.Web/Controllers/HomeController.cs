using Microsoft.AspNetCore.Mvc;
using SimpleCrm.Web.Models;
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
        private ICustomerData _customerData;
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
