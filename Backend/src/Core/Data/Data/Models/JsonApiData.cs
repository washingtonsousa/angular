using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RiscServicesHRSharepointAddIn.Models
{
    public class JsonApiData
    {
        public string @context { get; set; }
        public object @data { get; set; }
    }
}
