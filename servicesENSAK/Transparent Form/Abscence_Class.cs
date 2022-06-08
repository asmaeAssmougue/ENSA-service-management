using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transparent_Form
{
    internal class Abscence_Class
    {
        DBconnect connect = new DBconnect();
        public DataTable getlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
       
        /* public string Id_etud ()
         {
             string id_etudiant = Static_class.UserID;
             return id_etudiant;
         }*/
    }
}
