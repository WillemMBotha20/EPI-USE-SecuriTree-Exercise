﻿using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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
    }
}
