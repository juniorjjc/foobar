using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FirstAppCS
{
    class Connection
    {

        public Connection() {
            this.server = "localhost";
            this.database = "expediente";
            this.uid = "root";
            this.password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            this.connection = new MySqlConnection(connectionString);         
        }
    
        public MySqlConnection getConnection() {
            return connection;
        }

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        
    }

    
}
