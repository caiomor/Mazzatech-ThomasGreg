using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Application.ExceptionsHandler;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public class LogradouroModel
    {

        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroModel(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<Logradouro> Buscar(string email, string logradouroNome)
        {
            Logradouro logradouro = await _logradouroRepository.Buscar(email, logradouroNome);

            Validar(logradouro);

            return logradouro;
        }

        public async Task<IEnumerable<Logradouro>> BuscarTodos(string email)
        {
            IEnumerable<Logradouro> logradouros = await _logradouroRepository.BuscarTodos(email);

            return logradouros;
        }

        public async Task Adicionar(string email, string logradouroNome)
        {
            Logradouro logradouro = new Logradouro(logradouroNome, email);

            await _logradouroRepository.Inserir(logradouro);
        }

        public async Task Atualizar(string email, string logradouroAntigo, string logradouroAtual)
        {
            Logradouro logradouro = await _logradouroRepository.Buscar(email, logradouroAntigo);

            Validar(logradouro);

            logradouro.AtualizarLogradouro(logradouroAtual);

            await _logradouroRepository.Atualizar(logradouro);
        }

        public async Task Remover(string email, string logradouroNome)
        {
            Logradouro logradouro = await _logradouroRepository.Buscar(email, logradouroNome);

            Validar(logradouro);

            Logradouro logradouroAtual = new Logradouro(logradouroNome, email);

            await _logradouroRepository.Remover(logradouroAtual);
        }

        private void Validar(Logradouro logradouro)
        {
            if (logradouro == null)
                throw new LogradouroNaoEncontradoException();
        }
    }
}
