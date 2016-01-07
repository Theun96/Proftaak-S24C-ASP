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

        public int[] GetReservedSector(int tramnumber)
        {
            OracleParameter[] op = { new OracleParameter("tramid", tramnumber) };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetReservedSector"], op);
            int[] info = new int[2];
            foreach (DataRow dr in dt.Rows)
            {
                info[0] = Convert.ToInt32(dr[0]);
                info[1] = Convert.ToInt32(dr[1]);
            }

            return info;
        }

        public void AddIncoming(string tramid, int maintenance)
        {
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("tramid", tramid),
                new OracleParameter("maintenance", maintenance)
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["addtramtoincoming"], parameters);
        }
    }
}