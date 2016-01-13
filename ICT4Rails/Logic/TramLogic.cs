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

        public static void AddTrainToSector(int tramid, int spoor, int sector)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramid", tramid),
                new OracleParameter("spoor", spoor), 
                new OracleParameter("sector", sector)
            };

            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["AddTramToSector"], parameters);
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

        public static int CheckReserved(int tramid)
        {
            int spoor = 0;
            OracleParameter[] parameters =
            {
                new OracleParameter("tramid", tramid)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetReserved"], parameters);
            if (dt.Rows.Count > 0)
            {
                spoor = Convert.ToInt32(dt.Rows[0][2]);
            }
            return spoor;
        }

        public static int GetNumberFromRail(int id)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("id", id)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetNumberFromRail"], parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        public static int GetIdFromTram(int number)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramnumber", number)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetIdFromTram"], parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
            
        }

        public static int[] FindFreePlace(int spoor, string type)
        {
            bool maintenance = (type != "");
            DataTable freeRailsDt;
            if (spoor == 0)
            {
                freeRailsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeRails"], null);
            }
            else
            {
                OracleParameter[] parameters = {new OracleParameter("spoorid", spoor)};
                freeRailsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeRailFromId"], parameters);
            }
            
            int[] spoorandnumber = null;

            foreach (DataRow freeRailDt in freeRailsDt.Rows)
            {
                int railid = Convert.ToInt32(freeRailDt[0]);
                OracleParameter[] parameters = {new OracleParameter("spoorid", railid)};
                DataTable freeSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"], parameters);
                //List<int> freeSectors = (from DataRow dr in freeSectorsDt.Rows select Convert.ToInt32(dr[4])).ToList();
                List<int> freeSectors = (from DataRow freeSector in freeSectorsDt.Rows select Convert.ToInt32(freeSector[3])).ToList();
                freeSectors.Sort();
                freeSectors.Reverse();
                DataTable amountOfSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                int amountOfSectors = Convert.ToInt32(amountOfSectorsDt.Rows[0][0]);
                if(!maintenance && amountOfSectors <= 1) continue;
                if(maintenance && amountOfSectors > 1) continue;
                if(freeSectors[0] != amountOfSectors) continue;
                int lastAvailable = amountOfSectors;
                foreach (int number in freeSectors.Where(number => number != lastAvailable))
                {
                    if (number == lastAvailable - 1)
                    {
                        lastAvailable = number;
                    }
                    else
                    {
                        break;
                    }
                }

                spoorandnumber = new[] {Convert.ToInt32(freeRailDt[0]), lastAvailable};
                break;
            }
            return spoorandnumber;
        }

        public bool CheckIfExists(int tramid)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramnumber", tramid)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["CheckIfTramExists"], parameters);
            return (Convert.ToInt32(dt.Rows[0][0]) == 1);
        }

        public void AddTramToMaintenance(int tramid, string maintenance)
        {
            if(maintenance == "") return;
            OracleParameter[] parameters =
            {
                new OracleParameter("tramid", tramid),
                new OracleParameter("startdate", $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/{DateTime.Now.ToLongTimeString()}"), 
                new OracleParameter("soort", maintenance)
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["AddTramToMaintenance"], parameters);
        }

        public void Simulatie()
        {
            
        }
    }



}