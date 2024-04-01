using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application.ExceptionsHandler
{
    public class AuthSenhaErradaException : Exception
    {
        public AuthSenhaErradaException(string username) : base($"A Senha do {username} está errada.") { }
    }
}
