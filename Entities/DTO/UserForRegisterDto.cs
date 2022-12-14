using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class UserForRegisterDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
