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

        public HomeController(ICustomerData customerData)
        {
            _customerData = customerData;
        }

        public IActionResult Index()
        {
            var model = _customerData.GetAll(); 
            return View(model);
        }
    }
}
