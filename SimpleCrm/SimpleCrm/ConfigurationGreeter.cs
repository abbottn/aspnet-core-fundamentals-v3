using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrm
{
    public class ConfigurationGreeter : IGreeter
    {
        private readonly IConfiguration configuration;
        public ConfigurationGreeter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        string IGreeter.GetGreeting()
        {
            var message = configuration["Greeting"];
            return message;
            
            // throw new NotImplementedException();
        }
    }
}
