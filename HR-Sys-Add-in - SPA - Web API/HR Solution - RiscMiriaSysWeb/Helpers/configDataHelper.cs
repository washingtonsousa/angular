using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;

namespace RiscServicesHRSharepointAddIn.Helpers
{
  public class ConfigDataHelper
    {
    private ConfigData configData;
        public Dictionary<string, string> configDataDictionary { get; set; }


        public ConfigDataHelper()
        {
            configData = new ConfigData();

        }


   public ConfigData getConfigDataFromConfigFile()
    {
      configData.EmailAccount = ConfigurationManager.AppSettings["EmailAccount"];
      configData.EmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
      configData.EmailPort = ConfigurationManager.AppSettings["EmailPort"];
      configData.EmailSmtpServer = ConfigurationManager.AppSettings["EmailSmtpServer"];
      configData.NomePortal = ConfigurationManager.AppSettings["NomePortal"];
      configData.URLSiteMandatorio = ConfigurationManager.AppSettings["URLSiteMandatorio"];
      configData.ChamadoServiceEmail = ConfigurationManager.AppSettings["ChamadoServiceEmail"];
      configData.SenhaChamadoServiceEmail = ConfigurationManager.AppSettings["SenhaChamadoServiceEmail"];

      return configData;

    }
        



    }
}
