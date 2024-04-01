using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Domain
{
    public class Auth
    {
        public Auth(int id, string username, string passwordHash)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

    }
}
