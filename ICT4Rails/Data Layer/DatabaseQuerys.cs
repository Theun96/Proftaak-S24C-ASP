using System.Collections.Generic;

namespace ICT4Rails.Data_Layer
{
    public class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            //Query["GetAllLogins"] = "SELECT * FROM EMPLOYEELOGINS";
            //Query["GetLogin"] = "SELECT * FROM EMPLOYEELOGINS WHERE USERNAME=:username";
            //Query["GetEmployee"] = "SELECT USERID FROM EMPLOYEE WHERE name = :employee";
            //Query["CreateEmployee"] = "INSERT INTO EMPLOYEE(NAME, SURNAME, EMPLOYEETYPE) values (:name, :surname, :employeetype)";
            //Query["CreateLogin"] = "INSERT INTO LOGIN(USERNAME, PASSWORD, GUID, USERTYPE, USERID) values (:username, :password, :guid, :usertype, (SELECT MAX(USERID) FROM EMPLOYEE))";
            //Query["GetTech"] = "SELECT m.TRAMID,m.DATEADDED,m.DATEFINISHED,m.FINISHEDBY, m.OPMERKING FROM MAINTENANCE m WHERE m.TYPE = 1";
            //Query["GetClean"] = "SELECT m.TRAMID,m.DATEADDED,m.DATEFINISHED,m.FINISHEDBY, m.OPMERKING FROM MAINTENANCE m WHERE m.TYPE = 0";
            //Query["GetCleanUser"] = "SELECT e.NAME FROM EMPLOYEE e WHERE e.USERID =:USERID";
            //Query["RemoveUser"] = "DELETE FROM LOGIN WHERE USERNAME=:username";
            
            //Query["GetReservedSector"] = "SELECT RAILID, POSITION FROM SECTOR WHERE TRAMID = :tramid AND ISRESERVED = 1";
            //Query["UpdateEndDate"] = "UPDATE MAINTENANCE SET DATEFINISHED = TO_DATE(:datefinished,'dd/mm/yyyy hh24:mi:ss') WHERE TRAMID = :tramid";
            //Query["GetAllCleaners"] = "SELECT NAME FROM EMPLOYEE WHERE EMPLOYEETYPE = 'schoonmaker'";
            //Query["GetAllEngineers"] = "SELECT NAME FROM EMPLOYEE WHERE EMPLOYEETYPE = 'technicus'";
            //Query["maintenancefinished"] = "UPDATE MAINTENANCE SET DATEFINISHED = TO_DATE(:datefinished,'dd/mm/yyyy hh24:mi:ss'), FINISHEDBY = :employeeid WHERE TRAMID = :tramid AND TYPE = :type";

            //Beheer systeem querys
            Query["GetAllRails"] = "SELECT \"ID\", \"Nummer\" FROM SPOOR";
            Query["GetAllSectors"] = "SELECT * FROM SectorOverzicht";
            Query["GetTramNummer"] = "SELECT \"Nummer\" FROM \"TRAM\" WHERE ID = :id";

            //tech en clean
            Query["GetAllEngineers"] = "SELECT m.\"Naam\", m.id FROM medewerker m, functie f WHERE f.ID = 4 AND f.id = m.\"Functie_ID\"";
            Query["GetAllCleaners"] = "SELECT m.\"Naam\", m.id FROM medewerker m, functie f WHERE f.ID = 5 AND f.id = m.\"Functie_ID\"";

            Query["GetTech"] = "SELECT m.\"Naam\",tod.\"BeschikbaarDatum\",tod.\"DatumTijdstip\",tod.\"TypeOnderhoud\",t.\"Nummer\" FROM Tram t, Tram_onderhoud tod LEFT JOIN medewerker m ON m.id = tod.\"Medewerker_ID\" WHERE t.id = tod.\"Tram_ID\" AND tod.type = 'Techniek'";
            Query["GetClean"] = "SELECT m.\"Naam\",tod.\"BeschikbaarDatum\",tod.\"DatumTijdstip\",tod.\"TypeOnderhoud\",t.\"Nummer\" FROM Tram t, Tram_onderhoud tod LEFT JOIN medewerker m ON m.id = tod.\"Medewerker_ID\" WHERE t.id = tod.\"Tram_ID\" AND tod.type = 'Schoonmaak'";

            Query["SetTech"] = "UPDATE TRAM_ONDERHOUD SET \"BeschikbaarDatum\" = SYSDATE, \"Medewerker_ID\" = (SELECT ID FROM MEDEWERKER WHERE \"Naam\" = :naam) WHERE \"Tram_ID\" = (SELECT t.ID FROM TRAM t WHERE t.\"Nummer\" = :id) AND type = 'Techniek'";
            Query["SetClean"] = "UPDATE TRAM_ONDERHOUD SET \"BeschikbaarDatum\" = SYSDATE, \"Medewerker_ID\" = (SELECT ID FROM MEDEWERKER WHERE \"Naam\" = :naam) WHERE \"Tram_ID\" = (SELECT t.ID FROM TRAM t WHERE t.\"Nummer\" = :id) AND type = 'Schoonmaak'";


