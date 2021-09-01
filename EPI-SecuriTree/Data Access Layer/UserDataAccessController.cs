using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class UserDataAccessController
    {
        //This class managaes all functions related to users.

        public DataSet ValidateUser(string username)
        {
            DataSet ds = new DataSet();          
            using (SqlConnection con = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree"))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.CommandText = $"SELECT * FROM Registered_Users WHERE Username = '{username}'";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                }
            }

            return ds;
        }

        //Inserts a user into the database.
        public void InsertUser(User user)
        {
            Encryptor en = new Encryptor();

            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
               
                cmd = new SqlCommand($"INSERT INTO Registered_Users (Username,FirstName,Surname,Password) VALUES ('{user.Username}','{user.First_name}','{user.Surname}','{en.EncryptMD5(user.Password)}');", conn);
                cmd.ExecuteNonQuery();
                
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
        }
    }
}
