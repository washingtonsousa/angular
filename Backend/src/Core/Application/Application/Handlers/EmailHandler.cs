using Core.Application.Helpers;
using Core.Data.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Core.Application.Handlers
{
  public class EmailHandler
    {
        private ConfigData configData;
        private SmtpClient client;
        private MailMessage mailMessage;

        public EmailHandler(ConfigData configData, MailMessage mailMessage)
        {
            this.configData = configData;
            this.mailMessage = mailMessage;
            this.mailMessage.From = new MailAddress(this.configData.EmailAccount);
            this.mailMessage.IsBodyHtml = true;
            initializeComponents();
        }

       
            private void initializeComponents()
            {
              client = new SmtpClient();
              client.UseDefaultCredentials = false;
              client.Credentials = new  System.Net.NetworkCredential(configData.EmailAccount, configData.EmailPassword);
              client.EnableSsl = true;
              client.Port = int.Parse(configData.EmailPort);
              client.DeliveryMethod = SmtpDeliveryMethod.Network;
              client.Host = configData.EmailSmtpServer;
              client.Timeout = 600000;

            }

    

        public void addDestinyAddressFromUsuario(Usuario usuario)
        {
            if(usuario.Email_Secundario_Notificacao == null || usuario.Email_Secundario_Notificacao == "")
            {
                mailMessage.To.Add(usuario.Email);
            }

            else
            {

        mailMessage.To.Add(usuario.Email);
        mailMessage.To.Add(usuario.Email_Secundario_Notificacao);
            }

            
        }


        public void addDestinyAddress(string email)
        {

            this.mailMessage.To.Add(email);

        }


        public object SendMessage()
        {
            try
            {
                client.Send(this.mailMessage);
                client.Dispose();

               return new JsonResultObjHelper().getArquivoJsonResultSuccessObj();

            } catch(Exception e)

            {
              return new JsonResultObjHelper().getArquivoJsonResultSuccessObjEmailNotSentByError(e.Message);
            }

            
        }


    }
}
