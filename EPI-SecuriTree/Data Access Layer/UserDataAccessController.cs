﻿using System;
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
    }
}