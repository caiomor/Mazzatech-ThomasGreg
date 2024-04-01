using System;

namespace ThomasGreg.Application.ExceptionsHandler
{
    public class LogradouroNaoEncontradoException : Exception
    {
        public LogradouroNaoEncontradoException() : base("Logradouro não encontrado.")
        {
        }
    }
}
