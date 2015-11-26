using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

namespace ICT4Rails___ASP
{
    public class UserManager
    {
        public bool Authenticate(string username, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "PTS18.local"))
            {
                return pc.ValidateCredentials(username, password);
            }
        }
    }
}