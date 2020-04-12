using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class FormAcademicaAppService : AppService, IFormAcademicaAppService
    {
        public FormAcademicaAppService(IUnityOfWork unitOfWork, IUsuarioAppService usuarioAppService, IFormAcademicaRepository formAcademicaRepo) : base(unitOfWork)
        {
            _formAcademicaRepo = formAcademicaRepo;
            _usuarioAppService = usuarioAppService;
        }


        private IFormAcademicaRepository _formAcademicaRepo;
        private IUsuarioAppService _usuarioAppService;




        public IList<FormAcademica> Get()
        {

            IList<FormAcademica> FormAcademicas = _formAcademicaRepo.Get();


            return FormAcademicas;
        }




        public IList<FormAcademica> GetSingle()
        {



            IList<FormAcademica> FormAcademicas = _formAcademicaRepo.Get().Where(c => c.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId()).ToList();


            return FormAcademicas;

        }






        public FormAcademica InsertSingle(FormAcademica FormAcademica)
        {

            FormAcademica.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            _formAcademicaRepo.Insert(FormAcademica);
            _unityOfWork.Commit();

            return FormAcademica;
        }




        public FormAcademica UpdateSingle(FormAcademica FormAcademica)
        {

            FormAcademica FormAcademicaFromDb = _formAcademicaRepo.FindByBothIds(FormAcademica.Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (FormAcademicaFromDb.NotExists())
                return null;

            FormAcademicaFromDb.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            FormAcademicaFromDb.Instituicao = FormAcademica.Instituicao;
            FormAcademicaFromDb.Situacao = FormAcademica.Situacao;
            FormAcademicaFromDb.TipoCurso = FormAcademica.TipoCurso;
            FormAcademicaFromDb.Curso = FormAcademica.Curso;
            FormAcademica.Atualizado_em = DateTime.Now;
            _formAcademicaRepo.Update(FormAcademicaFromDb);
            _unityOfWork.Commit();

            return FormAcademica;






        }





        public void DeleteSingle(int Id)
        {


            FormAcademica FormAcademicaFromDb = _formAcademicaRepo.FindByBothIds(Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (FormAcademicaFromDb.NotExists())
                return;

            _formAcademicaRepo.Delete(FormAcademicaFromDb);
            _unityOfWork.Commit();







        }




        public FormAcademica Insert(FormAcademica FormAcademica)
        {

            _formAcademicaRepo.Insert(FormAcademica);
            _unityOfWork.Commit();

            return FormAcademica;
        }





        public FormAcademica Update(FormAcademica FormAcademica)
        {

            FormAcademica FormAcademicaFromDb = _formAcademicaRepo.FindByBothIds(FormAcademica.Id, FormAcademica.UsuarioId);

            if (FormAcademicaFromDb.NotExists())
                return null;


            FormAcademicaFromDb.Curso = FormAcademica.Curso;
            FormAcademicaFromDb.Instituicao = FormAcademica.Instituicao;
            FormAcademicaFromDb.Situacao = FormAcademica.Situacao;
            FormAcademicaFromDb.TipoCurso = FormAcademica.TipoCurso;

            _formAcademicaRepo.Update(FormAcademicaFromDb);
            _unityOfWork.Commit();

            return FormAcademica;





        }





        public void Delete(int Id)
        {

            FormAcademica FormAcademicaFromDb = _formAcademicaRepo.Find(Id);

            if (FormAcademicaFromDb.NotExists())
                return;

            _formAcademicaRepo.Delete(FormAcademicaFromDb);
            _unityOfWork.Commit();




        } // Fim método


    }
}
