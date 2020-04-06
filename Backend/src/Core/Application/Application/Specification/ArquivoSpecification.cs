using Core.Application.Entities;
using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class ArquivoSpecification
    {

        public static bool ValidForDownload(this Arquivo arquivo)
        {
            return AssertionConcern.IsSatisfiedBy(
                
                          
                
                
                );
        }


        public static bool IsFileFromRequestValid(this ArquivoFromRequest arquivo)
        {
            return AssertionConcern.IsSatisfiedBy(

                              AssertionConcern.AssertTrue(arquivo.FileName.Split(".".ToCharArray()).Length == 2, "Nome de arquivo inválido"),
                              AssertionConcern.AssertTrue(!System.IO.File.Exists(arquivo.FilePath), "Arquivo já existe no sistema"),
                               AssertionConcern.AssertTrue((arquivo.FileExtension == "pdf" || arquivo.FileExtension == "doc" || arquivo.FileExtension == "docx"), "Extensão de Arquivo Inválida")

              );
        }

    }
}
