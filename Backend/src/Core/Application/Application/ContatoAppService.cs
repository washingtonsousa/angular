using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
    public class ContatoAppService : AppService, IContatoAppService
    {
        private IContatoRepository _contatoRepo;
        private IUsuarioAppService _usuarioAppService;



        public ContatoAppService(IUnityOfWork unitOfWork, IContatoRepository contatoRepo, IUsuarioAppService usuarioAppService) : base(unitOfWork)
        {
            _contatoRepo = contatoRepo;
            _usuarioAppService = usuarioAppService;
        }

        public IList<Contato> Get()
        {

            IList<Contato> contatos = _contatoRepo.Get();


            return contatos;
        }




        public IList<Contato> GetSingle()
        {

            IList<Contato> contatos = _contatoRepo.Get().Where(c => c.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId()).ToList();



            return contatos;

        }




        public void DeleteSingle(int Id)
        {

            Contato Contato = _contatoRepo.Find(Id);


            if (Contato.NotExists())
                return;

            if (Contato.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId())
            {
                _contatoRepo.Delete(Contato);
                _unityOfWork.Commit();
            }



        } // Fim método




        public Contato UpdateSingle(Contato Contato)
        {


            Contato contatoFromDb = _contatoRepo.Find(Contato.Id);
            if (contatoFromDb.NotExists())
                return null;

            if (contatoFromDb.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId())
            {
                contatoFromDb.Fixo = Contato.Fixo;
                contatoFromDb.Celular = Contato.Celular;
                contatoFromDb.EmailContato = Contato.EmailContato;
                contatoFromDb.Descricao = Contato.Descricao;
                contatoFromDb.Atualizado_em = DateTime.Now;
                _contatoRepo.Update(contatoFromDb);
                _unityOfWork.Commit();


                return contatoFromDb;



            }

            return null;

        } //Fim método




        public Contato InsertSingle(Contato Contato)
        {



            Contato.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();

            _contatoRepo.Insert(Contato);

            _unityOfWork.Commit();

            return Contato;

        }





        public Contato Insert(Contato Contato)
        {

            _contatoRepo.Insert(Contato);
            _unityOfWork.Commit();
            return Contato;

        }





        public void Delete(int id)
        {

            Contato Contato = _contatoRepo.Find(id);
            if (Contato.NotExists())
                return;

            _contatoRepo.Delete(Contato);
            _unityOfWork.Commit();


        }



        public Contato Update(Contato Contato)
        {
            Contato contatoFromDb = _contatoRepo.Find(Contato.Id);
            if (contatoFromDb.NotExists())
                return null;


            contatoFromDb.Fixo = Contato.Fixo;
            contatoFromDb.Celular = Contato.Celular;
            contatoFromDb.EmailContato = Contato.EmailContato;
            contatoFromDb.Descricao = Contato.Descricao;
            contatoFromDb.Atualizado_em = DateTime.Now;
            _contatoRepo.Update(contatoFromDb);
            _unityOfWork.Commit();

            return contatoFromDb;

        } // Fim método

    }
}
