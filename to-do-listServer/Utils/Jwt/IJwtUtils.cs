using System;
using to_do_listServer.Models;

namespace to_do_listServer.Config.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public Guid? ValidateToken(string token);
    }
}