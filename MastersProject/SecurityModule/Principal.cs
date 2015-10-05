using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.SecurityModule
{
    public class Principal : ClaimsPrincipal
    {


        public Principal(Identity identity)
            : base(identity)
        {

        }

        public Principal(ClaimsPrincipal claimsPrincipal)
            : base(claimsPrincipal)
        {

        }
    }
    
}
