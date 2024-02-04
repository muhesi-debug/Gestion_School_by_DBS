namespace gestion_ecoles.view
{
    partial class frmbackupdatabase
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
            this.btnSaveDialog = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnStartBackUp = new System.Windows.Forms.Button();
            this.lblTitreBackUp = new System.Windows.Forms.Label();
            this.btnrestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveDialog
            // 
            this.btnSaveDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDialog.FlatAppearance.BorderSize = 0;
            this.btnSaveDialog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveDialog.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDialog.Location = new System.Drawing.Point(63, 63);
            this.btnSaveDialog.Name = "btnSaveDialog";
            this.btnSaveDialog.Size = new System.Drawing.Size(374, 28);
            this.btnSaveDialog.TabIndex = 9;
            this.btnSaveDialog.Text = "Choisir un emplacement d\'enregistrement";
            this.btnSaveDialog.UseVisualStyleBackColor = true;
            this.btnSaveDialog.Click += new System.EventHandler(this.btnSaveDialog_Click);
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblPath.Location = new System.Drawing.Point(21, 133);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(359, 48);
            this.lblPath.TabIndex = 10;
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartBackUp
            // 
            this.btnStartBackUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartBackUp.BackColor = System.Drawing.Color.Transparent;
            this.btnStartBackUp.Enabled = false;
            this.btnStartBackUp.FlatAppearance.BorderSize = 0;
            this.btnStartBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartBackUp.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 24F);
            this.btnStartBackUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStartBackUp.Location = new System.Drawing.Point(63, 234);
            this.btnStartBackUp.Name = "btnStartBackUp";
            this.btnStartBackUp.Size = new System.Drawing.Size(368, 56);
            this.btnStartBackUp.TabIndex = 11;
            this.btnStartBackUp.Text = "DEBUTER";
            this.btnStartBackUp.UseVisualStyleBackColor = false;
            this.btnStartBackUp.Click += new System.EventHandler(this.btnStartBackUp_Click);
            // 
            // lblTitreBackUp
            // 
            this.lblTitreBackUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitreBackUp.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreBackUp.Location = new System.Drawing.Point(65, 9);
            this.lblTitreBackUp.Name = "lblTitreBackUp";
            this.lblTitreBackUp.Size = new System.Drawing.Size(372, 30);
            this.lblTitreBackUp.TabIndex = 12;
            this.lblTitreBackUp.Text = "Backup MySql BD";
            // 
            // btnrestore
            // 
            this.btnrestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrestore.BackColor = System.Drawing.Color.Transparent;
            this.btnrestore.Enabled = false;
            this.btnrestore.FlatAppearance.BorderSize = 0;
            this.btnrestore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnrestore.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 24F);
            this.btnrestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnrestore.Location = new System.Drawing.Point(63, 305);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(368, 56);
            this.btnrestore.TabIndex = 13;
            this.btnrestore.Text = "RESTORE";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmbackupdatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 373);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.lblTitreBackUp);
            this.Controls.Add(this.btnStartBackUp);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnSaveDialog);
            this.Name = "frmbackupdatabase";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnSaveDialog;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblTitreBackUp;
        private System.Windows.Forms.Button btnrestore;
        protected System.Windows.Forms.Button btnStartBackUp;

        #endregion

        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}