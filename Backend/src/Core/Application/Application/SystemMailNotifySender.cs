using Core.Data.Models;
using System;
using System.Net.Mail;

namespace Core.Application
{
  public class SystemMailNotifySender
  {

        private SmtpClient Client;
        private MailMessage MailMessage;

        public SystemMailNotifySender()
        {
           
            initializeComponents();
        }

        public void AddMailMessage(MailMessage Message)
        {
            this.MailMessage = Message;
            this.MailMessage.From = new MailAddress(ConfigData.EmailAccount);
            this.MailMessage.IsBodyHtml = true;
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
                MailMessage.To.Add(usuario.Email);
            }

            else
            {

        MailMessage.To.Add(usuario.Email);
        MailMessage.To.Add(usuario.Email_Secundario_Notificacao);
            }

            
        }


        public void AddDestinyAddress(string email)
        {

            this.MailMessage.To.Add(email);

        }


        public void SendMessage()
        {
            try
            {
                Client.Send(this.MailMessage);
                Client.Dispose();

            } catch(Exception e)

            {
            }

        }
    }
}
