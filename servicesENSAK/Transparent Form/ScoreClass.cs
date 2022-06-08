using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transparent_Form
{
    class ScoreClass
    {
        DBconnect connect = new DBconnect();
        //create a function add score
        public bool insertNote(string idEtudiant, int idModule, double cc1, double cc2, double exam)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `notee`(`idEtudiant`, `idModule`,`cc1`,`cc2`,`exam`) VALUES (@idEtudiant,@idModule,@cc1,@cc2,@exam)", connect.getconnection);
            //@stid,@cn,@sco,@desc
            command.Parameters.Add("@cc1", MySqlDbType.Double).Value = cc1;
            command.Parameters.Add("@cc2", MySqlDbType.Double).Value = cc2;
            command.Parameters.Add("@exam", MySqlDbType.Double).Value = exam;
            command.Parameters.Add("@idEtudiant", MySqlDbType.VarChar).Value = idEtudiant;
            command.Parameters.Add("@idModule", MySqlDbType.Int32).Value = idModule;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        //create a functon to get list
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // create a function to check already course score
        public bool checkScore(int idModule, string idEtudiant)
        {
            DataTable table = getList(new MySqlCommand("SELECT * FROM `notee` WHERE `idEtudiant`= '" + idEtudiant + "' AND `idModule`= '" + idModule + "'"));
            if (table.Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        // Create A function to edit score data
        public bool updateNote(string idEtudiant, int idModule, double cc1, double cc2, double exam)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `notee` SET `cc1`=@cc1,`cc2`=@cc2 , `exam`=@exam  WHERE `idEtudiant`=@idEtudiant AND `idModule`=@idModule", connect.getconnection);
            //@stid,@sco,@desc
            command.Parameters.Add("@cc1", MySqlDbType.Double).Value = cc1;
            command.Parameters.Add("@cc2", MySqlDbType.Double).Value = cc2;
            command.Parameters.Add("@exam", MySqlDbType.Double).Value = exam;
            command.Parameters.Add("@idEtudiant", MySqlDbType.VarChar).Value = idEtudiant;
            command.Parameters.Add("@idModule", MySqlDbType.Int32).Value = idModule;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        //Create a function to delete a score data
        public bool deleteNote(string idEtudiant)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `note` WHERE `idEtudiant`=@idEtudiant", connect.getconnection);

            //@id
            command.Parameters.Add("@idEtudiant", MySqlDbType.VarChar).Value = idEtudiant;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }


        
    }
}
