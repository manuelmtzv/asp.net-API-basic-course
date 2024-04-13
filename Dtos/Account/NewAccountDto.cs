using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace start.Dtos.Account
{
    public class NewAccountDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}