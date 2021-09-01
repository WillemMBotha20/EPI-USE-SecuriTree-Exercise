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
    public partial class Dashboard : Form
    {

        //Used this source code to make the rounded corners on the forms.
        //https://stackoverflow.com/questions/18822067/rounded-corners-in-c-sharp-windows-forms

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

        readonly UserManager um = new UserManager();

        public Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            um.ClearCache();
        }

        private void btnManageDoors_Click(object sender, EventArgs e)
        {
            ManageDoors frmDoors = new ManageDoors();
            frmDoors.Show();
            this.Hide();
        }

        private void btnHier_Click(object sender, EventArgs e)
        {
            Hierarchy frmHier = new Hierarchy();
            frmHier.Show();
            this.Hide();
        }

        //On the dashboar load it fills in all the features that the dashboard provides.

        private void Dashboard_Load(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            HierarchyManager man = new HierarchyManager();
            List<string> temp = man.GetCount();

            lblUn.Text = temp[0];
            lblLock.Text = temp[1]; 
            lblTotal.Text = temp[2];

            lblUser.Text = um.DeserializeUser();
        }

        //Logs out of the application.

        private void button3_Click(object sender, EventArgs e)
        {
            um.ClearCache();
            LoginScreen log = new LoginScreen();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
