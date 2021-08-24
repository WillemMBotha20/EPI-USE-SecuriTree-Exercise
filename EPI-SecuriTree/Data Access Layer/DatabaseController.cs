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

        public void AreasTables()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                List<string> tables = new List<string>();

                tables.Add("CREATE TABLE areas (  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60), )");
                tables.Add("CREATE TABLE childareas (  id VARCHAR(60) FOREIGN KEY REFERENCES areas,  parent_area_id VARCHAR(60) FOREIGN KEY REFERENCES areas(id) )");
                tables.Add("CREATE TABLE doors(  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60),  parent_area_id VARCHAR(60) FOREIGN KEY REFERENCES areas(id),  doorstatus VARCHAR(60) )");
                tables.Add("CREATE TABLE access_rules(  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60), )");
                tables.Add("CREATE TABLE access_rule(  id VARCHAR(60) PRIMARY KEY,  access_rules_id VARCHAR(60) FOREIGN KEY REFERENCES access_rules(id),  doorid VARCHAR(60) FOREIGN KEY REFERENCES doors(id) ) ");

                foreach (var item in tables)
                {
                    cmd = new SqlCommand(item,conn);
                    cmd.ExecuteNonQuery();
                }
                
                Console.WriteLine("Tables Created Successfully...");                
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void ReadAreaData()
        {
            con.ReadAreaData();
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
