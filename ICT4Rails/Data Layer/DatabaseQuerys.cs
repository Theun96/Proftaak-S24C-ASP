using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Rails.Data_Layer
{
    public class DatabaseQuerys
    {
        public static Dictionary<string, string> query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            query["GetAllLogins"] = "SELECT * FROM EMPLOYEELOGINS";
            query["GetLogin"] = "SELECT * FROM EMPLOYEELOGINS WHERE USERNAME=:username";
            query["GetEmployee"] = "SELECT USERID FROM EMPLOYEE WHERE name = :employee";
            query["CreateEmployee"] = "INSERT INTO EMPLOYEE(NAME, SURNAME, EMPLOYEETYPE) values (:name, :surname, :employeetype)";
            query["CreateLogin"] = "INSERT INTO LOGIN(USERNAME, PASSWORD, GUID, USERTYPE, USERID) values (:username, :password, :guid, :usertype, (SELECT MAX(USERID) FROM EMPLOYEE))";
            query["GetTech"] = "SELECT m.TRAMID,m.DATEADDED,m.DATEFINISHED,m.FINISHEDBY, m.OPMERKING FROM MAINTENANCE m WHERE m.TYPE = 1";
            query["GetClean"] = "SELECT m.TRAMID,m.DATEADDED,m.DATEFINISHED,m.FINISHEDBY, m.OPMERKING FROM MAINTENANCE m WHERE m.TYPE = 0";
            query["GetCleanUser"] = "SELECT e.NAME FROM EMPLOYEE e WHERE e.USERID =:USERID";
            query["RemoveUser"] = "DELETE FROM LOGIN WHERE USERNAME=:username";
            query["GetAllSectors"] = "SELECT * FROM SECTOR";
            query["GetReservedSector"] = "SELECT RAILID, POSITION FROM SECTOR WHERE TRAMID = :tramid AND ISRESERVED = 1";
            query["UpdateEndDate"] = "UPDATE MAINTENANCE SET DATEFINISHED = TO_DATE(:datefinished,'dd/mm/yyyy hh24:mi:ss') WHERE TRAMID = :tramid";
            query["GetAllCleaners"] = "SELECT NAME FROM EMPLOYEE WHERE EMPLOYEETYPE = 'schoonmaker'";
            query["GetAllEngineers"] = "SELECT NAME FROM EMPLOYEE WHERE EMPLOYEETYPE = 'technicus'";
            query["maintenancefinished"] = "UPDATE MAINTENANCE SET DATEFINISHED = TO_DATE(:datefinished,'dd/mm/yyyy hh24:mi:ss'), FINISHEDBY = :employeeid WHERE TRAMID = :tramid AND TYPE = :type";
            query["GetAllRails"] = "SELECT * FROM RAIL";
            query["addtramtoincoming"] = "INSERT INTO INCOMING (TRAMID, MOMENT, MAINTENANCE) VALUES (:tramid, sysdate, :maintenance)";
            query["traincheckin"] = "UPDATE SECTOR SET ISRESERVED = 0 WHERE TRAMID = :tramid";
            query["IncomingTrams"] = "SELECT TRAMID, MOMENT, MAINTENANCE FROM INCOMING ORDER BY MOMENT DESC";
            query["UpdateSectorInformation"] = "UPDATE SECTOR SET TRAMID =: sectorinformation WHERE RAILID =: railid AND POSITION =: position";
            query["UpdateLastSectorInformation"] = "UPDATE SECTOR SET TRAMID = NULL WHERE RAILID =: railid AND POSITION =: position";
            query["GetTramStatus"] = "SELECT TRAMID, TYPE FROM MAINTENANCE WHERE TRAMID =: tramid AND DATEFINISHED IS NULL";
            query["GetAllTramsNotOnSectors"] = "SELECT  tt.NAME, tt.SPECIFICATIONS, t.STATUS,t.TRAMID FROM TRAMTYPE tt LEFT JOIN TRAM t ON t.TRAMTYPEID = tt.TRAMTYPESID"
                + " WHERE t.TRAMID NOT IN(SELECT TRAMID FROM SECTOR WHERE TRAMID IS NOT NULL)";

            query["UpdateTramSector"] = "UPDATE SECTOR SET TRAMID =: tramid WHERE RAILID =: railid AND POSITION =: position";
            query["UpdateReservedTramSector"] = "UPDATE SECTOR SET TRAMID =: tramid,ISRESERVED = 1 WHERE RAILID =: railid AND POSITION =: position";
            query["UpdateBlocked"] = "UPDATE SECTOR SET AVAILABLE =: available WHERE RAILID =: railid AND POSITION =: position";
            query["DeleteIncoming"] = "DELETE FROM INCOMING WHERE TRAMID = :tramid";

            query["CheckRailBlocked"] = "SELECT s.RAILID FROM SECTOR s WHERE s.RAILID =:RAILID GROUP BY s.RAILID HAVING COUNT(s.SECTORID) = (SELECT COUNT(ss.SECTORID) FROM SECTOR ss WHERE ss.RAILID = s.RAILID AND ss.AVAILABLE = 0 GROUP BY ss.RAILID)";
            query["TrackStatusChange"] = "UPDATE SECTOR SET AVAILABLE =:available WHERE RAILID =:railid";
            query["CheckRailSectorBlocked"] = "SELECT SECTORID FROM SECTOR WHERE RAILID =:RailID AND TRAMID IS NOT NULL";

            query["DeblokkeerAll"] = "UPDATE SECTOR SET AVAILABLE = 1";

            query["GetImpossibleSectors"] = "SELECT s.RAILID, MAX(s.POSITION) as POSITION FROM SECTOR s WHERE s.AVAILABLE = 0 OR s.TRAMID IS NOT NULL GROUP BY s.RAILID";
            query["UpdateMaintenances"] = "INSERT INTO MAINTENANCE(dateadded , datefinished , finishedby , maintenanceid , opmerking , tramid , type) VALUES(sysdate, null, null, MAINTENANCE_SEQ.nextval,:opmerking,:tramid,:type)";
        }
    }
}