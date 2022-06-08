using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transparent_Form
{
    class ProfesseurClass
    {
        DBconnect connect = new DBconnect();
        //create a function to add a new students to the database

        public bool insertProfesseur(string cin, string nom, string prenom, string tel, string email, string sexe, string mdp, string matiere, string titre)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `professeur`(`cin`, `nom`, `prenom`, `tel`, `email`, `sexe`, `mdp`,`matiere`,`titre`) VALUES(@cin, @nom, @prenom, @tel, @email, @sexe, @mdp,@matiere,@titre)", connect.getconnection);

            //@fn, @ln, @bd, @gd, @ph, @adr, @img
            command.Parameters.Add("@cin", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@sexe", MySqlDbType.VarChar).Value = sexe;
            command.Parameters.Add("@Mdp", MySqlDbType.VarChar).Value = mdp;
            command.Parameters.Add("@matiere", MySqlDbType.VarChar).Value = matiere;
            command.Parameters.Add("@titre", MySqlDbType.VarChar).Value = titre;

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
        // to get student table
        public DataTable getProfesseurlist(MySqlCommand command)
        {
            command.Connection=connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchProfesseur1(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `professeur` WHERE CONCAT(`nom`) LIKE '%"+ searchdata +"%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchProfesseur2(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `professeur` WHERE CONCAT(`prenom`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchProfesseur3(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `professeur` WHERE CONCAT(`matiere`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchProfesseur4(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `professeur` WHERE CONCAT(`sexe`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //create a function edit for student
        public bool updateProfesseur(string cin, string nom, string prenom, string tel, string email, string sexe, string mdp, string matiere, string titre)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `professeur` SET `cin`=@cin,`nom`=@nom,`prenom`=@prenom,`tel`=@tel,`email`=@email,`sexe`=@sexe,`mdp`=@Mdp , `matiere`=@matiere , `titre`=@titre WHERE  `cin`=@cin", connect.getconnection);

            //@id,@fn, @ln, @bd, @gd, @ph, @adr, @img
            command.Parameters.Add("@cin", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@sexe", MySqlDbType.VarChar).Value = sexe;
            command.Parameters.Add("@Mdp", MySqlDbType.VarChar).Value = mdp;
            command.Parameters.Add("@matiere", MySqlDbType.VarChar).Value = matiere;
            command.Parameters.Add("@titre", MySqlDbType.VarChar).Value = titre;

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
        //Create a function to delete data
        //we need only id 
        public bool deleteProfesseur(string cin)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `professeur` WHERE `cin`=@cin", connect.getconnection);

            //@id
            command.Parameters.Add("@cin", MySqlDbType.VarChar).Value = cin;
            
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
        // create a function for any command in studentDb
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
