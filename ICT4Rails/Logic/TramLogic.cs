using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ICT4Rails.Logic
{
    public class TramLogic
    {
       private List<int> _possbileTramNummerList = new List<int>();
        private const int ParameterInt = 0;

        public void AddingTram()
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramID", ParameterInt)
            };

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllAvailableTrams"], parameters);
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

        public void AddIncoming(string tramid, string maintenance)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramid", tramid),
                new OracleParameter("maintenance", maintenance)
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["addtramtoincoming"], parameters);
        }

        public int[] FindFreePlace()
        {
            DataTable freeRailsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeRails"], null);
            int[] spoorandnumber = {};

            foreach (DataRow freeRailDt in freeRailsDt.Rows)
            {
                int railid = Convert.ToInt32(freeRailDt[0]);
                OracleParameter[] parameters = {new OracleParameter("spoorid", railid)};
                DataTable freeSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"], parameters);
                DataTable amountOfSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                int amountOfSectors = Convert.ToInt32(amountOfSectorsDt.Rows[0][0]);
                int latestnumber = (from DataRow dr in freeSectorsDt.Rows select Convert.ToInt32(dr[0])).Concat(new[] {0}).Max();
                if(latestnumber < amountOfSectors) continue;
                spoorandnumber = new[] {Convert.ToInt32(freeRailDt[0]), latestnumber};
            }
            return spoorandnumber;
        }
    }



}