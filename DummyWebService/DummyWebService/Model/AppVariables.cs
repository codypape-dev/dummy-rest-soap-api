using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyWebService.Model
{
    public class AppVariables
    {
        public static string DBConnection { get; set; }
        public static string DatabaseName { get; set; }
        internal static void SetEnviroment(IConfiguration Configuration)
        {
            DBConnection = Configuration["DBConnection"];
            DatabaseName = Configuration["DatabaseName"];
        }
    }
}
