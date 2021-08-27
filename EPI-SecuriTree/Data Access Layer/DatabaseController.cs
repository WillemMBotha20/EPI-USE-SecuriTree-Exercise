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
        System_Data data = new System_Data();

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
            data = con.ReadAreaData(); 

            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                List<string> tables = new List<string>();

                //Creating and inserting Areas
                tables.Add("CREATE TABLE areas (  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60), )");
                
                //Making a seperate table for Child Areas
                tables.Add("CREATE TABLE childareas (  id VARCHAR(60) FOREIGN KEY REFERENCES areas,  parent_area_id VARCHAR(60) FOREIGN KEY REFERENCES areas(id) )");
               
                //Creating and inserting Doors
                tables.Add("CREATE TABLE doors(  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60),  parent_area_id VARCHAR(60) FOREIGN KEY REFERENCES areas(id),  doorstatus VARCHAR(60) )");
                
                //Creating and inserting Access Rules
                tables.Add("CREATE TABLE access_rules(  id VARCHAR(60) PRIMARY KEY,  name VARCHAR(60), )");
               
                //Creating and inserting Access Rules
                tables.Add("CREATE TABLE access_rule( access_rules_id VARCHAR(60) FOREIGN KEY REFERENCES access_rules(id),  doorid VARCHAR(60) FOREIGN KEY REFERENCES doors(id) ) ");
               
                foreach (var item in tables)
                {
                    cmd = new SqlCommand(item,conn);
                    cmd.ExecuteNonQuery();
                }


                InsertAreas(data.Areas); 
                InsertChildAreas(data.Areas);
                InsertDoors(data.Doors); 
                InsertRules(data.Rules); 
                InsertDoorRules(data.Rules);

                Console.WriteLine("Tables Created Successfully...");                
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }      

        public void InsertDoors(List<Door> doors)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                foreach (var item in doors)
                {
                    cmd = new SqlCommand($"INSERT INTO doors (id,name,parent_area_id,doorstatus) VALUES ('{ item.Id}','{item.Name}','{item.PrivateArea}','{item.Status}');", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();            
               
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void InsertAreas(List<Area> areas)
        {

            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                foreach (var item in areas)
                {
                    cmd = new SqlCommand($"INSERT INTO areas (id,name) VALUES ('{ item.Id}','{item.Name}');", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void InsertChildAreas(List<Area> areas)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                foreach (var item in areas)
                {
                    foreach (var item2 in item.Child_area_ids)
                    {
                        cmd = new SqlCommand($"INSERT INTO childareas (id,parent_area_id) VALUES ('{item2.ToString()}','{item.Id}');", conn);
                        cmd.ExecuteNonQuery();
                    }                   
                    
                }
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void InsertRules(List<AccessRules> rules)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                foreach (var item in rules)
                {                   
                    cmd = new SqlCommand($"INSERT INTO access_rules (id,name) VALUES ('{item.Id}','{item.Name}');", conn);
                    cmd.ExecuteNonQuery();                  
                }
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void InsertDoorRules(List<AccessRules> rules)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                foreach (var item in rules)
                {
                    foreach (var item2 in item.Doors)
                    {
                        cmd = new SqlCommand($"INSERT INTO access_rule (access_rules_id,doorid) VALUES ('{item.Id}','{item2}');", conn);
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void ManageDoorStatusTrue(string doorId)
        {          
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();             
                cmd = new SqlCommand($"UPDATE doors SET doorstatus = 'closed' WHERE id = '{doorId}';", conn);
                cmd.ExecuteNonQuery();                 
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public void ManageDoorStatusFalse(string doorId)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand($"UPDATE doors SET doorstatus = 'open' WHERE id = '{doorId}';", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }

        public DataSet CheckDoorStatus(string doorId)
        {
            DataSet ds = new DataSet();

            try
            {               
                using (SqlConnection con = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree"))
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        con.Open();
                        command.CommandText = $"SELECT * FROM doors WHERE id = '{doorId}';";
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }

            return ds;
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
