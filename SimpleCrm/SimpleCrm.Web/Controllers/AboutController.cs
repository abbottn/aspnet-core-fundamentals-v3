using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrm.Web.Controllers
{
    public class AboutController
    {
        private string phone;
        public string Address()
        {
            return "USA";
        }

        public string Phone(string phone)
        {
            this.phone = phone;
            return phone;
        }
    }
}
