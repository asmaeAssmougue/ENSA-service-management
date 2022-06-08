using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Transparent_Form
{
    class Absence
    {
        DBconnect connect = new DBconnect();
        //create a function to insert abs
        public bool insertAbsence(string cne, string cinP, string nomM, int nbrAb)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `abscence`(`cne_student`, `cin_prof`, `module`, `nb_absence`) VALUES (@cne,@cinP,@nomM,@nbrAb)", connect.getconnection);
            //@cn,@ch,@desc
            command.Parameters.Add("@cne", MySqlDbType.VarChar).Value = cne;
            command.Parameters.Add("@cinP", MySqlDbType.VarChar).Value = cinP;
            command.Parameters.Add("@nomM", MySqlDbType.VarChar).Value = nomM;
            command.Parameters.Add("@nbrAb", MySqlDbType.Int32).Value = nbrAb;
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
        public DataTable GetAbsence(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getModule(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //create a update function for course edit
        public bool updateAbsence(string cne, string cinP, string nomM, int nbrAb)
        {
            
            MySqlCommand command = new MySqlCommand("UPDATE `abscence` SET `cin_prof`=@cin,`module`=@nom,`nb_absence`=@nbrA  WHERE  `cne_student`=@cneS", connect.getconnection);
            //
            command.Parameters.Add("@cin", MySqlDbType.VarChar).Value = cinP;
            command.Parameters.Add("@cneS", MySqlDbType.VarChar).Value = cne;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nomM;
            command.Parameters.Add("@nbrA", MySqlDbType.Int32).Value = nbrAb;
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
