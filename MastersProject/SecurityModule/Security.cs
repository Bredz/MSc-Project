
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.SecurityModule
{
    public class Security:ISecurity
    {
        NIS.NIMS.Data.Core.Interfaces.IRepositoryBase<NIS.NIMS.Data.NISUsers> _userRepo;
        NIS.NIMS.Data.Core.Interfaces.IRepositoryBase<NIS.NIMS.Data.RolePermissions> _permRepo;
        DbContext _ctx;
        NIS.NIMS.Data.Core.Interfaces.IUnitOfWork<NIS.NIMS.Data.NIMSModelContainer> _uow;
        public Security()
            : this(new NIS.NIMS.Data.Core.UnitOfWorkBase<NIS.NIMS.Data.NIMSModelContainer>())
        {

        }
        public Security(NIS.NIMS.Data.Core.Interfaces.IUnitOfWork<NIS.NIMS.Data.NIMSModelContainer> uow)
        {
            _uow = uow;
            _ctx = _uow.context;
            //set repository context
            _userRepo = new NIS.NIMS.Data.Core.RepositoryBase<NIS.NIMS.Data.NISUsers>(_ctx);
            _permRepo = new NIS.NIMS.Data.Core.RepositoryBase<NIS.NIMS.Data.RolePermissions>(_ctx);
        }
        

        public ClaimsPrincipal Authenticate(string Username, string Password)
        {
            //TODO check if account is locked
            var isLoc=_userRepo.QueryAsNoTracking(a => a.UserName.Equals(Username, StringComparison.CurrentCultureIgnoreCase) && a.Locked == true).FirstOrDefault();
            if (isLoc != null)
                throw new NIMS.Common.NimsException("Account is locked,please contact operations unit of the M.I.S department.");
            //TODO validate uname & pword
            var pwd = Encrypt(Password, true);

            var tmpUser = _userRepo.QueryAsNoTracking(a => a.UserName.Equals(Username, StringComparison.CurrentCultureIgnoreCase) && a.PasswordHash.Equals(pwd)).FirstOrDefault();
            if (tmpUser != null)
            {
                //get claims for authenticated user else return defaults
                return DressUpPrincipal(Username);
            }
            else
            {
                throw new NIMS.Common.NimsException("Invalid username and/or password.");

            }
           
        }
       /// <summary>
       /// Used with web applications to replace default claims information 
       /// </summary>
       /// <param name="userName"></param>
       /// <returns></returns>
        //ClaimsPrincipal DressUpPrincipal(string userName)
        //{
        //    List<Claim> claims = new List<Claim>();
        //    ClaimsIdentity ci = new ClaimsIdentity();
            
        //    var tmpUser = _userRepo.Query(a => a.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //    //simulate database lookup
        //    if (tmpUser != null)
        //    {
        //        //Get user's permissions based on roles
        //        //var myRoles = tmpUser.AspNetRole;
        //        ////Get and store user's permissions for later use when authorizing actions
        //        //var t = myRoles.RolePermissions.Select(p => p.RolePermissions).ToList()[0];// tmpUser.AspNetRoles.Select(a => a.RolePermissions).GroupBy(a=>a).Select(a=>a.Key.ToString()).ToList();
        //        // var t = _permRepo.Where(r => myRoles.Any(ur => ur.RoleId == r.Id)).ToList();
        //        //List<NIS.NIMS.Data.RolePermission> userPermissions = new List<NIS.NIMS.Data.RolePermission>();
        //        //foreach (var item in t)
        //        //{
        //        //    userPermissions.AddRange(item.Permissions);
        //        //}
        //        //Session["UserPermissions"]
        //        var perms = _permRepo.Query(r => r.RoleId == tmpUser.RoleId).Select(p => p.PermissionId).GroupBy(a => a).Select(a => a.Key.ToString()).ToList();

        //        ci = CreateClaimsPrincipal(userName.ToLower(), perms.Aggregate((i, j) => i + "," + j));
        //        ci.AddClaim(new Claim("Department",tmpUser.Department_Id.ToString()));
        //        ci.AddClaim(new Claim("Parish", tmpUser.Parish.ToString()));
        //        ci.AddClaim(new Claim("Role", tmpUser.RoleId));
        //        ci.AddClaim(new Claim(ClaimTypes.GivenName,tmpUser.Firstname + ","+ tmpUser.Lastname + " ("+ userName.ToLower()+")"));
        //    }
        //    else
        //    {
        //        claims.Add(new Claim(ClaimTypes.GivenName, userName));
        //        claims.Add(new Claim(ClaimTypes.Name, userName));
        //        claims.Add(new Claim(ClaimTypes.NameIdentifier,tmpUser.Id));
        //        ci = new ClaimsIdentity(claims);
        //    }



        //    return new ClaimsPrincipal(ci);
        //}

        private ClaimsIdentity CreateClaimsPrincipal(string userName, string UserPermissions = "")
        {
            GenericIdentity gi = new GenericIdentity(userName, Constants.DefaultAuthenticationType);
            ClaimsIdentity ci = new ClaimsIdentity(gi);
            List<Claim> cls = new List<Claim>();
            var cl = new Claim(ClaimTypes.NameIdentifier, userName);//"http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider"
            cls.Add(cl);

            foreach (string rol in UserPermissions.Split(',').
              Select(r => r.Trim()).ToArray())
            {
                cl = new Claim(ClaimTypes.Role, rol);
                cls.Add(cl);
            }

            ci.AddClaims(cls);
            return ci;
            //this.AddIdentity(ci);
        }
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        private static string Encrypt(string toEncrypt, bool useHashing)
        {

            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "6Pd6pufTraVCEROd";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="cipherString"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        private static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "6Pd6pufTraVCEROd";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }



        public string HashString(string stringToHash)
        {
            return Encrypt(stringToHash, true);
        }





       public ClaimsPrincipal DressUpPrincipal(string userName)
        {
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity ci = new ClaimsIdentity();

            var tmpUser = _userRepo.Query(a => a.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //simulate database lookup
            if (tmpUser != null)
            {
                //Get user's permissions based on roles
                //var myRoles = tmpUser.AspNetRole;
                ////Get and store user's permissions for later use when authorizing actions
                //var t = myRoles.RolePermissions.Select(p => p.RolePermissions).ToList()[0];// tmpUser.AspNetRoles.Select(a => a.RolePermissions).GroupBy(a=>a).Select(a=>a.Key.ToString()).ToList();
                // var t = _permRepo.Where(r => myRoles.Any(ur => ur.RoleId == r.Id)).ToList();
                //List<NIS.NIMS.Data.RolePermission> userPermissions = new List<NIS.NIMS.Data.RolePermission>();
                //foreach (var item in t)
                //{
                //    userPermissions.AddRange(item.Permissions);
                //}
                //Session["UserPermissions"]
                var perms = _permRepo.Query(r => r.RoleId == tmpUser.RoleId).Select(p => p.PermissionId).GroupBy(a => a).Select(a => a.Key.ToString()).ToList();

                ci = CreateClaimsPrincipal(userName.ToLower(), perms.Aggregate((i, j) => i + "," + j));
                ci.AddClaim(new Claim("Department", tmpUser.Department_Id.ToString()));
                ci.AddClaim(new Claim("Parish", tmpUser.Parish.ToString()));
                ci.AddClaim(new Claim("Role", tmpUser.RoleId));
                ci.AddClaim(new Claim(ClaimTypes.GivenName, tmpUser.Firstname + "," + tmpUser.Lastname + " (" + userName.ToLower() + ")"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.GivenName, userName));
                claims.Add(new Claim(ClaimTypes.Name, userName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, tmpUser.Id));
                ci = new ClaimsIdentity(claims);
            }



            return new ClaimsPrincipal(ci);
        }
    }

}
