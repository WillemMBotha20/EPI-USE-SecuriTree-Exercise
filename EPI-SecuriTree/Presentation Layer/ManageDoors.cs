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
    public partial class ManageDoors : Form
    {
        //Used this source code to make the rounded corners on the forms.
        //https://stackoverflow.com/questions/18822067/rounded-corners-in-c-sharp-windows-forms

        readonly DoorManager manager = new DoorManager();

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

        public ManageDoors()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            um.ClearCache();
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard frmDash = new Dashboard();
            frmDash.Show();
            this.Hide();
        }

        private void txtDoorId_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtManageDoors_Load(object sender, EventArgs e)
        {
            btnUnlock.Enabled = false;
            btnLock.Enabled = false;            
            picbxDoor.ImageLocation = @"Closed.png";
            picbxLight.ImageLocation = @"";
           
        }

        private void txtDoorId_TextChanged(object sender, EventArgs e)
        {
            if (txtDoorId.Text.Length != 36)
            {
                btnUnlock.Enabled = false;
                btnLock.Enabled = false;
                picbxLight.ImageLocation = @"Locked.png";
                picbxDoor.ImageLocation = @"Closed.png";

            }
            else
            {               
                if (manager.GetDoor(txtDoorId.Text) == true)
                {
                    btnLock.Enabled = true;
                    btnUnlock.Enabled = false;
                    lblId.Text = txtDoorId.Text;
                    picbxLight.ImageLocation = @"Unlocked.png";
                    picbxDoor.ImageLocation = @"Open.png";
                    lblId.Text = "open";

                }
                else
                {
                    picbxLight.ImageLocation = @"Locked.png";
                    btnUnlock.Enabled = true;
                    btnLock.Enabled = false;                    
                    lblId.Text = txtDoorId.Text;                   
                    picbxDoor.ImageLocation = @"Closed.png";
                    lblId.Text = "closed";
                }                          
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            manager.UnlockDoor(txtDoorId.Text);

            if (manager.GetDoor(txtDoorId.Text) == true)
            {
                btnLock.Enabled = true;
                btnUnlock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                picbxLight.ImageLocation = @"Unlocked.png";
                picbxDoor.ImageLocation = @"Open.png";
                lblId.Text = "open";
            }
            else
            {
                btnUnlock.Enabled = true;
                btnLock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                picbxLight.ImageLocation = @"Locked.png";
                picbxDoor.ImageLocation = @"Closed.png";
                lblId.Text = "closed";
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            manager.LockDoor(txtDoorId.Text);
            if (manager.GetDoor(txtDoorId.Text) == true)
            {
                btnLock.Enabled = true;
                btnUnlock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                picbxLight.ImageLocation = @"Unlocked.png";
                picbxDoor.ImageLocation = @"Open.png";
                lblId.Text = "open";
            }
            else
            {
                btnUnlock.Enabled = true;
                btnLock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                picbxLight.ImageLocation = @"Locked.png";
                picbxDoor.ImageLocation = @"Closed.png";
                lblId.Text = "closed";
            }
        }
    }
}
