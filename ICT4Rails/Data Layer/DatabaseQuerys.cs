using System.Collections.Generic;
using System.Web.UI;

namespace ICT4Rails.Data_Layer
{
    public class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            //Beheer systeem querys
            Query["GetAllRails"] = "SELECT \"ID\", \"Nummer\" FROM SPOOR";
            Query["GetAllSectors"] = "SELECT * FROM SectorOverzicht";
            Query["GetTramNummer"] = "SELECT \"Nummer\" FROM \"TRAM\" WHERE ID = :id";
            Query["GetTramID"] = "SELECT ID FROM \"TRAM\" WHERE \"Nummer\" = :nummer";
            Query["GetSpecificSector"] = "SELECT * FROM SectorOverzicht WHERE ID = :id";

            Query["UpdateSectorBlokkade"] = "UPDATE SECTOR SET \"Blokkade\" = :blokkade WHERE ID = :id";
            Query["UpdateTramSector"] = "UPDATE SECTOR SET \"Tram_ID\" = :tramid WHERE ID = :id";
            Query["DeleteTramSector"] = "UPDATE SECTOR SET \"Tram_ID\" = null WHERE ID = :id";

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
            Query["GetFreeRailFromId"] = "SELECT \"Spoor_ID\" FROM \"SECTOR\" WHERE \"Tram_ID\" IS NULL AND \"Blokkade\" = 0 AND \"Spoor_ID\" = :spoorid";
            Query["GetAmountOfSectors"] = "SELECT COUNT(*) FROM \"SECTOR\" WHERE \"Spoor_ID\" = :spoorid";
            Query["GetReserved"] = "SELECT * FROM \"RESERVERING\" WHERE \"Tram_ID\" = :tramid";
            Query["GetNumberFromRail"] = "SELECT \"Nummer\" FROM \"SPOOR\" WHERE \"ID\" = :id";
            Query["GetIdFromTram"] = "SELECT \"ID\" FROM \"TRAM\" WHERE \"Nummer\" = :tramnumber";
            Query["AddTramToSector"] = "UPDATE SECTOR SET \"Tram_ID\" = :tramid WHERE \"Spoor_ID\" = :spoor AND \"Nummer\" = :sector";

            Query["GetAllReservedSectors"] =
                "SELECT ID,\"Tram_ID\", \"Spoor_ID\", \"Nummer\", \"Blokkade\", \"Beschikbaar\" FROM SECTOR WHERE \"Beschikbaar\" = 0 AND \"Tram_ID\" IS NOT NULL";
            Query["GetAllAvailableTrams"] = "SELECT t.\"Nummer\" FROM Tram t,Sector s WHERE t.id = s.\"Tram_ID\"";
            Query["GetReservedSector"] = "SELECT \"Spoor_ID\", \"Nummer\" FROM SECTOR WHERE \"Beschikbaar\" = 0 AND \"Tram_ID\" =:tramid";
            Query["CheckIfTramExists"] = "SELECT COUNT(*) FROM SECTOR WHERE \"Tram_ID\" = :tramid";
            Query["AddTramToMaintenance"] = "INSERT INTO TRAM_ONDERHOUD (\"Tram_ID\", \"DatumTijdstip\", \"TypeOnderhoud\", TYPE) VALUES (:tramid, TO_DATE(:startdate, 'YYYY-MM-DD HH24:MI:SS'), 'abc', :soort)";
            Query["GetFreeTramIds"] = "SELECT T.ID FROM TRAM T LEFT JOIN SECTOR S ON T.\"ID\" = S.\"Tram_ID\" WHERE S.\"Tram_ID\" IS NULL";
        }
    }
}