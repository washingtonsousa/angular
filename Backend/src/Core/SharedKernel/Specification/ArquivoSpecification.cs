using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel.Specification
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

                              AssertionConcern.AssertTrue(FileName.Split(".".ToCharArray()).Length == 2, "Nome de arquivo inválido")

              );
        }

        public static bool IsFilePathValid(this string FilePath)
        {
            return AssertionConcern.IsSatisfiedBy(

                              AssertionConcern.AssertTrue(!System.IO.File.Exists(FilePath), "Arquivo já existe no sistema")


              );
        }

        public static bool IsExtValid(this string FileExt)
        {
            return AssertionConcern.IsSatisfiedBy(

                              AssertionConcern.AssertTrue((FileExt == "pdf" || FileExt == "doc" || FileExt == "docx"), "Extensão de Arquivo Inválida")

              );
        }
    }
}
