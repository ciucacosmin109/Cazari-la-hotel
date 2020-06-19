namespace Cazari_la_hotel
{
    partial class RezervareNoua
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
            this.components = new System.ComponentModel.Container();
            this.nrBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.restituireDateTime = new System.Windows.Forms.DateTimePicker();
            this.rezervareDateTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cnpBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numeBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.info_etaj = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.info_pretNoapte = new System.Windows.Forms.Label();
            this.info_baieBuc = new System.Windows.Forms.Label();
            this.info_nrPers = new System.Windows.Forms.Label();
            this.info_nr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rezervaBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.info_pretTotal = new System.Windows.Forms.Label();
            this.printCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nrBox
            // 
            this.nrBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nrBox.FormattingEnabled = true;
            this.nrBox.Location = new System.Drawing.Point(53, 24);
            this.nrBox.Name = "nrBox";
            this.nrBox.Size = new System.Drawing.Size(84, 21);
            this.nrBox.TabIndex = 0;
            this.nrBox.SelectedIndexChanged += new System.EventHandler(this.nrBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nume:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.restituireDateTime);
            this.groupBox1.Controls.Add(this.rezervareDateTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perioada";
            // 
            // restituireDateTime
            // 
            this.restituireDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restituireDateTime.Location = new System.Drawing.Point(9, 45);
            this.restituireDateTime.Name = "restituireDateTime";
            this.restituireDateTime.Size = new System.Drawing.Size(154, 20);
            this.restituireDateTime.TabIndex = 1;
            // 
            // rezervareDateTime
            // 
            this.rezervareDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rezervareDateTime.Location = new System.Drawing.Point(9, 19);
            this.rezervareDateTime.Name = "rezervareDateTime";
            this.rezervareDateTime.Size = new System.Drawing.Size(154, 20);
            this.rezervareDateTime.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cnpBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numeBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Persoana";
            // 
            // cnpBox
            // 
            this.cnpBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cnpBox.Location = new System.Drawing.Point(50, 44);
            this.cnpBox.MaxLength = 13;
            this.cnpBox.Name = "cnpBox";
            this.cnpBox.Size = new System.Drawing.Size(113, 20);
            this.cnpBox.TabIndex = 5;
            this.cnpBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cnpBox_KeyPress);
            this.cnpBox.Validating += new System.ComponentModel.CancelEventHandler(this.cnpBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CNP :";
            // 
            // numeBox
            // 
            this.numeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numeBox.Location = new System.Drawing.Point(50, 22);
            this.numeBox.MaxLength = 100;
            this.numeBox.Name = "numeBox";
            this.numeBox.Size = new System.Drawing.Size(113, 20);
            this.numeBox.TabIndex = 3;
            this.numeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeBox_KeyPress);
            this.numeBox.Validating += new System.ComponentModel.CancelEventHandler(this.numeBox_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.info_etaj);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.nrBox);
            this.groupBox3.Controls.Add(this.info_pretNoapte);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.info_baieBuc);
            this.groupBox3.Controls.Add(this.info_nrPers);
            this.groupBox3.Controls.Add(this.info_nr);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(198, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 154);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selectare camera";
            // 
            // info_etaj
            // 
            this.info_etaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.info_etaj.Location = new System.Drawing.Point(102, 90);
            this.info_etaj.Name = "info_etaj";
            this.info_etaj.Size = new System.Drawing.Size(46, 13);
            this.info_etaj.TabIndex = 11;
            this.info_etaj.Text = "-";
            this.info_etaj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Etaj:";
            // 
            // info_pretNoapte
            // 
            this.info_pretNoapte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.info_pretNoapte.Location = new System.Drawing.Point(85, 129);
            this.info_pretNoapte.Name = "info_pretNoapte";
            this.info_pretNoapte.Size = new System.Drawing.Size(63, 13);
            this.info_pretNoapte.TabIndex = 9;
            this.info_pretNoapte.Text = "-";
            this.info_pretNoapte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // info_baieBuc
            // 
            this.info_baieBuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.info_baieBuc.Location = new System.Drawing.Point(102, 116);
            this.info_baieBuc.Name = "info_baieBuc";
            this.info_baieBuc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.info_baieBuc.Size = new System.Drawing.Size(46, 13);
            this.info_baieBuc.TabIndex = 8;
            this.info_baieBuc.Text = "-";
            this.info_baieBuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // info_nrPers
            // 
            this.info_nrPers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.info_nrPers.Location = new System.Drawing.Point(102, 103);
            this.info_nrPers.Name = "info_nrPers";
            this.info_nrPers.Size = new System.Drawing.Size(46, 13);
            this.info_nrPers.TabIndex = 7;
            this.info_nrPers.Text = "-";
            this.info_nrPers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // info_nr
            // 
            this.info_nr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.info_nr.Location = new System.Drawing.Point(102, 77);
            this.info_nr.Name = "info_nr";
            this.info_nr.Size = new System.Drawing.Size(46, 13);
            this.info_nr.TabIndex = 6;
            this.info_nr.Text = "-";
            this.info_nr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Pret pe noapte:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Baie/Bucatarie:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nr. persoane:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numar:";
            // 
            // rezervaBtn
            // 
            this.rezervaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rezervaBtn.Image = global::Cazari_la_hotel.Properties.Resources.form_min;
            this.rezervaBtn.Location = new System.Drawing.Point(198, 192);
            this.rezervaBtn.Name = "rezervaBtn";
            this.rezervaBtn.Size = new System.Drawing.Size(154, 28);
            this.rezervaBtn.TabIndex = 6;
            this.rezervaBtn.Text = "&Rezerva";
            this.rezervaBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rezervaBtn.UseVisualStyleBackColor = true;
            this.rezervaBtn.Click += new System.EventHandler(this.rezervaBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pret total:";
            // 
            // info_pretTotal
            // 
            this.info_pretTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.info_pretTotal.AutoSize = true;
            this.info_pretTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.info_pretTotal.Location = new System.Drawing.Point(253, 176);
            this.info_pretTotal.Name = "info_pretTotal";
            this.info_pretTotal.Size = new System.Drawing.Size(13, 13);
            this.info_pretTotal.TabIndex = 13;
            this.info_pretTotal.Text = "0";
            // 
            // printCheckBox
            // 
            this.printCheckBox.AutoSize = true;
            this.printCheckBox.Checked = true;
            this.printCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.printCheckBox.Location = new System.Drawing.Point(9, 27);
            this.printCheckBox.Name = "printCheckBox";
            this.printCheckBox.Size = new System.Drawing.Size(112, 17);
            this.printCheckBox.TabIndex = 14;
            this.printCheckBox.Text = "Imprima document";
            this.printCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.printCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 48);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Altele";
            // 
            // RezervareNoua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 236);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.info_pretTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.rezervaBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(372, 267);
            this.Name = "RezervareNoua";
            this.Text = "Rezervare noua";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nrBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox cnpBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numeBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label info_pretNoapte;
        private System.Windows.Forms.Label info_baieBuc;
        private System.Windows.Forms.Label info_nrPers;
        private System.Windows.Forms.Label info_nr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button rezervaBtn;
        private System.Windows.Forms.DateTimePicker restituireDateTime;
        private System.Windows.Forms.DateTimePicker rezervareDateTime;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label info_etaj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label info_pretTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox printCheckBox;
    }
}

