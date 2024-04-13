using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using start.Models;

namespace start.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}