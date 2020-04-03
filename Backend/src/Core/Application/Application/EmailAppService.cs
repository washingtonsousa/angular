using Core.Application.Helpers;
using Core.Data.Models;
using System;
using System.Net.Mail;


namespace Core.Application
{
  public class EmailAppService
    {

        private SmtpClient Client;
        private MailMessage mailMessage;

        public EmailAppService(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
            this.mailMessage.From = new MailAddress(ConfigData.EmailAccount);
            this.mailMessage.IsBodyHtml = true;
            initializeComponents();
        }

       
            private void initializeComponents()
            {
              Client = new SmtpClient();
              Client.UseDefaultCredentials = false;
              Client.Credentials = new  System.Net.NetworkCredential(ConfigData.EmailAccount, ConfigData.EmailPassword);
              Client.EnableSsl = true;
              Client.Port = int.Parse(ConfigData.EmailPort);
              Client.DeliveryMethod = SmtpDeliveryMethod.Network;
              Client.Host = ConfigData.EmailSmtpServer;
              Client.Timeout = 600000;

            }

    

        public void AddDestinyAddressFromUsuario(Usuario usuario)
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


        public void AddDestinyAddress(string email)
        {

            this.mailMessage.To.Add(email);

        }


        public object SendMessage()
        {
            try
            {
                Client.Send(this.mailMessage);
                Client.Dispose();

               return new JsonResultObjHelper().getArquivoJsonResultSuccessObj();

            } catch(Exception e)

            {
              return new JsonResultObjHelper().getArquivoJsonResultSuccessObjEmailNotSentByError(e.Message);
            }

            
        }


    }
}
