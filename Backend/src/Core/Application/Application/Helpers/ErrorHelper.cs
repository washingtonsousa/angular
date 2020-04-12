using Core.Data.Models;
using Core.Application.Strategy.Errors;
using System;

namespace Core.Application.Helpers
{
  public class ErrorHelper
    {

        public Data.Models.Error getError(Strategy.Errors.Error errorContext)
        {

            return errorContext.GetError();

        }


        public Data.Models.Error getGenericError(int Code, string Message)
        {

            Data.Models.Error error = new Data.Models.Error();

            Code = Code;
            Message = Message;

            return this;

        }

    }
}