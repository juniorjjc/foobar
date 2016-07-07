using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppCS
{
    class DAOclass
    {
        public List<Mats> getAllMats() {
            Mats mat = null;
            List<Mats> mats = new List<Mats>();
            string callableStatement = "call lista_materias";
            MySqlCommand cmd = new MySqlCommand(callableStatement, connection.getConnection());

            connection.getConnection().Open();
            
            MySqlDataReader resultSet = cmd.ExecuteReader();
            while (resultSet.Read()) {
                mat = new Mats();
                int nrc = resultSet.GetInt32(0);
                string asignatura = resultSet.GetString(1);
                int creditos = resultSet.GetInt32(2);
                string modalidad = resultSet.GetString(3);
                int periodo = resultSet.GetInt32(4);
                mat.Nrc = nrc;
                mat.Asignatura = asignatura;
                mat.Creditos = creditos;
                mat.Modalidad = modalidad;
                mat.Periodo = periodo;
                mats.Add(mat);
            }

            return mats;
        }

        private static Connection connection = new Connection();
    }
}
