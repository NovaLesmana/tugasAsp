using MySql.Data.MySqlClient;

namespace absensionline.Models
{
    public class koneksiDB
    {
        private static string username = "root";
        private static string password = "";
        private static string server = "localhost";
        private static string db = "kampus7";
        string cs = @"server=" + server + ";userid=" + username + ";password=" + password + ";database=" + db;
        private MySqlConnection connection;
        public MySqlConnection openConnection()
        {

            if (connection != null)
            {
                return connection;
            }
            else
            {
                connection = new MySqlConnection(cs);
            }
            return connection;
        }
        public bool checkConnection()
        {

            bool result = false;
            MySqlConnection connection = openConnection();
            try
            {

                connection.Open();
                result = true;
                connection.Close();
            }
            catch (MySqlException ex)
            {
                string e = ex.ToString();
                result = false;
            }
            return result;
        }
    }
}

