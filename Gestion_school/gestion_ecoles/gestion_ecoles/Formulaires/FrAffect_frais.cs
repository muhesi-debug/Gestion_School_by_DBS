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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestion_ecoles.Formulaires
{
    public partial class FrAffect_frais : Form
    {
        models.connection conn = new models.connection();
        models.Cl_frais frais = new models.Cl_frais();
        string datePaie;
        public FrAffect_frais()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbCtaegorie();
            remplireCmbSemestre();
            remplireMois();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            string dateafft = string.Format("{0}-{1}-{2}", datePaiement.Value.Year, datePaiement.Value.Month, datePaiement.Value.Day);
            if (dgvClienSelected() == null)
            {
                for (int i = 0; i < dgvPaiement.Rows.Count; i++)
                {
                    txtIdPaiementFrais.Text = dgvPaiement.Rows[i].Cells[1].Value.ToString();
                }
                if (txtIdPaiementFrais.Text!=null)
                {
                    if (frais.affecter_frais(dateafft,decimal.Parse(txtMontantPaye.Text),cmbAnne.Text,cmbCategorieFrais.Text,cmbSemestre.Text,cmbMois.Text,int.Parse(txtIdPaiementFrais.Text))==true)
                    {
                        // Update de 
                        models.Cl_Cumule cumule = new models.Cl_Cumule();
                        cumule.cumuler(int.Parse(txtIdPaiementFrais.Text), decimal.Parse(txtMontantPaye.Text));
                        MessageBox.Show("Affectation réussie");
                        affichage(datePaie);
                    }
                    else
                    {
                        MessageBox.Show("Echec");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner le montant à affecter");
                }
            }
            else
            {
                MessageBox.Show(dgvClienSelected());
            }
        }



        // Methode 
        void remplireCmbSemestre()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `semestre`", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbSemestre.Items.Clear();
                while (rd.Read())
                {
                    cmbSemestre.Items.Add(rd[1]).ToString();
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

        void remplireAnneeScolaire()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnne.Items.Clear();
                while (rd.Read())
                {
                    cmbAnne.Items.Add(rd[1]).ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }

        }

        // Recupération id Catégorie
        void remplireMois()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `mois`", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbMois.Items.Clear();
                while (rd.Read())
                {
                    cmbMois.Items.Add(rd[1]).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Affichages 
            datePaie = string.Format("{0}-{1}-{2}", datePaiement.Value.Year, datePaiement.Value.Month, datePaiement.Value.Day);
            affichage(datePaie);
        }

        void affichage(string dates)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT payement_frais.id_payement_frais,payement_frais.date_paie,(montant_paye-cumule) as calculs,payement_frais.libelle,cumule FROM payement_frais WHERE  montant_paye>=cumule AND payement_frais.date_paie='" + dates+"' AND cumule < montant_paye", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                dgvPaiement.Rows.Clear();
                while (rd.Read())
                {
                    dgvPaiement.Rows.Add(false,rd[0].ToString(), rd[1].ToString(), rd[2].ToString(),rd[3].ToString(), rd[4].ToString());
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



        // Verification de selction du dgvClient
        public string dgvClienSelected()
        {
            int nombreLigneselectionnes = 0;
            for (int i = 0; i < dgvPaiement.Rows.Count; i++)
            {
                if ((bool)dgvPaiement.Rows[i].Cells[0].Value == true)
                {
                    nombreLigneselectionnes++;
                }

            }

            if (nombreLigneselectionnes == 0) return "sélectionner le montant à affecter";
            if (nombreLigneselectionnes > 1) return "Veuillez sélectionner un seul montant pour l'affectation";
            return null;

        }
    }
}
