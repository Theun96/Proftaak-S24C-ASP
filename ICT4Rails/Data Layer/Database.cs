using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Rails.Data_Layer
{
    public class Database
    {
        private OracleConnection _connection;
        public OracleConnection Connection
        {
            get
            {
                _connection = new OracleConnection();
                try
                {
                    _connection.Open();
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("UserPage.aspx", true);
                }
                return _connection;
            }
        }
    }
}