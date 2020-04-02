namespace Core.Application.Helpers
{
  public class JsonResultObjHelper
    {

        public object getArquivoJsonResultSuccessObj()
        {

            return new
            {
                message = "Operação realizada com sucesso",

                code = 0

            };


        }


    public object getArquivoJsonResultSuccessObjEmailNotSent()
    {

      return new
      {
        message = "Operação realizada com sucesso, porém a notificação não foi enviada por ausência ou erro de configuração",

        code = 0

      };


    }

    public object getArquivoJsonResultSuccessObjEmailNotSentByError(string ErrorMessage)
    {

      return new
      {
        message = "Operação realizada com sucesso, porém a notificação foi enviada, contate o administrador, detalhes do erro: " + ErrorMessage,

        code = 0

      };


    }


  }
}
