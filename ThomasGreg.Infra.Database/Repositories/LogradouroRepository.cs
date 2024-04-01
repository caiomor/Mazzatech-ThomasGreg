using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database.Repositories
{
    public class LogradouroRepository : Context, ILogradouroRepository
    {
        public LogradouroRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Atualizar(Logradouro logradouro)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            await con.ExecuteAsync("spAtualizarLogradouro", new { logradouro.LogradouroNome, logradouro.Email }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Logradouro> Buscar(string email, string logradouro)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            return await con.QueryFirstOrDefaultAsync<Logradouro>("spBuscarLogradouro", new { email, logradouro }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Logradouro>> BuscarTodos(string email)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            return await con.QueryAsync<Logradouro>("spBuscarTodosLogradouros", new { email }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task Inserir(Logradouro logradouro)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            await con.ExecuteAsync("spInserirLogradouro", new { logradouro.LogradouroNome, logradouro.Email }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task Remover(Logradouro logradouro)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            await con.ExecuteAsync("spRemoverLogradouro", new { logradouro.Email, logradouro.LogradouroNome }, commandType: System.Data.CommandType.StoredProcedure);
        }

    }
}
