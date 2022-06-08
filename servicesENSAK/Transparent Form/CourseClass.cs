using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Transparent_Form
{
    class CourseClass
    {
        DBconnect connect = new DBconnect();
        //create a function to insert course
        public bool insetCourse(int id_module, string cin_prof, int heure)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `cours`(`id_module`, `cin_prof`, `heure`) VALUES (@id_module,@cin_prof,@heure)", connect.getconnection);
            //@cn,@ch,@desc
            command.Parameters.Add("@id_module", MySqlDbType.Int32).Value = id_module ;
            command.Parameters.Add("@heure", MySqlDbType.Int32).Value = heure;
            command.Parameters.Add("@cin_prof", MySqlDbType.VarChar).Value = cin_prof;
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

        //create a function to get course list
        public DataTable getCourse(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //create a update function for course edit
        public bool updateCourse(int id_module, string cin_prof, int heure)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `cours` SET`id_module`=@id_module,`cin_prof`=@cin_prof,`heure`=@heure WHERE  `id_module`=@id_module", connect.getconnection);
            //@id,@cn,@ch,@desc
            command.Parameters.Add("@id_module", MySqlDbType.Int32).Value = id_module;
            command.Parameters.Add("@heure", MySqlDbType.Int32).Value = heure;
            command.Parameters.Add("@cin_prof", MySqlDbType.VarChar).Value = cin_prof;
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
        //Create a function to delete a course
        //we only need course id
        public bool deletCourse(int id_module)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `cours` WHERE `id_module`=@id_module", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id_module;
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
