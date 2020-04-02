using Core.Data.Models;
using System;
using System.IO;

namespace Core.Application.Helpers
{
  public static class ArquivosHelper
    {

        public static string getArquivoFileAbsolutePath(this Arquivo Arquivo, String UploadPath)
        {

            return UploadPath + "/" + Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "/" + Arquivo.NomeCompleto;
        }


        public static string getArquivoFileAbsolutePathForDownload(this Arquivo Arquivo, String UploadPath)
        {

            return UploadPath + "\\" + Arquivo.UsuarioId + "\\" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "\\" + Arquivo.NomeCompleto;
        }


        public static string getArquivoDirectoryAbsolutepath(this Arquivo Arquivo, String UploadPath)
        {

            return UploadPath + "/" +
                   +Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                   + "-" + Arquivo.Data_Referencia.Year.ToString("0000");

        }

        public static string createArquivoDirectoryIfNotExists(this Arquivo arquivo, String UploadPath)
        {

            string UserFilesPath = arquivo.getArquivoDirectoryAbsolutepath(UploadPath); 

            if (!Directory.Exists(UserFilesPath))
            {
                System.IO.Directory.CreateDirectory(UserFilesPath);
            }


            return UserFilesPath;

        }

        public static String getArquivoFileName(this Arquivo Arquivo, String TipoDoc, String ext)
        {

            return TipoDoc + "-" + Arquivo.Data_Referencia.Day.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Year.ToString("0000")
                    + "." + ext;

        }

      
    }
}
