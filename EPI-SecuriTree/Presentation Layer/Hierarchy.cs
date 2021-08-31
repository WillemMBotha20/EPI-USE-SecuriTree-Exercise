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
    public partial class Hierarchy : Form
    {
        public Hierarchy()
        {
            InitializeComponent();
        }
        HierarchyManager manager = new HierarchyManager();

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
    }
}
