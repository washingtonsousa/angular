using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public abstract class Error
    {

        public int Code { get; protected set; }

        public string Message { get; protected set; }

        public string DetailedMessage { get; protected set; }

        public abstract Error GetError();


    }
}