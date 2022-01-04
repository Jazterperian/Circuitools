using MySqlConnector;
namespace Circuitools
{
    public class SQLcontrol
    {
        public MySqlConnection SQLconn = new MySqlConnection("Server=34.151.204.116;Port=1460;Database=PBlivin;UserID=PBlivin;Password=Smulca");
        public MySqlCommand SQLcmd; public MySqlDataReader SQLrd;
        public bool Con() { try { SQLconn.Open(); SQLconn.Close(); return true; } catch { return false; } }
    }
}