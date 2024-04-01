using BCrypt.Net;
using System.Threading.Tasks;
using ThomasGreg.Application.ExceptionsHandler;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public class AuthModel
    {
        private readonly IAuthRepository _authRepository;

        public AuthModel(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Auth> Buscar(string username, string password)
        {
            var login = await _authRepository.Buscar(username);
            Validar(login, username, password);

            return login;
        }

        private void Validar(Auth login, string username, string password)
        {
            if (login == null)
                throw new AuthNaoEncontradoException(username);

            if (!BCrypt.Net.BCrypt.Verify(password, login.PasswordHash))
                throw new AuthSenhaErradaException(username);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
