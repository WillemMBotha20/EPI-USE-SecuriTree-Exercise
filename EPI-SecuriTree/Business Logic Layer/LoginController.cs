using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPI_SecuriTree
{
    class LoginController
    {
        UserDataAccessController userCon = new UserDataAccessController();
        Encryptor enc = new Encryptor();

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
