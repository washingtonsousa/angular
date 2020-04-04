using Core.Data.Models;
using System;
using System.IO;
using System.Web.Hosting;

namespace Core.Application.Helpers
{
  public static class ArquivosHelper
    {

        public static string getArquivoFileAbsolutePath(this Arquivo Arquivo)
        {

            return HostingEnvironment.MapPath("~/App_data/Uploads") + "/" + Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "/" + Arquivo.NomeCompleto;
        }


        public static string getArquivoFileAbsolutePathForDownload(this Arquivo Arquivo)
        {

            return HostingEnvironment.MapPath("~/App_data/Uploads") + "\\" + Arquivo.UsuarioId + "\\" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "\\" + Arquivo.NomeCompleto;
        }


        public static string getArquivoDirectoryAbsolutepath(this Arquivo Arquivo)
        {

            return HostingEnvironment.MapPath("~/App_data/Uploads") + "/" +
                   +Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                   + "-" + Arquivo.Data_Referencia.Year.ToString("0000");

        }

        public static string createArquivoDirectoryIfNotExists(this Arquivo arquivo)
        {

            string UserFilesPath = arquivo.getArquivoDirectoryAbsolutepath(); 

            if (!Directory.Exists(UserFilesPath))
            {
                System.IO.Directory.CreateDirectory(UserFilesPath);
            }


            return UserFilesPath;

        }

        public static string getArquivoFileName(this Arquivo Arquivo, string TipoDoc, string ext)
        {

            return TipoDoc + "-" + Arquivo.Data_Referencia.Day.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Year.ToString("0000")
                    + "." + ext;

        }

      
    }
}
