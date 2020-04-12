using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;

namespace Core.Application
{
    public class CertCursoAppService : AppService, ICertCursoAppService
    {
        private ICertCursoRepository _certCurRepo;
        private IUsuarioAppService _usuarioAppService;

        public CertCursoAppService(IUnityOfWork unitOfWork, IUsuarioAppService usuarioAppService, ICertCursoRepository certCurRepo) : base(unitOfWork)
        {
            _usuarioAppService = usuarioAppService;
            _certCurRepo = certCurRepo;
        }

        public IList<CertCurso> Get()
        {

            IList<CertCurso> certCursos = _certCurRepo.Get();


            return certCursos;
        }


        public IList<CertCurso> GetSingle()
        {

            IList<CertCurso> certCurso = _certCurRepo.GetCertCursosByUsuarioId(_usuarioAppService.GetUsuarioLoggedInId());
            return certCurso;

        }


        public CertCurso InsertSingle(CertCurso CertCurso)
        {

            _certCurRepo.Insert(CertCurso);
            _unityOfWork.Commit();

            return CertCurso;
        }


        public CertCurso UpdateSingle(CertCurso CertCurso)
        {

            CertCurso CertCursoFromDb = _certCurRepo.Find(CertCurso.Id);

            if (CertCursoFromDb.NotExists())
                return null;

            CertCursoFromDb.Certificadora = CertCurso.Certificadora;
            CertCursoFromDb.Descricao = CertCurso.Descricao;
            CertCursoFromDb.Atualizado_em = DateTime.Now;
            CertCursoFromDb.Instituicao = CertCurso.Instituicao;
            CertCursoFromDb.Nome = CertCurso.Nome;
            CertCursoFromDb.Periodo = CertCurso.Periodo;
            _certCurRepo.Update(CertCursoFromDb);
            _unityOfWork.Commit();

            return CertCursoFromDb;



        }


        public void DeleteSingle(int Id)
        {
            CertCurso CertCursoFromDb = _certCurRepo.Find(Id);

            if (CertCursoFromDb.NotExists())
                return;

            _certCurRepo.Delete(CertCursoFromDb);
            _unityOfWork.Commit();

        }
    }
}
