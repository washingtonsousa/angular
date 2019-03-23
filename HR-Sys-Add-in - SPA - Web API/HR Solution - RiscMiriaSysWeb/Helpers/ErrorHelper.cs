using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using System;

namespace RiscServicesHRSharepointAddIn.Helpers
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