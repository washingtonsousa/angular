using Core.Data.Models;
using Core.Application.Strategy.Errors;
using System;

namespace Core.Application.Helpers
{
  public class ErrorHelper
    {

        public Error getError(IError errorContext)
        {

            return errorContext.getError();

        }


        public Error getGenericError(int code, String Message)
        {

            Error error = new Error();

            error.code = code;
            error.message = Message;

            return error;

        }

    }
}