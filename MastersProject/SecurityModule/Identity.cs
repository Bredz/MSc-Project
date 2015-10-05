using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.SecurityModule
{
   public class Identity:ClaimsIdentity
    {
        public Identity(IEnumerable<Claim> claims, string authenticationType):base(claims,authenticationType)
        {

        }
    }
}
