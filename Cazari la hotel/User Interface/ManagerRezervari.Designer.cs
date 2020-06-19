namespace Cazari_la_hotel {
    partial class ManagerRezervari {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerRezervari));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preiaRezervarileDinBdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salveazaRezervarileInBdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.importaRezervariDinFisierExternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportaRezervariInFisierExternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervariLV = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operatiiRezervariContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stergeRezervareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.informatii = new Cazari_la_hotel.InformatiiUC();
            this.menuStrip.SuspendLayout();
            this.operatiiRezervariContextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(595, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preiaRezervarileDinBdToolStripMenuItem,
            this.salveazaRezervarileInBdToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importaRezervariDinFisierExternToolStripMenuItem,
            this.exportaRezervariInFisierExternToolStripMenuItem});
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dateToolStripMenuItem.Text = "&Date";
            // 
            // preiaRezervarileDinBdToolStripMenuItem
            // 
            this.preiaRezervarileDinBdToolStripMenuItem.Name = "preiaRezervarileDinBdToolStripMenuItem";
            this.preiaRezervarileDinBdToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.preiaRezervarileDinBdToolStripMenuItem.Text = "&Preia rezervarile din baza de date";
            this.preiaRezervarileDinBdToolStripMenuItem.Click += new System.EventHandler(this.preiaRezervarileDinBdToolStripMenuItem_Click);
            // 
            // salveazaRezervarileInBdToolStripMenuItem
            // 
            this.salveazaRezervarileInBdToolStripMenuItem.Name = "salveazaRezervarileInBdToolStripMenuItem";
            this.salveazaRezervarileInBdToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.salveazaRezervarileInBdToolStripMenuItem.Text = "&Salveaza rezervarile in baza de date";
            this.salveazaRezervarileInBdToolStripMenuItem.Click += new System.EventHandler(this.salveazaRezervarileInBdToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(253, 6);
            // 
            // importaRezervariDinFisierExternToolStripMenuItem
            // 
            this.importaRezervariDinFisierExternToolStripMenuItem.Name = "importaRezervariDinFisierExternToolStripMenuItem";
            this.importaRezervariDinFisierExternToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.importaRezervariDinFisierExternToolStripMenuItem.Text = "Importa rezervari din fisier extern";
            this.importaRezervariDinFisierExternToolStripMenuItem.Click += new System.EventHandler(this.importaRezervariDinFisierExternToolStripMenuItem_Click);
            // 
            // exportaRezervariInFisierExternToolStripMenuItem
            // 
            this.exportaRezervariInFisierExternToolStripMenuItem.Name = "exportaRezervariInFisierExternToolStripMenuItem";
            this.exportaRezervariInFisierExternToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.exportaRezervariInFisierExternToolStripMenuItem.Text = "Exporta rezervari in fisier extern";
            this.exportaRezervariInFisierExternToolStripMenuItem.Click += new System.EventHandler(this.exportaRezervariInFisierExternToolStripMenuItem_Click);
            // 
            // rezervariLV
            // 
            this.rezervariLV.AllowDrop = true;
            this.rezervariLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rezervariLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader2});
            this.rezervariLV.ContextMenuStrip = this.operatiiRezervariContextMenuStrip;
            this.rezervariLV.FullRowSelect = true;
            this.rezervariLV.GridLines = true;
            this.rezervariLV.HideSelection = false;
            this.rezervariLV.Location = new System.Drawing.Point(12, 27);
            this.rezervariLV.MultiSelect = false;
            this.rezervariLV.Name = "rezervariLV";
            this.rezervariLV.Size = new System.Drawing.Size(571, 211);
            this.rezervariLV.TabIndex = 6;
            this.rezervariLV.UseCompatibleStateImageBehavior = false;
            this.rezervariLV.View = System.Windows.Forms.View.Details;
            this.rezervariLV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rezervariLV_MouseMove);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 33;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr. camera";
            this.columnHeader1.Width = 64;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nume persoana";
            this.columnHeader7.Width = 88;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "CNP";
            this.columnHeader8.Width = 98;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Data rezervare";
            this.columnHeader9.Width = 87;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Data restituire";
            this.columnHeader10.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pret total";
            this.columnHeader2.Width = 92;
            // 
            // operatiiRezervariContextMenuStrip
            // 
            this.operatiiRezervariContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stergeRezervareaToolStripMenuItem});
            this.operatiiRezervariContextMenuStrip.Name = "operatiiRezervariContextMenuStrip";
            this.operatiiRezervariContextMenuStrip.Size = new System.Drawing.Size(164, 26);
            // 
            // stergeRezervareaToolStripMenuItem
            // 
            this.stergeRezervareaToolStripMenuItem.Name = "stergeRezervareaToolStripMenuItem";
            this.stergeRezervareaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.stergeRezervareaToolStripMenuItem.Text = "Sterge rezervarea";
            this.stergeRezervareaToolStripMenuItem.Click += new System.EventHandler(this.stergeRezervareaToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 391);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(595, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
            this.statusLabel.Text = "...";
            this.statusLabel.TextChanged += new System.EventHandler(this.statusLabel_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.Location = new System.Drawing.Point(447, 353);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(136, 35);
            this.newButton.TabIndex = 9;
            this.newButton.Text = "Rezervare noua";
            this.newButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.AllowDrop = true;
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(12, 353);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(189, 35);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Sterge rezervarea selectata";
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            this.deleteButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.deleteButton_DragDrop);
            this.deleteButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.deleteButton_DragEnter);
            // 
            // informatii
            // 
            this.informatii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.informatii.Location = new System.Drawing.Point(12, 244);
            this.informatii.Name = "informatii";
            this.informatii.Size = new System.Drawing.Size(571, 103);
            this.informatii.TabIndex = 10;
            // 
            // ManagerRezervari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 413);
            this.Controls.Add(this.informatii);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.rezervariLV);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(260, 183);
            this.Name = "ManagerRezervari";
            this.Text = "ManagerRezervari";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.operatiiRezervariContextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preiaRezervarileDinBdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salveazaRezervarileInBdToolStripMenuItem;
        private System.Windows.Forms.ListView rezervariLV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip operatiiRezervariContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stergeRezervareaToolStripMenuItem;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importaRezervariDinFisierExternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportaRezervariInFisierExternToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3; 
        private InformatiiUC informatii;
    }
}