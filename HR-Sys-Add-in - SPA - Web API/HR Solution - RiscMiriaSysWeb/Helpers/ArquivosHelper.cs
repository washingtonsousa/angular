using RiscServicesHRSharepointAddIn.Models;
using System;
using System.IO;

namespace RiscServicesHRSharepointAddIn.Helpers
{
  public class ArquivosHelper
    {

        public String getArquivoFileAbsolutePath(String UploadPath, Arquivo Arquivo)
        {

            return UploadPath + "/" + Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "/" + Arquivo.NomeCompleto;
        }


        public String getArquivoFileAbsolutePathForDownload(String UploadPath, Arquivo Arquivo)
        {

            return UploadPath + "\\" + Arquivo.UsuarioId + "\\" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00") + "-" + Arquivo.Data_Referencia.Year.ToString("0000") + "\\" + Arquivo.NomeCompleto;
        }


        public String getArquivoDirectoryAbsolutepath(String UploadPath, Arquivo Arquivo)
        {

            return UploadPath + "/" +
                   +Arquivo.UsuarioId + "/" + Arquivo.Data_Referencia.Day.ToString("00") + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                   + "-" + Arquivo.Data_Referencia.Year.ToString("0000");

        }

        public String createArquivoDirectoryIfNotExists(String UploadPath, Arquivo arquivo)
        {

            string UserFilesPath = getArquivoDirectoryAbsolutepath(UploadPath, arquivo);

            if (!Directory.Exists(UserFilesPath))
            {
                System.IO.Directory.CreateDirectory(UserFilesPath);
            }


            return UserFilesPath;

        }

        public String getArquivoFileName(String TipoDoc, Arquivo Arquivo, String ext)
        {

            return TipoDoc + "-" + Arquivo.Data_Referencia.Day.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Year.ToString("0000")
                    + "." + ext;

        }

      
    }
}
