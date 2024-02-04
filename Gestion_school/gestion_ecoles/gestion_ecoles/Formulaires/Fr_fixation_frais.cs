using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.Formulaires
{
    public partial class Fr_fixation_frais : Form
    {
        models.connection conn = new models.connection();
        models.Cl_frais frais = new models.Cl_frais();
        public Fr_fixation_frais()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            afficher();
            remplireCmbClasse();
            remplireCmbCtaegorie();
            remplireCmbOption();
            remplireEcole();
            
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            // Enregistrement de fixation de frais 
            if (ObligatoireXhamp() == null)
            {
                if (frais.ajouet(float.Parse(txtMontant.Text),cmbCategorieFrais.Text,txtScope.Text,cmbOption.Text,cmbClasse.Text,cmbAnneeScolaire.Text) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                    afficher();
                }
                else MessageBox.Show("Echec d'enregistrement");
            }
            else MessageBox.Show(ObligatoireXhamp());
        }

        // Vérification de champs 
        string ObligatoireXhamp()
        {
            if (cmbClasse.Text == "") return "Choisissez la classe";
            if (cmbOption.Text == "") return "Choisissez l'option";
            if (cmbAnneeScolaire.Text == "") return "Choisissez l'année scolaire";
            if (cmbCategorieFrais.Text == "") return "Chosissez Catégorie Frais";
            return null;
        }

        // Methode 
        void remplireCmbClasse()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM classes", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbClasse.Items.Clear();
                while (rd.Read())
                {
                    cmbClasse.Items.Add(rd[0]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void remplireCmbOption()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM options", conn.conndb);

            // Ouverture de la connexion à la BDD
            conn.conndb.Open();

            MySqlDataReader rd = cmd.ExecuteReader();
            cmbOption.Items.Clear();
            while (rd.Read())
            {
                cmbOption.Items.Add(rd[0]).ToString();
            }
            rd.Close();
            conn.conndb.Close();
        }

        void remplireAnneeScolaire()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnneeScolaire.Items.Clear();
                while (rd.Read())
                {
                    cmbAnneeScolaire.Items.Add(rd[1]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
           
            conn.conndb.Close();
        }

        void remplireEcole()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtScope.Text = rd[0].ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();    
            }
            
        }

        // Recupération id Catégorie
        void remplireCmbCtaegorie()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `categorie_frais`", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbCategorieFrais.Items.Clear();
                while (rd.Read())
                {
                    cmbCategorieFrais.Items.Add(rd[1]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            
        }

        void afficher()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT frais.id_frais,frais.code_class,frais.code_option,school_year.description_annee,frais.montant FROM frais,school_year WHERE frais.id_annee_scol=school_year.id_annee_scol", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                dgvFixationFrais.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvFixationFrais.Rows.Add(num, rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString() + " $");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnModifFrais_Click(object sender, EventArgs e)
        {
            // Modification 
        }

        private void mODIFIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Appel de modification
        }

        private void sUPPRIMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Appel de suppression 
        }
    }
}
