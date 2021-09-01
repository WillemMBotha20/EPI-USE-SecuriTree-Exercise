using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPI_SecuriTree
{
    class LoginController
    {
        //Login manager
        //Meaning that this class validates all the input from the login screen.

        readonly UserDataAccessController userCon = new UserDataAccessController();
        readonly Encryptor enc = new Encryptor();
        readonly UserManager um = new UserManager();

        //Validates user input
        public void Validate(string username,string password, Form temp)
        {
            DataSet ds = userCon.ValidateUser(username);            

            if (username == string.Empty) {
                MessageBox.Show("Please Enter a Username!");
            }
            else if(ds.Tables.Count == 1)
            {
                try
                {
                    if (username == ds.Tables[0].Rows[0]["Username"].ToString())
                    {
                        string hash = ds.Tables[0].Rows[0]["Password"].ToString();

                        if (enc.EncryptMD5(password) == hash)
                        {
                            Dashboard dash = new Dashboard();
                            um.SerializeUser(ds.Tables[0].Rows[0]["FirstName"].ToString(), ds.Tables[0].Rows[0]["Surname"].ToString());
                            dash.Show();
                            temp.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password!");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong Username!");
                }
            }  
        }
    }
}
