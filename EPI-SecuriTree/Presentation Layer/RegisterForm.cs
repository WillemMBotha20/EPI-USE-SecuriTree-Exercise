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
    public partial class RegisterForm : Form
    {

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
        public RegisterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            LoginScreen log = new LoginScreen();
            log.Show();
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            LoginScreen log = new LoginScreen();

            try
            {
                if (txtUsername.Text != string.Empty && txtFirstName.Text != string.Empty && txtSurname.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    um.InsertUser(txtUsername.Text, txtFirstName.Text, txtSurname.Text, txtPassword.Text);
                    log.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields!");
                }
            }
            catch (Exception)
            {

                
            }                  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginScreen log = new LoginScreen();
            log.Show();
            this.Hide();
        }
    }
}
