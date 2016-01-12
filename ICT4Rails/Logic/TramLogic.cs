using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

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

        public int FindFreePlace()
        {
            DataTable freeRailsDT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeRails"], null);

            foreach (DataRow freeRailDT in freeRailsDT.Rows)
            {
                int railid = Convert.ToInt32(freeRailDT[0]);
                OracleParameter[] parameters = {new OracleParameter("spoorid", railid)};
                DataTable freeSectorsDT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"], parameters);
                DataTable amountOfSectorsDT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                int amountOfSectors = Convert.ToInt32(amountOfSectorsDT.Rows[0][0]);
                int latestnumber = 1;
                foreach (DataRow dr in freeSectorsDT.Rows)
                {
                    int currentNumber = Convert.ToInt32(dr[0]);
                    if (latestnumber < currentNumber)
                    {
                        
                    }
                }
            }
            return 0;
        }
    }



}