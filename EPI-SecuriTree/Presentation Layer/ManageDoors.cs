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
    public partial class txtManageDoors : Form
    {
        DoorManager manager = new DoorManager();

        public txtManageDoors()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
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
        }

        private void txtDoorId_TextChanged(object sender, EventArgs e)
        {
            if (txtDoorId.Text.Length != 36)
            {
                btnUnlock.Enabled = false;
                btnLock.Enabled = false;
            }
            else
            {               
                if (manager.GetDoor(txtDoorId.Text) == true)
                {
                    btnLock.Enabled = true;
                    btnUnlock.Enabled = false;
                    lblId.Text = txtDoorId.Text;
                    lblStatus.Text = "open";
                }
                else
                {
                    btnUnlock.Enabled = true;
                    btnLock.Enabled = false;
                    lblId.Text = txtDoorId.Text;
                    lblStatus.Text = "closed";
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
                lblStatus.Text = "open";
            }
            else
            {
                btnUnlock.Enabled = true;
                btnLock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                lblStatus.Text = "closed";
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
                lblStatus.Text = "open";
            }
            else
            {
                btnUnlock.Enabled = true;
                btnLock.Enabled = false;
                lblId.Text = txtDoorId.Text;
                lblStatus.Text = "closed";
            }
        }
    }
}
