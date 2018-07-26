using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class FailGetFactor
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Fields { get; set; }
        public string Parameters { get; set; }
        public DateTime QuarterDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsFirst { get; set; }
    }
}
