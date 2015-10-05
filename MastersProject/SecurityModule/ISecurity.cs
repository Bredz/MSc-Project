using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.SecurityModule
{
   public interface ISecurity
    {
        //string RequestKey(string Username,string IpAddress);
       ClaimsPrincipal Authenticate(string Username, string Password);
       string HashString(string stringToHash);
       ClaimsPrincipal DressUpPrincipal(string userName);
    }
}
