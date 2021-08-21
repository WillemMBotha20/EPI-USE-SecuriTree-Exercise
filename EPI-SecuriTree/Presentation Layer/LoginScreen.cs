using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPI_SecuriTree
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController login = new LoginController();
            login.Validate(txtUsername.Text,txtPassword.Text,this);
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            OnStartUpController startObj = new OnStartUpController();
            startObj.StartUpDatabase();
        }
    }
}
