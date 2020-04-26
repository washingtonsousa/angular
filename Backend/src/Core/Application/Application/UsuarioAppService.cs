using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Core.Application
{
    public class UsuarioAppService : AppServiceWithHub<UsuariosHub>, IUsuarioAppService
    {
        private IUsuarioRepository _usuarioRepo;
        private ISharepointPeopleManagerAppService _sharepointPeopleManagerAppService;
        private IConhecimentoAppService _conhecimentoAppService;
        private IUsuarioConhecimentoRepository _usrConhecimentoRepo;

        public UsuarioAppService(IUsuarioRepository usuarioRepo, IUnityOfWork unityOfWork, ISharepointPeopleManagerAppService sharepointPeopleManagerAppService, IConhecimentoAppService conhecimentoAppService, IUsuarioConhecimentoRepository usrConhecimentoRepo) : base(unityOfWork)
        {
            _usuarioRepo = usuarioRepo;
            _sharepointPeopleManagerAppService = sharepointPeopleManagerAppService;
            _conhecimentoAppService = conhecimentoAppService;
            _usrConhecimentoRepo = usrConhecimentoRepo;
        }

        public Usuario GetUsuarioLoggedIn()
        {

            var usuario = GetUsuarioById(GetUsuarioLoggedInId());
            return usuario;

        }

        public Usuario Update(Usuario usuario)
        {
            Usuario usuarioFromDb = _usuarioRepo.FindByMatriculaOrEmail(usuario.Matricula, usuario.Email);

            if (usuarioFromDb.NotExists())
                return null;

            usuarioFromDb.CargoId = usuario.CargoId;
            usuarioFromDb.NivelAcessoId = usuario.NivelAcessoId;
            usuarioFromDb.Nome = usuario.Nome;
            usuarioFromDb.StatusId = usuario.StatusId;
            usuarioFromDb.Email = usuario.Email;
            usuarioFromDb.Matricula = usuario.Matricula;
            usuarioFromDb.DataAdmissao = usuario.DataAdmissao;
            usuarioFromDb.DataNasc = usuario.DataNasc;
            usuarioFromDb.EstadoCivil = usuario.EstadoCivil;
            usuarioFromDb.Ramal = usuario.Ramal;
            usuarioFromDb.Sexo = usuario.Sexo;

            bool result = _unityOfWork.Commit();

            if (result)
            {
                UsuariosHub.updateUsuario(usuarioFromDb);
                //usuarioFromDb.Status.Usuarios = null;
                //usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;
            }

            return usuarioFromDb;

        }

        public Usuario PartialyUpdate(Usuario usuario)
        {
            Usuario usuarioFromDb = GetUsuarioById(usuario.Id);

            if (usuarioFromDb.NotExists())
                return null;


            usuarioFromDb.Email_Secundario_Notificacao = usuario.Email_Secundario_Notificacao;
            _unityOfWork.Commit();

            return usuario;

        }

        public void Delete(int id)
        {
            Usuario usuario = _usuarioRepo.Find(id);

            if (usuario.NotExists())
                return;

            _usuarioRepo.Delete(usuario);
            bool result = _unityOfWork.Commit();

            if (result)
                UsuariosHub.deleteUsuario(usuario);
        }

        public Usuario GetByMatricula(string matricula)
        {

            Usuario usuario = _usuarioRepo.FindUsuarioByMatricula(matricula);

            ///Validação sem if apenas para gerar notificação se necessário
            usuario.NotExists();

            return usuario;

        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            Usuario usuarioFromDb = _usuarioRepo.FindByMatriculaOrEmail(usuario.Matricula, usuario.Email);

            if (usuarioFromDb.Exists())
                return null;

            //Funções de Sharepoint comentadas temporariamente
            //_sharepointPeopleManagerAppService.GetPersonPropertiesByEmail(usuario.Email);
            //bool result = _sharepointPeopleManagerAppService.ExecuteRequest();

            //if (result)
            //{

            _usuarioRepo.Insert(usuario);
            bool result  = _unityOfWork.Commit();

            if (result)
            {
                usuarioFromDb = _usuarioRepo.FindUsuarioByEmail(usuario.Email);
                usuarioFromDb.Status.Usuarios = null;
                usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;
            }
            UsuariosHub.newUsuario(usuarioFromDb);

            return usuarioFromDb;
            //}

        }

        public IList<Usuario> Get()
        {
            return _usuarioRepo.Get();
        }

        public Usuario GetUsuarioById(int Id) => _usuarioRepo.Find(Id);

        public int GetUsuarioLoggedInId()
        {
            OwinContext context = (OwinContext)HttpContext.Current.GetOwinContext();
            ClaimsPrincipal user = context.Authentication.User;

            if (user.Identity.IsAuthenticated)
            {

             string claimIdStr = user.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;
             int.TryParse(claimIdStr, out int result);
             return result;
            }
            return 0;
        }

        public void AddConhecimentosForUsuarioLoggedIn(IList<int> ConhecimentoIds) => AddConhecimentosForUsuario(ConhecimentoIds, GetUsuarioLoggedInId());

        public void AddConhecimentosForUsuarioByUsuarioId(IList<int> ConhecimentoIds, int UsuarioId) => AddConhecimentosForUsuario(ConhecimentoIds, UsuarioId);


        private void AddConhecimentosForUsuario(IList<int> ConhecimentoIds, int UsuarioId)
        {
            IList<Conhecimento> Conhecimentos = _conhecimentoAppService.Get(); // Todos os conhecimentos cadastrados no sistema
            IList<UsuarioConhecimento> UsuarioConhecimentos = _usrConhecimentoRepo.Get()
            .Where(uc => uc.UsuarioId == UsuarioId).ToList(); // Entidade Associativa 'Usuario ManyToMany Conhecimento'

            if (GetUsuarioById(UsuarioId).NotExists())
                return;
            
            if (ConhecimentoIds != null)   // Se lista não for nula
            {

                // Varre todos os conhecimentos cadastrados para comparar com os da lista

                foreach (var conhecimento in Conhecimentos)
                {

                    // Se não existir na lista recebida (Usuário deixou desmarcado)

                    if (ConhecimentoIds.Contains(conhecimento.Id) == false)
                    {
                        UsuarioConhecimento usuarioConhecimento = UsuarioConhecimentos
                       .Where(uc => uc.ConhecimentoId == conhecimento.Id && uc.UsuarioId == GetUsuarioLoggedInId())
                       .FirstOrDefault();

                        // Se for encontrado valor para ser deletado

                        if (usuarioConhecimento != null)
                            _usrConhecimentoRepo.Delete(usuarioConhecimento);
                        


                    } // @Senao - Se encontra valor na lista comparando com todos os conhecimentos disponíveis
                    else
                    {
                        // Se não for encontrado valor para ser inserido

                        if (_usrConhecimentoRepo.Get()
                       .Where(uc => uc.UsuarioId == UsuarioId && uc.ConhecimentoId == conhecimento.Id)
                       .FirstOrDefault() == null)
                        {

                            // Insere e já salva, pois evita falha durante taferas no banco de dados

                            UsuarioConhecimento usuarioConhecimento = new UsuarioConhecimento();
                            usuarioConhecimento.ConhecimentoId = conhecimento.Id;
                            usuarioConhecimento.UsuarioId = UsuarioId;
                            _usrConhecimentoRepo.Insert(usuarioConhecimento);

                        }

                    }
                }

            } // Se lista retorna nula - Usuário deixou todas as checkboxes desmarcadas na View
            else
            {


                // Se existe algo para deletar

                if (UsuarioConhecimentos.FirstOrDefault() != null)
                    foreach (var usuarioConhecimento in UsuarioConhecimentos)
                    {
                        //Deleta e salva a deleção

                        _usrConhecimentoRepo.Delete(usuarioConhecimento);

                    }

                
            }

            _unityOfWork.Commit();
          

        } // Método @UpdateAction

    }
}
