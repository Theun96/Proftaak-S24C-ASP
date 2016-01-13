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
        private readonly int[] _line1 = {17, 23}; //Done
        private readonly int[] _line2 = {19, 15, 31, 38}; //Done
        private readonly int[] _line5 = {18, 22, 32, 30}; //Done
        private readonly int[] _line10 = {13, 21}; //Done
        private readonly int[] _line13 = {24, 29}; //Done
        private readonly int[] _line16 = {16, 14, 11, 33}; //Done
        private readonly int[] _line24 = {16, 14, 11, 33}; //Done
        private readonly int[] _line17 = {25, 28}; //Done
        private readonly int[] _reserve = {12, 20, 34, 27, 39, 37, 36, 40, 41, 42, 43};

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

        public int[] FindFreePlace(int spoor, string type, int tramid)
        {
            bool maintenance = (type != "");

            if (spoor == 0)
            {
                OracleParameter[] parameters = {new OracleParameter("spoorid", spoor)};
                DataTable freeRailsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeRailFromId"], parameters);
                return null;
            }
            else
            {
                OracleParameter[] parameters1 = {new OracleParameter("tramid", tramid)};
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTramLine"], parameters1);
                if (dt.Rows.Count <= 0) return FindReserveRail();
                int linenumber = Convert.ToInt32(dt.Rows[0][0]);

                int[] sporen = FindRailFromLine(linenumber);

                int[] spoorandnumber = null;
                if (sporen == null) return null;

                foreach (int spoorI in sporen)
                {
                    OracleParameter[] parameters = {new OracleParameter("spoorid", spoorI)};
                    DataTable freeSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"],parameters);
                    List<int> freeSectors = (from DataRow freeSector in freeSectorsDt.Rows select Convert.ToInt32(freeSector[3])).ToList();
                    freeSectors.Sort();
                    freeSectors.Reverse();

                    DataTable amountOfSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                    int amountOfSectors = Convert.ToInt32(amountOfSectorsDt.Rows[0][0]);

                    if (!maintenance && amountOfSectors <= 1) continue;
                    if (maintenance && amountOfSectors > 1) continue;
                    if (freeSectors[0] != amountOfSectors) continue;

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

                    spoorandnumber = new[] {spoorI, lastAvailable};
                    break;
                }

                return spoorandnumber ?? FindReserveRail();
            }  
        }

        private int[] FindReserveRail()
        {
            int[] spoorandnumber = null;
            foreach (int rail in _reserve)
            {
                OracleParameter[] parameters = { new OracleParameter("spoorid", rail) };
                DataTable freeSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"], parameters);
                List<int> freeSectors = (from DataRow freeSector in freeSectorsDt.Rows select Convert.ToInt32(freeSector[3])).ToList();
                freeSectors.Sort();
                freeSectors.Reverse();

                DataTable amountOfSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                int amountOfSectors = Convert.ToInt32(amountOfSectorsDt.Rows[0][0]);
                if (freeSectors[0] != amountOfSectors) continue;

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

                spoorandnumber = new[] { rail, lastAvailable };
                break;
            }

            return spoorandnumber;
        }

        public static bool CheckIfExists(int tramid)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("tramnumber", tramid)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["CheckIfTramExists"], parameters);
            return (Convert.ToInt32(dt.Rows[0][0]) == 1);
        }

        public static void AddTramToMaintenance(int tramid, string maintenance)
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

        public static void Simulatie()
        {
            int[] simulatiesporen = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 27, 28, 29, 30, 31, 32, 33, 34, 36, 37, 38, 39};
            Shuffle(simulatiesporen);
            DataTable freeTramsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeTramIds"], null);
            List<int> freeTrams = (from DataRow dr in freeTramsDt.Rows select Convert.ToInt32(dr[0])).ToList();
            Random rnd = new Random();
            int randomindex = rnd.Next(freeTrams.Count);
            int tramid = freeTrams[randomindex];

            int randomsectorid = 0;
            int randomspoorid = 0;
            foreach (int spoor in simulatiesporen)
            {
                OracleParameter[] parameters =
                {
                    new OracleParameter("spoorid", spoor)
                };
                DataTable freeSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFreeSectors"], parameters);
                List<int> freeSectors = (from DataRow dr in freeSectorsDt.Rows select Convert.ToInt32(dr[3])).ToList();
                if(!freeSectors.Any()) continue;
                freeSectors.Sort();
                freeSectors.Reverse();
                DataTable amountOfSectorsDt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameters);
                int amountOfSectors = Convert.ToInt32(amountOfSectorsDt.Rows[0][0]);
                if (freeSectors[0] != amountOfSectors) continue;
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

                randomsectorid = lastAvailable;
                randomspoorid = spoor;
                break;
            }

            if (randomspoorid == 0 || randomsectorid == 0) return;
            AddTrainToSector(tramid, randomspoorid, randomsectorid);
        }

        private int[] FindRailFromLine(int linenumber)
        {
            int[] sporen;
            switch (linenumber)
            {
                case 1:
                    sporen = _line1;
                    break;
                case 2:
                    sporen = _line2;
                    break;
                case 5:
                    sporen = _line5;
                    break;
                case 10:
                    sporen = _line10;
                    break;
                case 13:
                    sporen = _line13;
                    break;
                case 16:
                    sporen = _line16;
                    break;
                case 17:
                    sporen = _line17;
                    break;
                case 24:
                    sporen = _line24;
                    break;
                default:
                    sporen = null;
                    break;
            }
            return sporen;
        }

        private static readonly Random Random = new Random();

        private static void Shuffle<T>(IList<T> array)
        {
            int n = array.Count;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(Random.NextDouble() * (n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }



}