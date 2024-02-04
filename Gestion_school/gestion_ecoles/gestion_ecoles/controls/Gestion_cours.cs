using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace gestion_ecoles.controls
{
    public partial class Gestion_cours : UserControl
    {
        // Création de l'instance 
        //Gestion_cours student = new Gestion_cours();
        models.Cl_cours cours = new models.Cl_cours();
        models.connection conn = new models.connection();

        private static Gestion_cours cl_cours;

        public static Gestion_cours instance
        {
            get
            {
                if (cl_cours == null)
                {
                    cl_cours = new Gestion_cours();
                }
                return cl_cours;
            }


        }
        public Gestion_cours()
        {
            InitializeComponent();
            afficher("");
            
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text== "Recherche ......................") txtReseach.Text = "";
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text=="") txtReseach.Text = "Recherche ......................";
        }

        private void txtNomCours_Enter(object sender, EventArgs e)
        {
            if (txtNomCours.Text== "Description de Cours") txtNomCours.Text = "";
        }

        private void txtNomCours_Leave(object sender, EventArgs e)
        {
            if (txtNomCours.Text=="") txtNomCours.Text = "Description de Cours";
        }

        private void aFFECTERCOURSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Affecter cours à la classe et option dans une année scolaire

            Formulaires.Affecter_cours afect = new Formulaires.Affecter_cours();

            // Récupération de la id du cours choisi
            if (dgvCours.CurrentRow != null)
            {
                // Index
                string index = dgvCours.CurrentRow.Cells[0].Value.ToString();
                afect.txtIdCours.Text = index;
                afect.txtCours.Text = dgvCours.CurrentRow.Cells[2].Value.ToString();
                afect.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Impression liste de cours dans une classe 
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Formulaires.Affecter_cours cours = new Formulaires.Affecter_cours();
            cours.ShowDialog();
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            if (txtNomCours.Text != "" && txtNomCours.Text != "Description de Cours")
            {
                if (cours.ajouet(txtNomCours.Text) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                }
                else MessageBox.Show("Echec d'enregistrement");
            }
            else MessageBox.Show("Remplisser le champ");
        }

        // Remplissage du datGriview
        void afficher(string recher)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `courses` WHERE descrption_cours LIKE '%" + recher+"%' ", conn.conndb);
            conn.conndb.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            dgvCours.Rows.Clear();
            while (rd.Read())
            {
                dgvCours.Rows.Add(rd[0].ToString(), rd[0].ToString(), rd[1].ToString());
            }rd.Close();
            conn.conndb.Close();

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCours.CurrentRow != null)
            {
                txtIdCours.Text =dgvCours.CurrentRow.Cells[0].Value.ToString();
                txtNomCours.Text= dgvCours.CurrentRow.Cells[2].Value.ToString();
                btnAddClasse.Visible = false;
                btnModifCours.Visible = true;

            }
        }

        private void sUPPRIMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCours.CurrentRow!=null)
            {
                string id = dgvCours.CurrentRow.Cells[0].Value.ToString();
                if (cours.supprimer(id)==true)
                {
                    MessageBox.Show("Supprission réussie");
                    afficher("");
                }
                else
                {
                    MessageBox.Show("echec");
                }
            }
        }

        private void btnModifCours_Click(object sender, EventArgs e)
        {
            if (cours.modifier(txtIdCours.Text,txtNomCours.Text)==true)
            {
                MessageBox.Show("Modification ruéssie");
                btnAddClasse.Visible = true;
                btnModifCours.Visible = false;
                txtNomCours.Text = "Description de Cours";
                afficher("");
            }
            else
            {
                MessageBox.Show("Echec");
            }
        }

        private void txtReseach_TextChanged(object sender, EventArgs e)
        {
            if (txtReseach.Text!="" && txtReseach.Text!= "Recherche ......................")
            {
                afficher(txtReseach.Text);
            }
            else 
            { 
                afficher(""); 
            }
        }
    }
}