            Query["SetTechDate"] = "UPDATE TRAM_ONDERHOUD SET \"BeschikbaarDatum\" = TO_DATE(:datum, 'MM/DD/YYYY') WHERE \"Tram_ID\" = (SELECT ID FROM TRAM WHERE \"Nummer\" = :nummer) AND TYPE = 'Techniek'";
            Query["SetCleanDate"] = "UPDATE TRAM_ONDERHOUD SET \"BeschikbaarDatum\" = TO_DATE(:datum, 'MM/DD/YYYY') WHERE \"Tram_ID\" = (SELECT ID FROM TRAM WHERE \"Nummer\" = :nummer) AND TYPE = 'Schoonmaak'";

            Query["GetFreeSectors"] = "SELECT * FROM \"SECTOR\" WHERE \"Tram_ID\" IS NULL AND \"Blokkade\" = 0 AND \"Spoor_ID\" = :spoorid";
            Query["GetFreeRails"] = "SELECT \"Spoor_ID\" FROM \"SECTOR\" WHERE \"Tram_ID\" IS NULL AND \"Blokkade\" = 0 GROUP BY \"Spoor_ID\" ORDER BY \"Spoor_ID\"";
            Query["GetAmountOfSectors"] = "SELECT COUNT(*) FROM \"SECTOR\" WHERE \"Spoor_ID\" = :spoorid";
            //Query["addtramtoincoming"] = "INSERT INTO INCOMING (TRAMID, MOMENT, MAINTENANCE) VALUES (:tramid, sysdate, :maintenance)";
            //Query["traincheckin"] = "UPDATE SECTOR SET ISRESERVED = 0 WHERE TRAMID = :tramid";
            //Query["IncomingTrams"] = "SELECT TRAMID, MOMENT, MAINTENANCE FROM INCOMING ORDER BY MOMENT DESC";
            //Query["UpdateSectorInformation"] = "UPDATE SECTOR SET TRAMID =: sectorinformation WHERE RAILID =: railid AND POSITION =: position";
            //Query["UpdateLastSectorInformation"] = "UPDATE SECTOR SET TRAMID = NULL WHERE RAILID =: railid AND POSITION =: position";
            //Query["GetTramStatus"] = "SELECT TRAMID, TYPE FROM MAINTENANCE WHERE TRAMID =: tramid AND DATEFINISHED IS NULL";
            //Query["GetAllTramsNotOnSectors"] = "SELECT  tt.NAME, tt.SPECIFICATIONS, t.STATUS,t.TRAMID FROM TRAMTYPE tt LEFT JOIN TRAM t ON t.TRAMTYPEID = tt.TRAMTYPESID"
            //+ " WHERE t.TRAMID NOT IN(SELECT TRAMID FROM SECTOR WHERE TRAMID IS NOT NULL)";

            //Query["UpdateTramSector"] = "UPDATE SECTOR SET TRAMID =: tramid WHERE RAILID =: railid AND POSITION =: position";
            //Query["UpdateReservedTramSector"] = "UPDATE SECTOR SET TRAMID =: tramid,ISRESERVED = 1 WHERE RAILID =: railid AND POSITION =: position";
            //Query["UpdateBlocked"] = "UPDATE SECTOR SET AVAILABLE =: available WHERE RAILID =: railid AND POSITION =: position";
            //Query["DeleteIncoming"] = "DELETE FROM INCOMING WHERE TRAMID = :tramid";

            //Query["CheckRailBlocked"] = "SELECT s.RAILID FROM SECTOR s WHERE s.RAILID =:RAILID GROUP BY s.RAILID HAVING COUNT(s.SECTORID) = (SELECT COUNT(ss.SECTORID) FROM SECTOR ss WHERE ss.RAILID = s.RAILID AND ss.AVAILABLE = 0 GROUP BY ss.RAILID)";
            //Query["TrackStatusChange"] = "UPDATE SECTOR SET AVAILABLE =:available WHERE RAILID =:railid";
            //Query["CheckRailSectorBlocked"] = "SELECT SECTORID FROM SECTOR WHERE RAILID =:RailID AND TRAMID IS NOT NULL";

            //Query["DeblokkeerAll"] = "UPDATE SECTOR SET AVAILABLE = 1";

            //Query["GetImpossibleSectors"] = "SELECT s.RAILID, MAX(s.POSITION) as POSITION FROM SECTOR s WHERE s.AVAILABLE = 0 OR s.TRAMID IS NOT NULL GROUP BY s.RAILID";
            //Query["UpdateMaintenances"] = "INSERT INTO MAINTENANCE(dateadded , datefinished , finishedby , maintenanceid , opmerking , tramid , type) VALUES(sysdate, null, null, MAINTENANCE_SEQ.nextval,:opmerking,:tramid,:type)";
            Query["GetAllReservedSectors"] =
                "SELECT ID,\"Tram_ID\", \"Spoor_ID\", \"Nummer\", \"Blokkade\", \"Beschikbaar\" FROM SECTOR WHERE \"Beschikbaar\" = 0 AND \"Tram_ID\" IS NOT NULL";
            Query["GetAllAvailableTrams"] = "SELECT t.\"Nummer\" FROM Tram t,Sector s WHERE t.id = s.\"Tram_ID\"";
            Query["GetReservedSector"] = "SELECT \"Spoor_ID\", \"Nummer\" FROM SECTOR WHERE \"Beschikbaar\" = 0 AND \"Tram_ID\" =:tramid";
        }
    }
}