using Core.Data.Models;
using System;

namespace Core.Application.Factories
{
  public class Log_ActionFactory
    {



        public static Log_Action Generate_ArquivoLog_Action(string HostAddress, Usuario usuario, Arquivo arquivo, string Route)
        {

            return new Log_Action
            {

                Host_Address = HostAddress,
                Matricula_Usuario = usuario.Matricula,
                Data_Acesso = DateTime.Now,
                Action_Type = "Ação de Arquivo",
                Usuario = usuario.Nome,
                Action_Details = " Arquivo afetado:  " + arquivo.Nome + " ",
                Action_Dest = Route

            };

        }

        public static Log_Action Generate_AccessListArquivoLog_Action(string HostAddress, Usuario usuario, string Route)
        {

            return new Log_Action
            {

                Host_Address = HostAddress,
                Matricula_Usuario = usuario.Matricula,
                Data_Acesso = DateTime.Now,
                Action_Type = "Listagem de arquivos",
                Usuario = usuario.Nome,
                Action_Details = " Acessou lista de arquivos no sistema (Checar rota para mais detalhes)",
                Action_Dest = Route

            };

        }




    }
}




