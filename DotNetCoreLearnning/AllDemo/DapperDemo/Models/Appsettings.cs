using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class Appsettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
