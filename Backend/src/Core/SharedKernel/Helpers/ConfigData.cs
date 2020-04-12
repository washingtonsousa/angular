using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Security;

namespace Core.Data.Models
{
    public class ConfigData
    {


        public static string ClienteId = ConfigurationManager.AppSettings["ClientId"];
        public static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];

        public static string ContextAppUrl { get { return ConfigurationManager.AppSettings["UrlContext"]; } }

        public static string EmailAccount             { get { return ConfigurationManager.AppSettings["EmailAccount"]; } }
        public static string EmailPassword            { get { return  ConfigurationManager.AppSettings["EmailPassword"]; } }
        public static string EmailPort                { get { return      ConfigurationManager.AppSettings["EmailPort"]; } }
        public static string EmailSmtpServer          { get { return ConfigurationManager.AppSettings["EmailSmtpServer"]; } }
        public static string NomePortal               { get { return    ConfigurationManager.AppSettings["NomePortal"]; } }
        public static string URLSiteMandatorio        { get { return ConfigurationManager.AppSettings["URLSiteMandatorio"]; } }
        public static string ChamadoServiceEmail      { get { return    ConfigurationManager.AppSettings["ChamadoServiceEmail"]; } }
        public static string SenhaChamadoServiceEmail { get { return ConfigurationManager.AppSettings["SenhaChamadoServiceEmail"]; } }
        public static string InstallEmailAccount
        {
            get
            {
                return ConfigurationManager.AppSettings["InstallEmailAccount"];
             
              }
        }


        public static string InstallPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["InstallPassword"];

                    } 
        
        }
    }
}
