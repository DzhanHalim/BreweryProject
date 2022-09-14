using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    // Extensions are always static!
    public static class ClaimExtensions
    {
        // addemail :  a new method that we are creting
        // first parameter = is not a prameter but the class that you wanna extend
        // second paramter is just a parameter
        // to use this extension you just need to : claims.AddEmail(email);
       
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim("id", nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim("roles", role)));
        }
    }
}
