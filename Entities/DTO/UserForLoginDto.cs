using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class UserForLoginDto : IDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
