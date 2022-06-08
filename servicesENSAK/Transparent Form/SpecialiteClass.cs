using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transparent_Form
{
    class SpecialiteClass
    {
        DBconnect connect = new DBconnect();
        //create a function to add a new students to the database

        public bool insertSpecialite(string nom, string niveau_etude)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `specialite`(`nom`, `niveau_etude`) VALUES(@nom, @niveau)", connect.getconnection);

            //@fn, @ln, @bd, @gd, @ph, @adr, @img
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@niveau", MySqlDbType.VarChar).Value = niveau_etude;

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
        public DataTable getSpecialite(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //create a update function for course edit
        public bool updateSpecialite(int id, string nom, String niveaux)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `specialite` SET`nom`=@cn,`niveau_etude`=@ch WHERE  `id`=@id", connect.getconnection);
            //@id,@cn,@ch,@desc
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@ch", MySqlDbType.VarChar).Value = niveaux;

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
        public bool deletSpecialite(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `specialite` WHERE `id`=@id", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
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
