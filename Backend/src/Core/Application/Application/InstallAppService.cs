using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;

namespace Core.Application
{
    public class InstallAppService : AppService, IInstallAppService
    {

        private IUsuarioRepository _usuarioRepo;
        private ICargoRepository _cargoRepo;
        private IStatusRepository _statusRepo;
        private IDepartamentoRepository _depRepo;
        private IAreaRepository _areaRepo;
        private INivelAcessoRepository _nivelAcessoRepo;


        public InstallAppService(IUnityOfWork unitOfWork, IUsuarioRepository usuarioRepo, ICargoRepository cargoRepo, IStatusRepository statusRepo, INivelAcessoRepository nivelAcessoRepo, IDepartamentoRepository depRepo, IAreaRepository areaRepo) : base(unitOfWork)
        {
            _usuarioRepo = usuarioRepo;
            _cargoRepo = cargoRepo;
            _statusRepo = statusRepo;
            _nivelAcessoRepo = nivelAcessoRepo;
            _depRepo = depRepo;
            _areaRepo = areaRepo;
        }


        /// <summary>
        /// Execute Primary installation with de default User and system values
        /// </summary>
        public void Execute()
        {

                Cargo cargoDefault = new Cargo()
                {

                    Nome = "Default",
                    Departamento = new Departamento()
                    {

                        Nome = "Default",

                        Area = new Area()
                        {
                            Nome = "Default"
                        }

                    }
                };

                Usuario usuarioPadraoMaster = new Usuario
                {
                    Nome = "Administrador",
                    Email = "Administrador@localhost",
                    NivelAcesso = new NivelAcesso()
                    {

                        Nivel = "Administrador"

                    },
                    Password = "Admin123",
                    Cargo = cargoDefault,
                    Status = new Status()
                    {
                        Nome = "ativo",
                        Codigo = 1
                    },
                    DataNasc = DateTime.Now,
                    DataAdmissao = DateTime.Now,
                    Matricula = 0.ToString(),
                    EstadoCivil = "Solteiro",
                    Ramal = 0,
                    Sexo = "Masculino"
                };


                //Status padrões
                _statusRepo.Insert(new Status()
                {
                    Nome = "desativado",
                    Codigo = 0
                });


                _nivelAcessoRepo.Insert(new NivelAcesso()
                {
                    Nivel = "Funcionario"

                });



                _usuarioRepo.Insert(usuarioPadraoMaster);

                _unityOfWork.Commit();


            }


            //// Deprecated code for reference
            /*
             * 
             * 
             *    ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();
                    SPPeopleManagerHelper _spPeopleManager = new SPPeopleManagerHelper(clientContext);
                    PersonProperties _personProperties = _spPeopleManager.getPersonPropertiesByEmail(ConfigurationManager.AppSettings["InstallEmailAccount"]);



                    if (_spPeopleManager.execQuery() == false)
                    {
                        return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper()
                          .getError(new SPUserNotFoundError()));
                    }

                    Usuario novoUsuario = usuarioFactory.UsuarioInstallObjFactory(_personProperties.DisplayName,
                    _personProperties.Email, _cargoRepo, _nivelAcessoRepo, _statusRepo);
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */



        }
    }
