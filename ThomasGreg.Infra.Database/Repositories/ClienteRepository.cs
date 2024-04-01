using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database.Repositories
{
    public class ClienteRepository : Context, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Atualizar(Cliente cliente)
        {
            string storedProcedureName = "spAtualizarCliente";

            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            var param = new
            {
                cliente.Nome,
                cliente.Logotipo,
                cliente.Email
            };

            await con.ExecuteAsync(storedProcedureName, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Cliente> Buscar(string email)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            var param = new { Email = email };

            return await con.QueryFirstOrDefaultAsync<Cliente>("spBuscarClientePorEmail", param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task Inserir(Cliente cliente)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            var param = new
            {
                cliente.Nome,
                cliente.Email,
                cliente.Logotipo
            };

            await con.ExecuteAsync("spInserirCliente", param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task Remover(string email)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            var param = new { Email = email };

            await con.ExecuteAsync("spRemoverCliente", param, commandType: System.Data.CommandType.StoredProcedure);
        }

    }
}
