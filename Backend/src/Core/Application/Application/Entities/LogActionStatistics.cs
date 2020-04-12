using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Application.Entities
{
    public class LogActionStatistics
    {
        public double Total { get; set; }
        public string Action_Type { get; set; }
        public DateTime Data_Acesso { get; set; }
    }
}