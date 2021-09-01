using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPI_SecuriTree
{
    public partial class LoginScreen : Form
    {
        //Used this source code to make the rounded corners on the forms.

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        public LoginScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
            UserManager um = new UserManager();
            um.ClearCache();
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
            UserManager um = new UserManager();
            um.ClearCache();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }
    }
}
