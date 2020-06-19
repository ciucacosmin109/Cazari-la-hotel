namespace Cazari_la_hotel {
    partial class MeniuPrincipal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeniuPrincipal));
            this.rezBtn = new System.Windows.Forms.Button();
            this.mgrBtn = new System.Windows.Forms.Button();
            this.mgrRezBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.instrumenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.iesireToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administrareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerRezervariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerCamereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.informatii = new Cazari_la_hotel.InformatiiUC();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rezBtn
            // 
            this.rezBtn.Image = global::Cazari_la_hotel.Properties.Resources.plus;
            this.rezBtn.Location = new System.Drawing.Point(12, 27);
            this.rezBtn.Name = "rezBtn";
            this.rezBtn.Size = new System.Drawing.Size(164, 38);
            this.rezBtn.TabIndex = 0;
            this.rezBtn.Text = "Rezervare &noua";
            this.rezBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rezBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rezBtn.UseVisualStyleBackColor = true;
            this.rezBtn.Click += new System.EventHandler(this.rezBtn_Click);
            // 
            // mgrBtn
            // 
            this.mgrBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mgrBtn.Image = global::Cazari_la_hotel.Properties.Resources.door;
            this.mgrBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mgrBtn.Location = new System.Drawing.Point(6, 68);
            this.mgrBtn.Name = "mgrBtn";
            this.mgrBtn.Size = new System.Drawing.Size(152, 41);
            this.mgrBtn.TabIndex = 1;
            this.mgrBtn.Text = "Manager de &camere";
            this.mgrBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mgrBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mgrBtn.UseVisualStyleBackColor = true;
            this.mgrBtn.Click += new System.EventHandler(this.mgrBtn_Click);
            // 
            // mgrRezBtn
            // 
            this.mgrRezBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mgrRezBtn.Image = ((System.Drawing.Image)(resources.GetObject("mgrRezBtn.Image")));
            this.mgrRezBtn.Location = new System.Drawing.Point(6, 21);
            this.mgrRezBtn.Name = "mgrRezBtn";
            this.mgrRezBtn.Size = new System.Drawing.Size(152, 41);
            this.mgrRezBtn.TabIndex = 2;
            this.mgrRezBtn.Text = "Manager de &rezervari";
            this.mgrRezBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mgrRezBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mgrRezBtn.UseVisualStyleBackColor = true;
            this.mgrRezBtn.Click += new System.EventHandler(this.mgrRezBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.mgrRezBtn);
            this.groupBox1.Controls.Add(this.mgrBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 115);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administrare";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despreToolStripMenuItem,
            this.toolStripSeparator1,
            this.iesireToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(27, 20);
            this.toolStripMenuItem1.Text = "&>";
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "despreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.despreToolStripMenuItem.Text = "&Despre";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.despreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.iesireToolStripMenuItem.Text = "&Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // chartBtn
            // 
            this.chartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chartBtn.Image = global::Cazari_la_hotel.Properties.Resources.chart;
            this.chartBtn.Location = new System.Drawing.Point(12, 114);
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(164, 41);
            this.chartBtn.TabIndex = 5;
            this.chartBtn.Text = "&Incasari grupate pe luna";
            this.chartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chartBtn.UseVisualStyleBackColor = true;
            this.chartBtn.Click += new System.EventHandler(this.chartBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumenteToolStripMenuItem,
            this.administrareToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(437, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // instrumenteToolStripMenuItem
            // 
            this.instrumenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despreToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.iesireToolStripMenuItem1});
            this.instrumenteToolStripMenuItem.Name = "instrumenteToolStripMenuItem";
            this.instrumenteToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.instrumenteToolStripMenuItem.Text = "&Instrumente";
            // 
            // despreToolStripMenuItem1
            // 
            this.despreToolStripMenuItem1.Name = "despreToolStripMenuItem1";
            this.despreToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.despreToolStripMenuItem1.Text = "&Despre";
            this.despreToolStripMenuItem1.Click += new System.EventHandler(this.despreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 6);
            // 
            // iesireToolStripMenuItem1
            // 
            this.iesireToolStripMenuItem1.Name = "iesireToolStripMenuItem1";
            this.iesireToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.iesireToolStripMenuItem1.Text = "&Iesire";
            this.iesireToolStripMenuItem1.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // administrareToolStripMenuItem
            // 
            this.administrareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managerRezervariToolStripMenuItem,
            this.managerCamereToolStripMenuItem});
            this.administrareToolStripMenuItem.Name = "administrareToolStripMenuItem";
            this.administrareToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.administrareToolStripMenuItem.Text = "&Administrare";
            // 
            // managerRezervariToolStripMenuItem
            // 
            this.managerRezervariToolStripMenuItem.Name = "managerRezervariToolStripMenuItem";
            this.managerRezervariToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.managerRezervariToolStripMenuItem.Text = "Manager &rezervari";
            this.managerRezervariToolStripMenuItem.Click += new System.EventHandler(this.mgrRezBtn_Click);
            // 
            // managerCamereToolStripMenuItem
            // 
            this.managerCamereToolStripMenuItem.Name = "managerCamereToolStripMenuItem";
            this.managerCamereToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.managerCamereToolStripMenuItem.Text = "Manager &camere";
            this.managerCamereToolStripMenuItem.Click += new System.EventHandler(this.mgrBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 279);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(437, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // informatii
            // 
            this.informatii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.informatii.Location = new System.Drawing.Point(182, 27);
            this.informatii.Name = "informatii";
            this.informatii.Size = new System.Drawing.Size(243, 249);
            this.informatii.TabIndex = 9;
            // 
            // MeniuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 301);
            this.Controls.Add(this.informatii);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rezBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chartBtn);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(445, 332);
            this.Name = "MeniuPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meniu principal";
            this.Activated += new System.EventHandler(this.MeniuPrincipal_Activated);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rezBtn;
        private System.Windows.Forms.Button mgrBtn;
        private System.Windows.Forms.Button mgrRezBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.Button chartBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem instrumenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administrareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerRezervariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerCamereToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private InformatiiUC informatii;
    }
}