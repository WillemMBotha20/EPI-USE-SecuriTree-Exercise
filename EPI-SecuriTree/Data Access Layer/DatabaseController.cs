using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace EPI_SecuriTree
{
    class DatabaseController
    {
        JsonController con = new JsonController();
        Encryptor enc = new Encryptor();        

        public void CreateUserTable()
        {   
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                SqlCommand cmd = new SqlCommand($"CREATE TABLE Registered_Users (Username varchar(100),FirstName varchar(100),Surname varchar(100),Password varchar(100));", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully...");                
                try
                {                         
                    foreach (var item in con.UserData())
                    {
                        cmd = new SqlCommand($"INSERT INTO Registered_Users (Username,FirstName,Surname,Password) VALUES ('{ item.Username}','{item.First_name}','{item.Surname}','{enc.EncryptMD5(item.Password)}');", conn);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }            
        }

        //Creates the database on startup.

        public void CreateDatabase()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=true;Database=");

            str = "CREATE DATABASE SecuriTree";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {

                //If database exists do nothing, else throw error.

                if (ex.Message.ToString() != "Database 'SecuriTree' already exists. Choose a different database name.")
                {
                    MessageBox.Show(ex.GetType().Namespace.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
