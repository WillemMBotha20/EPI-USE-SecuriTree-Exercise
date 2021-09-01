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
    public partial class Hierarchy : Form
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

        public Hierarchy()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        readonly HierarchyManager manager = new HierarchyManager();

        private void Hierarchy_Load(object sender, EventArgs e)
        {
            manager.CreateHiercy(trvHier);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard frmDash = new Dashboard();
            frmDash.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            um.ClearCache();
            Application.Exit();
        }

        private void trvHier_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
