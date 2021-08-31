
namespace EPI_SecuriTree
{
    partial class ManageDoors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtDoorId = new System.Windows.Forms.TextBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.picbxDoor = new System.Windows.Forms.PictureBox();
            this.picbxLight = new System.Windows.Forms.PictureBox();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxLight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Orbitron", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1050, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.panel9.Controls.Add(this.btnExit);
            this.panel9.Location = new System.Drawing.Point(-4, -1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1090, 26);
            this.panel9.TabIndex = 9;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Russo One", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(997, 661);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtDoorId
            // 
            this.txtDoorId.Location = new System.Drawing.Point(400, 564);
            this.txtDoorId.Name = "txtDoorId";
            this.txtDoorId.Size = new System.Drawing.Size(262, 20);
            this.txtDoorId.TabIndex = 11;
            this.txtDoorId.TextChanged += new System.EventHandler(this.txtDoorId_TextChanged);
            this.txtDoorId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoorId_KeyPress);
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Russo One", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ForeColor = System.Drawing.Color.White;
            this.btnLock.Location = new System.Drawing.Point(400, 590);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(128, 41);
            this.btnLock.TabIndex = 12;
            this.btnLock.Text = "Lock Door";
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(214)))), ((int)(((byte)(160)))));
            this.btnUnlock.FlatAppearance.BorderSize = 0;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Font = new System.Drawing.Font("Russo One", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.ForeColor = System.Drawing.Color.White;
            this.btnUnlock.Location = new System.Drawing.Point(534, 590);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(128, 41);
            this.btnUnlock.TabIndex = 15;
            this.btnUnlock.Text = "Unlock Door";
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Lemon", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.Location = new System.Drawing.Point(503, 72);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(57, 17);
            this.lblStats.TabIndex = 17;
            this.lblStats.Text = "Status";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Lemon", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(500, 544);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(62, 17);
            this.lblId.TabIndex = 18;
            this.lblId.Text = "Door Id";
            // 
            // picbxDoor
            // 
            this.picbxDoor.Image = global::EPI_SecuriTree.Properties.Resources.Closed;
            this.picbxDoor.Location = new System.Drawing.Point(409, 182);
            this.picbxDoor.Name = "picbxDoor";
            this.picbxDoor.Size = new System.Drawing.Size(244, 354);
            this.picbxDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbxDoor.TabIndex = 14;
            this.picbxDoor.TabStop = false;
            // 
            // picbxLight
            // 
            this.picbxLight.Location = new System.Drawing.Point(490, 92);
            this.picbxLight.Name = "picbxLight";
            this.picbxLight.Size = new System.Drawing.Size(82, 78);
            this.picbxLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbxLight.TabIndex = 13;
            this.picbxLight.TabStop = false;
            // 
            // ManageDoors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 696);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.picbxDoor);
            this.Controls.Add(this.picbxLight);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.txtDoorId);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageDoors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageDoors";
            this.Load += new System.EventHandler(this.txtManageDoors_Load);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbxDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtDoorId;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.PictureBox picbxLight;
        private System.Windows.Forms.PictureBox picbxDoor;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblId;
    }
}