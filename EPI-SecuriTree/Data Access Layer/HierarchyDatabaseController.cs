using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class HierarchyDatabaseController
    {
        public DataSet GetDoors(string id)
        {

            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree"))
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        con.Open();
                        command.CommandText = $"SELECT * FROM doors WHERE parent_area_id = '{id}';";
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while selecting:" + e.Message + "\t" + e.GetType());
            }

            return ds;
        }

        public DataSet GetChildren(string id)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree"))
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        con.Open();
                        command.CommandText = $"SELECT * FROM childareas WHERE parent_area_id = '{id}';";
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while selecting:" + e.Message + "\t" + e.GetType());
            }

            return ds;
        }

        public DataSet GetRules(string id)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection("Server=localhost;Integrated security=true;Database=SecuriTree"))
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        con.Open();
                        command.CommandText = $"SELECT DISTINCT * FROM access_rule WHERE doorid = '{id}';";
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while selecting:" + e.Message + "\t" + e.GetType());
            }

            return ds;
        }


    }
}
