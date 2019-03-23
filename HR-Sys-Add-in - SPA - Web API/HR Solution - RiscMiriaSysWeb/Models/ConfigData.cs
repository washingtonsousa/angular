using System;
using System.Security;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class ConfigData
    {
        public String NomePortal { get; set; }
        public String URLSiteMandatorio { get; set; }
        public String ChamadoServiceEmail { get; set; }
        public String SenhaChamadoServiceEmail { get; set; }
        public String EmailPort { get; set; }
        public String EmailPassword { get; set; }
        public String EmailAccount { get; set; }
        public String EmailSmtpServer { get; set; }

    }
}
