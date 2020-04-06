using Core.Application.Abstractions;
using Core.Application.Handlers;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml.Linq;

namespace Core.Application
{
    public class EmailAppService: AppService, IEmailAppService
    {

        public EmailAppService(IUnityOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void SendFileUploadedNotificationEmail(Arquivo arquivo, Usuario usuario)
        {

            var sender = new SystemMailNotifySender();
            var tplHandler = new XMLTplViewHandler(@"\ArquivoEnviadoMailTemplate.xml",

               new
               {

                   Data_Doc = arquivo.Data_Referencia.Day.ToString("00") +
                       "/" + arquivo.Data_Referencia.Month.ToString("00") +
                       "/" + arquivo.Data_Referencia.Year.ToString("00"),
                   Arquivo_Nome = arquivo.Nome,
                   System_Url = ConfigData.ContextAppUrl,
                   Nome_Usuario = usuario.Nome

               });

            XDocument templateParts = tplHandler.CompileXMLLinq();
            MailMessage mailMessage = new MailMessage()
            {
                Subject = templateParts.Root.Element("subject").Value,
                Body = templateParts.Root.Element("body").Value,
            };

            sender.AddMailMessage(mailMessage);
            sender.AddDestinyAddressFromUsuario(usuario);
            sender.SendMessage();
        }

    }
}
