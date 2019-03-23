using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Filters;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;

namespace RiscServicesHRSharepointAddIn.Controllers
{

 
    public class UsuarioConhecimentoController : BasicApiAppController
    {

        private UsuariosRepository usrRepo;
        private JsonResultObjHelper jsonResultObjHelper;
        private ConhecimentoRepository conhecimentoRepo;
        private UsuarioConhecimentoRepository usrConhecimentoRepo;


        public UsuarioConhecimentoController()
        {
            
            usrRepo = new UsuariosRepository();  
            conhecimentoRepo = new ConhecimentoRepository();
            usrConhecimentoRepo = new UsuarioConhecimentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();

        }
  

        /* 
         * @UpdateAction
         * @Método insere ou deleta entradas na entidade UsuarioConhecimento com base no parametro recebido
         * @Param IList<int> ConhecimentoIds = List de Ids de conhecimentos para serem deletados ou inseridos 
         * na entidade associada UsuarioConhecimento relacionada a 'Usuario ManyToMany Conhecimento'
         * */

        [Authorize(Roles="Administrador, Funcionario")]
        [HttpOptions]
        [HttpPost]
        public HttpResponseMessage PostSingle([FromBody]ConhecimentoIdsJsonObj ConhecimentoIds)
        {
      this.SetCurrentLoggedUserHandler();
      ConhecimentoIds.UsuarioId = this.Usuario_Id;
      IList<Conhecimento> Conhecimentos = conhecimentoRepo.GetConhecimentos(); // Todos os conhecimentos cadastrados no sistema
            IList<UsuarioConhecimento> UsuarioConhecimentos = usrConhecimentoRepo.GetUsuarioConhecimentos()
            .Where(uc => uc.UsuarioId == ConhecimentoIds.UsuarioId).ToList(); // Entidade Associativa 'Usuario ManyToMany Conhecimento'

          

            if (ConhecimentoIds.ConhecimentoIds != null)   // Se lista não for nula
            {

                // Varre todos os conhecimentos cadastrados para comparar com os da lista

                foreach (var conhecimento in Conhecimentos) { 

                    // Se não existir na lista recebida (Usuário deixou desmarcado)

                    if (ConhecimentoIds.ConhecimentoIds.Contains(conhecimento.Id) == false)
                    {
                       UsuarioConhecimento usuarioConhecimento = UsuarioConhecimentos
                      .Where(uc => uc.ConhecimentoId == conhecimento.Id && uc.UsuarioId == ConhecimentoIds.UsuarioId)
                      .FirstOrDefault();

                        // Se for encontrado valor para ser deletado

                        if (usuarioConhecimento != null)
                        {
                            
                            usrConhecimentoRepo.DeleteUsuarioConhecimento(usuarioConhecimento);
                            usrConhecimentoRepo.Save();

                        }
                        

                    } // @Senao - Se encontra valor na lista comparando com todos os conhecimentos disponíveis
                    else
                    {
                        // Se não for encontrado valor para ser inserido

                        if (usrConhecimentoRepo.GetUsuarioConhecimentos()
                       .Where(uc => uc.UsuarioId == ConhecimentoIds.UsuarioId && uc.ConhecimentoId == conhecimento.Id)
                       .FirstOrDefault() == null)
                        {

                            // Insere e já salva, pois evita falha durante taferas no banco de dados

                            UsuarioConhecimento usuarioConhecimento = new UsuarioConhecimento();
                            usuarioConhecimento.ConhecimentoId = conhecimento.Id;
                            usuarioConhecimento.UsuarioId = ConhecimentoIds.UsuarioId;
                            usrConhecimentoRepo.InsertUsuarioConhecimento(usuarioConhecimento);
                            usrConhecimentoRepo.Save();

                        }

                    }
            }

            } // Se lista retorna nula - Usuário deixou todas as checkboxes desmarcadas na View
            else
            {


              // Se existe algo para deletar

                if (UsuarioConhecimentos.FirstOrDefault() != null)
                {

                    foreach(var usuarioConhecimento in UsuarioConhecimentos)
                    {
                       //Deleta e salva a deleção

                        usrConhecimentoRepo.DeleteUsuarioConhecimento(usuarioConhecimento);
                        usrConhecimentoRepo.Save();

                    }
                   

                }


            }


             return Request.CreateResponse(System.Net.HttpStatusCode.OK, this.jsonResultObjHelper.getArquivoJsonResultSuccessObj());

        } // Método @UpdateAction



    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]ConhecimentoIdsJsonObj ConhecimentoIds)
    {
    
      IList<Conhecimento> Conhecimentos = conhecimentoRepo.GetConhecimentos(); // Todos os conhecimentos cadastrados no sistema
      IList<UsuarioConhecimento> UsuarioConhecimentos = usrConhecimentoRepo.GetUsuarioConhecimentos()
      .Where(uc => uc.UsuarioId == ConhecimentoIds.UsuarioId).ToList(); // Entidade Associativa 'Usuario ManyToMany Conhecimento'



      if (ConhecimentoIds.ConhecimentoIds != null)   // Se lista não for nula
      {

        // Varre todos os conhecimentos cadastrados para comparar com os da lista

        foreach (var conhecimento in Conhecimentos)
        {

          // Se não existir na lista recebida (Usuário deixou desmarcado)

          if (ConhecimentoIds.ConhecimentoIds.Contains(conhecimento.Id) == false)
          {
            UsuarioConhecimento usuarioConhecimento = UsuarioConhecimentos
           .Where(uc => uc.ConhecimentoId == conhecimento.Id && uc.UsuarioId == ConhecimentoIds.UsuarioId)
           .FirstOrDefault();

            // Se for encontrado valor para ser deletado

            if (usuarioConhecimento != null)
            {

              usrConhecimentoRepo.DeleteUsuarioConhecimento(usuarioConhecimento);
              usrConhecimentoRepo.Save();

            }


          } // @Senao - Se encontra valor na lista comparando com todos os conhecimentos disponíveis
          else
          {
            // Se não for encontrado valor para ser inserido

            if (usrConhecimentoRepo.GetUsuarioConhecimentos()
           .Where(uc => uc.UsuarioId == ConhecimentoIds.UsuarioId && uc.ConhecimentoId == conhecimento.Id)
           .FirstOrDefault() == null)
            {

              // Insere e já salva, pois evita falha durante taferas no banco de dados

              UsuarioConhecimento usuarioConhecimento = new UsuarioConhecimento();
              usuarioConhecimento.ConhecimentoId = conhecimento.Id;
              usuarioConhecimento.UsuarioId = ConhecimentoIds.UsuarioId;
              usrConhecimentoRepo.InsertUsuarioConhecimento(usuarioConhecimento);
              usrConhecimentoRepo.Save();

            }

          }
        }

      } // Se lista retorna nula - Usuário deixou todas as checkboxes desmarcadas na View
      else
      {


        // Se existe algo para deletar

        if (UsuarioConhecimentos.FirstOrDefault() != null)
        {

          foreach (var usuarioConhecimento in UsuarioConhecimentos)
          {
            //Deleta e salva a deleção

            usrConhecimentoRepo.DeleteUsuarioConhecimento(usuarioConhecimento);
            usrConhecimentoRepo.Save();

          }


        }


      }


      return Request.CreateResponse(System.Net.HttpStatusCode.OK, this.jsonResultObjHelper.getArquivoJsonResultSuccessObj());

    } // Método @UpdateAction

  } // classe

} // namespace
