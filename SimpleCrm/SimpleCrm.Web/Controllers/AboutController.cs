using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrm.Web.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("address")]
        // private string phone;
        
        public string Address()
        {
            return "USA";
        }

        [Route("phone")]
        public string Phone(/* string phone */ )
        {
            // this.phone = phone;
            return "314-555-5555";
        }
    }
}
