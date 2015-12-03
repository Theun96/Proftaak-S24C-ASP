using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ICT4Rails.Data_Layer
{
    public class Active_Directory
    {
        private string _path;
        private string _domain = "PTS18.local";

        public bool Authenticate (string username, string password)
        {
            bool _isvalid = false;
            using(PrincipalContext PC = new PrincipalContext(ContextType.Domain, _domain))
            {
                _isvalid = PC.ValidateCredentials(username, password);
            }
            return _isvalid;
        }
    }
}