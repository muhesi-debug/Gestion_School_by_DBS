using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace gestion_ecoles.controls
{
    public partial class Cl_Gestion_salle : UserControl
    {
        // Création de l'instance 
        //Cl_Gestion_salle salle = new Gestion_studient();
        models.Cl_calsse_et_option ajout = new models.Cl_calsse_et_option();
        models.connection conn = new models.connection();

        private static Cl_Gestion_salle cl_salle;

        public static Cl_Gestion_salle instance
        {
            get
            {
                if (cl_salle == null)
                {
                    cl_salle = new Cl_Gestion_salle();
                }
                return cl_salle;
            }


        }
        public Cl_Gestion_salle()
        {
            InitializeComponent();
            affichClasse();
            affichOption();
            btnModClasse.Visible = false;
            btnModOption.Visible = false;
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNomClasse_Enter(object sender, EventArgs e)
        {
            if (txtNomClasse.Text == "Description de la classe") txtNomClasse.Text = "";

        }

        private void txtNomClasse_Leave(object sender, EventArgs e)
        {
            if (txtNomClasse.Text == "") txtNomClasse.Text = "Description de la classe";
        }

        private void txtNomOption_Enter(object sender, EventArgs e)
        {
            if (txtNomOption.Text == "Description de l'option") txtNomOption.Text = "";
        }

        private void txtNomOption_Leave(object sender, EventArgs e)
        {
            if (txtNomOption.Text == "") txtNomOption.Text = "Description de l'option";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtAnneeScolaire_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtAnneeScolaire_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnAddOption_Click(object sender, EventArgs e)
        {
            if (ajout.ajouter_option(txtCodeOption.Text, txtNomOption.Text) ==true)
            {
                MessageBox.Show("Energistrement réussi");
            }
            else MessageBox.Show("Echec");
        }

        private void txtCodeClasse_Leave(object sender, EventArgs e)
        {
            if (txtCodeClasse.Text== "")
            {
                txtCodeClasse.Text = "Code de la classe";
            }
        }

        private void txtCodeClasse_Enter(object sender, EventArgs e)
        {
            if (txtCodeClasse.Text == "Code de la classe")
            {
                txtCodeClasse.Text = "";
            }
        }

        private void txtCodeOption_Leave(object sender, EventArgs e)
        {
            if (txtCodeOption.Text=="")
            {
                txtCodeOption.Text = "Code Option";
            }
        }

        private void txtCodeOption_Enter(object sender, EventArgs e)
        {
            if (txtCodeOption.Text == "Code Option")
            {
                txtCodeOption.Text = "";
            }
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            if (ajout.ajouter_classe(txtCodeClasse.Text, txtNomClasse.Text) == true)
            {
                MessageBox.Show("Energistrement réussi");
            }
            else MessageBox.Show("Echec");
        }

        void affichOption()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from options", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvOptions.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvOptions.Rows.Add(rd[0].ToString(),rd[1].ToString());

                }
                rd.Close();
                conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
        }


        void affichClasse()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from classes", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvClasses.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvClasses.Rows.Add(rd[0].ToString(), rd[1].ToString());

                }
                rd.Close();
                conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void sUPRIMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Suprimer Classe
            if (dgvClasses.CurrentRow != null)
            {
                // Index

                string index = dgvClasses.CurrentRow.Cells[0].Value.ToString();
                if (ajout.supprimeClasse(index) == true)
                {
                    MessageBox.Show("Suppression reussie");
                    affichClasse();
                }
                else
                {
                    MessageBox.Show("Echec");
                }
            }
        }

        private void aCTUALISERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Actualiser Classe
            affichClasse();
        }

        private void sUPRIMERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Suprimer Option
            if (dgvOptions.CurrentRow != null)
            {
                // Index

                string index = dgvOptions.CurrentRow.Cells[0].Value.ToString();
                if (ajout.supprimeOption(index) == true)
                {
                    MessageBox.Show("Suppression reussie");
                    affichOption();
                }
                else
                {
                    MessageBox.Show("Echec");
                }
            }
        }

        private void aCTUALSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Actualiser Option 
            affichOption();
        }

        private void btnModClasse_Click(object sender, EventArgs e)
        {
            if (ajout.modiClasse(txtCodeClasse.Text, txtNomClasse.Text) == true)
            {
                MessageBox.Show("modification reussie");
                txtCodeClasse.Enabled = true;
                txtCodeClasse.Text = "Code de la classe";
                txtNomClasse.Text = "Description de la classe";
                btnAddClasse.Visible = true;
                btnModClasse.Visible = false;
                affichClasse();
            }
            else
            {
                MessageBox.Show("Echec");
            }


        }

        private void mODIFIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow != null)
            {
                // Index
                btnAddClasse.Visible = false;
                btnModClasse.Visible = true;
                txtCodeClasse.Enabled = false;

                txtCodeClasse.Text = dgvClasses.CurrentRow.Cells[0].Value.ToString();
                txtNomClasse.Text= dgvClasses.CurrentRow.Cells[1].Value.ToString();
               
            }
        }

        private void mODIFIERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvOptions.CurrentRow != null)
            {
                // Index
                btnAddOption.Visible = false;
                btnModOption.Visible = true;
                txtCodeOption.Enabled = false;

                txtCodeOption.Text = dgvOptions.CurrentRow.Cells[0].Value.ToString();
                txtNomOption.Text = dgvOptions.CurrentRow.Cells[1].Value.ToString();
               
            }
        }

        private void btnModOption_Click(object sender, EventArgs e)
        {
           
            if (ajout.modiOption(txtCodeOption.Text, txtNomOption.Text) == true)
            {
                MessageBox.Show("Suppression reussie");
                txtCodeOption.Enabled = true;
                txtCodeOption.Text = "Code Option";
                txtNomOption.Text = "Description de l'option";
                btnAddOption.Visible = true;
                btnModOption.Visible = false;
                affichOption();
            }
            else
            {
                MessageBox.Show("Echec");
            }
        }
    }
}
