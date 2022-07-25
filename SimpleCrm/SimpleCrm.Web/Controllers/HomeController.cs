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
        public IActionResult Index(string id)
        {
            var model = new CustomerModel{
                Id = 1,
                FirstName = "Nick",
                PhoneNumber = "816-231-0460",
                LastName = "Abbott"
            }; 
            return View(model);
        }
    }
}
