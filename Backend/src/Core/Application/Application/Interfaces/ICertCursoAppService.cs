using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ICertCursoAppService
    {


        IList<CertCurso> Get();


        IList<CertCurso> GetSingle();


        CertCurso InsertSingle(CertCurso CertCurso);


        CertCurso UpdateSingle(CertCurso CertCurso);


        void DeleteSingle(int Id);

    }
}
