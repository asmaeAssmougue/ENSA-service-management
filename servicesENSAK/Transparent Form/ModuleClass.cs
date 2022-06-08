using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transparent_Form
{
    internal class ModuleClass
    {

        DBconnect connect = new DBconnect();
        //create a function to add a new module to the database



        public bool InsertModule(String nom, String nom_prof, String prenom_prof)

        {
            /*connect.openConnect();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "SELECT cin_prof FROM `professeur` WHERE `nom`=@nom_prof AND `prenom`=@prenom_prof ";*/
            connect.openConnect();
            MySqlCommand cmdS = new MySqlCommand("SELECT cin FROM `professeur` WHERE nom = '" + @nom_prof + "' and prenom = '" + @prenom_prof + "'", connect.getconnection);

            object result = cmdS.ExecuteScalar();
            if (result == null || Convert.IsDBNull(result))
            {
                System.Windows.Forms.MessageBox.Show("une erreur est produite result null, réessayez", "Ajouter absence", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            



                String cin_prof = Convert.ToString(result);



                //MySqlCommand command1 = new MySqlCommand("SELECT cin_prof FROM `professeur` WHERE `nom`=@nom_prof AND `prenom`=@prenom_prof ", connect.getconnection);

                /* if (command1.ExecuteNonQuery() == 1)
                 {
                     connect.closeConnect();
                     return true;
                     String cin_prof =gettext(new MySqlCommand("SELECT cin_prof FROM `professeur` WHERE `nom`=@nom_prof AND `prenom`=@prenom_prof ", connect.getconnection););
                 }
                 else
                 {
                     connect.closeConnect();
                     return false;
                 }*/
                MySqlCommand command = new MySqlCommand("INSERT INTO `module`(`nom`, `cin_prof`) VALUES(@nom, @cin_prof)", connect.getconnection);

                command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
                command.Parameters.Add("@cin_prof", MySqlDbType.VarChar).Value = cin_prof;




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
    




        public DataTable getlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //create a function search for a module (nom module , cin prof)
        public DataTable searchmodule(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `module` WHERE CONCAT(`id`,`nom`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //create a function edit for module
        public bool updatemodule( int id, string nom, string cinprof)

        {
            connect.openConnect();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            MySqlCommand command = new MySqlCommand("UPDATE `module` SET `nom`=@nom,`cin_prof`=@cin_prof WHERE  `id`= @id", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@cin_prof", MySqlDbType.VarChar).Value = cinprof;
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
            public bool deletemodule(int id)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM `module` WHERE `id`=@id", connect.getconnection);

                //@id
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



