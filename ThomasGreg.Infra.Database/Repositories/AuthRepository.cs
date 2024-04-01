using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database.Repositories
{
    public class AuthRepository : Context, IAuthRepository
    {
        public AuthRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Auth> Buscar(string username)
        {
            using var con = new SqlConnection(ConexaoDB());
            await con.OpenAsync();

            var param = new { Username = username };

            return await con.QueryFirstOrDefaultAsync<Auth>("spBuscarLoginPorUsername", param, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
