using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IFormAcademicaAppService
    {

        IList<FormAcademica> Get();
        IList<FormAcademica> GetSingle();
        FormAcademica InsertSingle(FormAcademica FormAcademica);

        FormAcademica UpdateSingle(FormAcademica FormAcademica);
        void DeleteSingle(int Id);
        FormAcademica Insert(FormAcademica FormAcademica);
        FormAcademica Update(FormAcademica FormAcademica);

        void Delete(int Id);

    }
}
