using System.Threading.Tasks;
using ThomasGreg.Application.ExceptionsHandler;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public class ClienteModel
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteModel(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Atualizar(string nome, string email, string logotipo)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            Validar(clienteEmail, email);

            Cliente cliente = new Cliente(nome, email, logotipo);

            await _clienteRepository.Atualizar(cliente);
        }


        public async Task<Cliente> Buscar(string email)
        {
            var cliente = await _clienteRepository.Buscar(email);
            Validar(cliente, email);
            return cliente;
        }

        public async Task Inserir(string nome, string email, string logotipo)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);
            if (clienteEmail != null)
                throw new ClienteExistenteException(email);

            Cliente cliente = new Cliente(nome, email, logotipo);
            
            await _clienteRepository.Inserir(cliente);
        }

        public async Task Remover(string email)
        {
            var cliente = await _clienteRepository.Buscar(email);

            Validar(cliente, email);

            await _clienteRepository.Remover(email);
        }

        private void Validar(Cliente cliente, string email)
        {
            if (cliente == null)
                throw new ClienteNaoEncontradoException(email);
        }
    }
}
