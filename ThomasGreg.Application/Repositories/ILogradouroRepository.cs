using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> Buscar(string email, string logradouro);
        Task<IEnumerable<Logradouro>> BuscarTodos(string email);
        Task Inserir(Logradouro logradouro);

        Task Atualizar(Logradouro logradouro);

        Task Remover(Logradouro logradouro);
    }
}
