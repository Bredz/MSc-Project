using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.SecurityModule
{
    public class IdentityValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
           // Debug.WriteLine("Check user name");
           Core.Module.Security.ISecurity _sec = new Core.Module.Security.Security();
            var authUser = _sec.Authenticate(userName, password);

            if (authUser.Identity.IsAuthenticated==false)
            {
                var msg = String.Format("Unknown Username {0} or incorrect password {1}", userName, password);
                //Trace.TraceWarning(msg);
               throw new FaultException(msg);//the client actually will receive MessageSecurityException. But if I throw MessageSecurityException, the runtime will give FaultException to client without clear message.
            }

        }
    }

    public class RoleAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // Find out the roleNames from the user database, for example, var roleNames = userManager.GetRoles(user.Id).ToArray();
            var identity = operationContext.ServiceSecurityContext.PrimaryIdentity;
            Core.Module.Security.ISecurity _sec = new Core.Module.Security.Security();
           var userP=_sec.DressUpPrincipal("dwalters");//identity.Name
          //  if (userP.Identity.IsAuthenticated==false)
           var r = userP.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
           var roleNames = r.Select(a=>Enum.Parse(typeof(Core.Common.Enums.Permissions),a.Value).ToString()).ToArray(); //new string[] { "Customer" };
//operationContext.ServiceSecurityContext.PrimaryIdentity
            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = new GenericPrincipal(userP.Identity, roleNames);
            return true;
        }

    }

}
