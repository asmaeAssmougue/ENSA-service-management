using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transparent_Form
{
    class StudentClass
    {
        DBconnect connect = new DBconnect();
        //create a function to add a new students to the database

        public void selectid()
        {
            //specialite
            //`id`='specialite'

        }
        //cne,fname, lname, phone,mail,gender,address,idspecialite,bdate,img
        public bool insertStudent(string cne, string fname, string lname, string phone, string mail, string gender, string address, int idspecialite, DateTime bdate, byte[] img)
        {
            //MySqlCommand c1 = new MySqlCommand("SELECT id FROM `specialite` WHERE nom='" + specialite + "'", connect.getconnection);
            //int specId = Convert.ToInt32(c1.ExecuteScalar());
            MySqlCommand command = new MySqlCommand("INSERT INTO `etudiant`(`cne`, `nom`, `prenom`, `tel`, `email`, `sexe`, `adresse`, `id_specialite`, `annee_bac`, `photo`) VALUES(@cne,@fn, @ln, @ph, @mail, @gd, @adr,@specId,@bac,@img)", connect.getconnection);
            //INSERT INTO `student`(`StdId`, `StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `cne`, `mail`, `Photo`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]','[value-8]','[value-9]','[value-10]')
            //
            //@fn, @ln, @bd, @gd, @ph, @adr, @cne,@mail,@img
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bac", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@cne", MySqlDbType.VarChar).Value = cne;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
            command.Parameters.Add("@specId", MySqlDbType.Int64).Value = idspecialite;

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
        public DataTable getStudentlist(MySqlCommand command)
        {
            command.Connection=connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getSpecialite(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        // Create a function to execute the count query(total, male , female)
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }
        //to get the total student
        public string totalStudent()
        {
            return exeCount("SELECT COUNT(*) FROM etudiant");
        }
        // to get the male student count
        public string maleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM etudiant WHERE `sexe`='Male'");
        }
        // to get the female student count
        public string femaleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM etudiant WHERE `sexe`='Female'");
        }
        //create a function search for student (first name, last name, address,cne,mail)
        public DataTable searchStudent(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `etudiant` WHERE CONCAT(`nom`, `prenom`, `email`, `id_specialite`) LIKE '%" + searchdata + "%'", connect.getconnection);
            //`cne`='[value-1]',`nom`='[value-2]',`prenom`='[value-3]',`tel`='[value-4]',`email`='[value-5]',`sexe`='[value-6]',`adresse`='[value-7]',`id_specialite`='[value-8]',`annee_bac`='[value-9]',`photo`='[value-10]'

            // `StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `cne`, `mail`, `Photo`, `id_specialite`
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE CONCAT(`StdFirstName`,`StdLastName`,`Address``, `cne`, `mail`,`id_specialite`) LIKE '%" + searchdata +"%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //create a function edit for student
        public bool updateStudent(string cne, string fname, string lname, string phone, string mail, string gender, string address, int idspecialite, DateTime bdate, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `etudiant` SET `cne`=@cne,`nom`=@fn,`prenom`=@ln,`tel`=@ph,`email`=@mail,`sexe`=@gd,`adresse`=@adr,`id_specialite`=@specId,`annee_bac`=@bd,`photo`=@img   WHERE `cne`= @cne", connect.getconnection);

            //UPDATE `student` SET `StdFirstName`=@fn,`StdLastName`=@ln,`Birthdate`=@bd,`Gender`=@gd,`Phone`=@ph,`Address`=@adr,',`cne`=@cne,`mail`=@mail,`Photo`=@img WHERE  `StdId`= @id", connect.getconnection
            //@id,@fn, @ln, @bd, @gd, @ph, @adr, @img
            //command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@cne", MySqlDbType.VarChar).Value = cne;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
            command.Parameters.Add("@specId", MySqlDbType.Int64).Value = idspecialite;

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
        public bool deleteStudent(string cne)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `etudiant` WHERE `cne`=@cne", connect.getconnection);

            //@cne
            command.Parameters.Add("@cne", MySqlDbType.VarChar).Value = cne;

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
