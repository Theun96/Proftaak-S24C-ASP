using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ICT4Rails.Data_Layer
{
    public class ActiveDirectory
    {

        public bool Authenticate (string username, string password)
        {
            bool isvalid = false;
            using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "PTS18.local"))
            {
                isvalid = pc.ValidateCredentials(username, password);
            }
            return isvalid;
        }
    }
}