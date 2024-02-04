namespace gestion_ecoles.controls
{
    partial class Gestion_agents
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAgent = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbChoix = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtReseach = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnClient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sUPRIMERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mODIFIERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAgent
            // 
            this.dgvAgent.AllowUserToAddRows = false;
            this.dgvAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvAgent.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvAgent.EnableHeadersVisualStyles = false;
            this.dgvAgent.Location = new System.Drawing.Point(-1, 203);
            this.dgvAgent.Name = "dgvAgent";
            this.dgvAgent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAgent.RowHeadersVisible = false;
            this.dgvAgent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAgent.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAgent.Size = new System.Drawing.Size(1086, 343);
            this.dgvAgent.TabIndex = 51;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Matricule";
            this.Column9.Name = "Column9";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Noms";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Genre";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Fonction";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Grade";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Téléphone";
            this.Column8.Name = "Column8";
            // 
            // cmbChoix
            // 
            this.cmbChoix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbChoix.BackColor = System.Drawing.SystemColors.Window;
            this.cmbChoix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbChoix.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChoix.FormattingEnabled = true;
            this.cmbChoix.Items.AddRange(new object[] {
            "Nom",
            "Postnom",
            "Prenom",
            "Email",
            "Téléphone"});
            this.cmbChoix.Location = new System.Drawing.Point(213, 135);
            this.cmbChoix.Name = "cmbChoix";
            this.cmbChoix.Size = new System.Drawing.Size(199, 28);
            this.cmbChoix.TabIndex = 50;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(445, 161);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(268, 2);
            this.panel7.TabIndex = 49;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel8.Location = new System.Drawing.Point(0, 59);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(997, 5);
            this.panel8.TabIndex = 10;
            // 
            // txtReseach
            // 
            this.txtReseach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtReseach.BackColor = System.Drawing.SystemColors.Window;
            this.txtReseach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReseach.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReseach.ForeColor = System.Drawing.Color.DimGray;
            this.txtReseach.Location = new System.Drawing.Point(445, 137);
            this.txtReseach.Multiline = true;
            this.txtReseach.Name = "txtReseach";
            this.txtReseach.Size = new System.Drawing.Size(268, 25);
            this.txtReseach.TabIndex = 48;
            this.txtReseach.Text = "Recherche ......................";
            this.txtReseach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReseach.TextChanged += new System.EventHandler(this.txtReseach_TextChanged);
            this.txtReseach.Enter += new System.EventHandler(this.txtReseach_Enter);
            this.txtReseach.Leave += new System.EventHandler(this.txtReseach_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(57, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 3);
            this.panel2.TabIndex = 47;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Orange;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(997, 5);
            this.panel5.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel6.Location = new System.Drawing.Point(0, 59);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(997, 5);
            this.panel6.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 5);
            this.panel4.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.Orange;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(57, 120);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(997, 3);
            this.panel9.TabIndex = 46;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.panel10.Location = new System.Drawing.Point(0, 59);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(997, 5);
            this.panel10.TabIndex = 10;
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(57, 50);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(226, 38);
            this.btnClient.TabIndex = 45;
            this.btnClient.Text = "AJOUTER";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 35);
            this.panel1.TabIndex = 53;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sUPRIMERToolStripMenuItem,
            this.mODIFIERToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(160, 52);
            // 
            // sUPRIMERToolStripMenuItem
            // 
            this.sUPRIMERToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sUPRIMERToolStripMenuItem.Name = "sUPRIMERToolStripMenuItem";
            this.sUPRIMERToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.sUPRIMERToolStripMenuItem.Text = "SUPRIMER";
            this.sUPRIMERToolStripMenuItem.Click += new System.EventHandler(this.sUPRIMERToolStripMenuItem_Click);
            // 
            // mODIFIERToolStripMenuItem
            // 
            this.mODIFIERToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mODIFIERToolStripMenuItem.Name = "mODIFIERToolStripMenuItem";
            this.mODIFIERToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.mODIFIERToolStripMenuItem.Text = "MODIFIER";
            this.mODIFIERToolStripMenuItem.Click += new System.EventHandler(this.mODIFIERToolStripMenuItem_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(482, 60);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(20, 20);
            this.txtid.TabIndex = 56;
            this.txtid.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(828, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 38);
            this.button1.TabIndex = 57;
            this.button1.Text = "ACTUALISER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Gestion_agents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvAgent);
            this.Controls.Add(this.cmbChoix);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.txtReseach);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.btnClient);
            this.Name = "Gestion_agents";
            this.Size = new System.Drawing.Size(1084, 549);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAgent;
        private System.Windows.Forms.ComboBox cmbChoix;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtReseach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        public System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem sUPRIMERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mODIFIERToolStripMenuItem;
        private System.Windows.Forms.TextBox txtid;
        public System.Windows.Forms.Button button1;
    }
}
