using RiscServicesHRSharepointAddIn.Handlers;
using RiscServicesHRSharepointAddIn.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml.Linq;

namespace RiscServicesHRSharepointAddIn.Factories
{
  public class MailMessageFactory
    {

    public XMLTplViewHandler tplHandler;


    /// <summary>
    /// Renderiza do template de email para arquivos enviados e cria um objeto MailMessage
    /// utilizando o objeto XDocument retornado pela renderização do template
    /// Para alterar este template acesse o arquivo ArquivoEnviadoMailTemplate.xml na pasta Templates
    /// </summary>
    /// <param name="usuario">Usuario da base de dados que recebeu o arquivo</param>
    /// <param name="arquivo"> Model do Arquivo enviado para o usuário</param>
    /// <param name="url">Url do sistema de destino do arquivo</param>
    /// <returns>MailMessage</returns>
    public MailMessage arquivoEnviadoTemplateToMailMessage(Usuario usuario, Arquivo arquivo, string url)
        {

      tplHandler = new XMLTplViewHandler(HostingEnvironment.MapPath("~/Templates") + @"\ArquivoEnviadoMailTemplate.xml",

                new {

                  Data_Doc = arquivo.Data_Referencia.Day.ToString("00") +
                        "/" + arquivo.Data_Referencia.Month.ToString("00") +
                        "/" + arquivo.Data_Referencia.Year.ToString("00"),
                  Arquivo_Nome = arquivo.Nome,
                  System_Url = url,
                  Nome_Usuario = usuario.Nome

                });

              XDocument templateParts = tplHandler.CompileXMLLinq();

              MailMessage mailMessage = new MailMessage() {

                Subject = templateParts.Root.Element("subject").Value,

                Body = templateParts.Root.Element("body").Value,

              };

            return mailMessage;

        }



    }
}
