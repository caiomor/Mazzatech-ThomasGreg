using System;

namespace ThomasGreg.Application.ExceptionsHandler
{
    public class AuthNaoEncontradoException : Exception
    {
        public AuthNaoEncontradoException(string username) : base($"O Username {username} não foi encontrado. ")
        {
        }
    }
}
