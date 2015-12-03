using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Rails.Database
{
    public class Database
    {
        private OracleConnection connection;
        public OracleConnection Connection
        {
            get
            {
                connection = new OracleConnection();
                try
                {
                    connection.Open();
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("UserPage.aspx", true);
                }
                return connection;
            }
        }
    }
}