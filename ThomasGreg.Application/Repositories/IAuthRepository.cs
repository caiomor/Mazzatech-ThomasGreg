using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public interface IAuthRepository
    {
        Task<Auth> Buscar(string username);
    }
}
