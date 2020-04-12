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
    public class EnderecoAppService : AppService, IEnderecoAppService
    {
        private IEnderecoRepository _endRepo;
        private IDepartamentoRepository _depRepo;
        private IUsuarioAppService _usuarioAppService;


        public EnderecoAppService(IUnityOfWork unitOfWork, IEnderecoRepository endRepo, IDepartamentoRepository depRepo, IUsuarioAppService usuarioAppService) : base(unitOfWork)
        {
            _endRepo = endRepo;
            _depRepo = depRepo;
            _usuarioAppService = usuarioAppService;
        }

        public IList<Endereco> Get()
        {

            IList<Endereco> Enderecos = _endRepo.Get();


            return Enderecos;
        }




        public IList<Endereco> GetSingle()
        {

            IList<Endereco> Enderecos = _endRepo.Get().Where(c => c.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId()).ToList();
            return Enderecos;

        }




        public void DeleteSingle(int Id)
        {


            Endereco enderecoFromDb = _endRepo.FindByBothIds(Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (enderecoFromDb.NotExists())
                return;

            _endRepo.Delete(enderecoFromDb);
            _unityOfWork.Commit();

        }




        public Endereco UpdateSingle(Endereco Endereco)
        {



            Endereco enderecoFromDb = _endRepo.Find(Endereco.Id);


            if (enderecoFromDb.NotExists())
                return null;

            if (enderecoFromDb.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId())
            {
                enderecoFromDb.Atualizado_em = DateTime.Now;
                enderecoFromDb.Bairro = Endereco.Bairro;
                enderecoFromDb.CEP = Endereco.CEP;
                enderecoFromDb.Rua = Endereco.Rua;
                enderecoFromDb.Cidade = Endereco.Cidade;
                enderecoFromDb.Complemento = Endereco.Complemento;
                enderecoFromDb.Numero = Endereco.Numero;
                enderecoFromDb.Referencia = Endereco.Referencia;
                _endRepo.Update(enderecoFromDb);
                _unityOfWork.Commit();

            }


            return enderecoFromDb;

        }





        public Endereco InsertSingle(Endereco Endereco)
        {



            Endereco.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();


            _endRepo.Insert(Endereco);
            _unityOfWork.Commit();

            return Endereco;


        } // Fim método






        public Endereco Insert(Endereco endereco)
        {

            _endRepo.Insert(endereco);

            _unityOfWork.Commit();

            return endereco;

        }





        public void Delete(int Id)
        {

            Endereco enderecoFromDb = _endRepo.Find(Id);
            if (enderecoFromDb.NotExists())
                return;

            _endRepo.Delete(enderecoFromDb);
            _unityOfWork.Commit();

        }





        public Endereco Update(Endereco endereco)
        {
            Endereco enderecoFromDb = _endRepo.Find(endereco.Id);

            if (enderecoFromDb.NotExists())
                return null;

                enderecoFromDb.CEP = endereco.CEP;
                enderecoFromDb.Bairro = endereco.Bairro;
                enderecoFromDb.Cidade = endereco.Cidade;
                enderecoFromDb.Complemento = endereco.Complemento;
                enderecoFromDb.Atualizado_em = DateTime.Now;
                enderecoFromDb.Numero = endereco.Numero;
                enderecoFromDb.Referencia = endereco.Referencia;

                _endRepo.Update(enderecoFromDb);

                _unityOfWork.Commit();

                return endereco;
           
        }
    }
}
