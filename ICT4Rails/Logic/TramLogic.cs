using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ICT4Rails.Classes;
using ICT4Rails.Data_Layer;

namespace ICT4Rails.Logic
{
    public class TramLogic
    {
       private List<int> _possbileTramNummerList = new List<int>();
         int parameterInt = 0;

        public void AddingTram()
        {
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("tramID", parameterInt)
            };

            DataTable DT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllAvailableTrams"], parameters);


        }
    }
}