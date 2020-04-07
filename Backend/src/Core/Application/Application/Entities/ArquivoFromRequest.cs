using Core.Application.Helpers;
using Core.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Entities
{
    public class ArquivoFromRequest
    {
        public ArquivoFromRequest(MultipartFileData fileData, Arquivo arquivo)
        {
            FileData = fileData;
            Arquivo = arquivo;
        }

        public string UserDirectory
        {
            get
            {

                return Arquivo.createArquivoDirectoryIfNotExists();

            }
        }

        public string FileExtension { get {

                return FileName.Split(".".ToCharArray()).LastOrDefault();


            } }
        public string FilePath { get {


                return Path.Combine(UserDirectory, NewFileName);


            } }

        public string FileName { get {

                return JsonConvert.DeserializeObject<string>(FileData.Headers.ContentDisposition.FileName);


            } }


        public string NewFileName
        {
            get
            {


                return $@"{FileName.Split(".".ToCharArray()).FirstOrDefault()}-{Arquivo.Data_Referencia.Day.ToString("00")}-{Arquivo.Data_Referencia.Month.ToString("00")}-{Arquivo.Data_Referencia.Year}.{FileExtension}";



            }
        }


        public MultipartFileData FileData { get; set; }

        public Arquivo Arquivo { get;  private set; }
  

        public bool Valid { get; private set; }


        public void SaveToDirectory()
        {
            try
            {

                File.Move(FileData.LocalFileName, FilePath);
                
                Arquivo.Tipo = FileExtension;
                Arquivo.URL = FilePath;
                Arquivo.NomeCompleto = NewFileName;
                Arquivo.Nome = NewFileName.Split(".".ToCharArray()).FirstOrDefault();
                Arquivo.Ext = FileExtension;
                
                Valid = true;

            } catch
            {
                Valid = false;

            }
        }

        
    }
}
