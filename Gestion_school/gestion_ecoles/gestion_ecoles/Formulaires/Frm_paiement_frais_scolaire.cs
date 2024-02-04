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
    public partial class Frm_paiement_frais_scolaire : Form
    {
        // Connexion 
        models.connection conn = new models.connection();
        models.Cl_frais frais = new models.Cl_frais();
        float montantPaeyer = 0;
        public Frm_paiement_frais_scolaire()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbCtaegorie();
            remplireCmbSemestre();
            remplireMois();
            
        }

        private void cmbDevise_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Visualiser 
            if (cmbDevise.Text== "Franc Congolais")
            {
                txtTaux.Visible = true;
                pnlTaux.Visible = true;
                label4.Text = "FC";

                
            }
            else
            {
                txtTaux.Visible = false;
                pnlTaux.Visible = false;
                label4.Text = "$";
                int zero = 1;
                txtTaux.Text = zero.ToString();
            }
        }

        private void txtTaux_Enter(object sender, EventArgs e)
        {
            if (txtTaux.Text== "Taux du jour") txtTaux.Text = "";
        }

        private void txtTaux_Leave(object sender, EventArgs e)
        {
            if (txtTaux.Text=="")
            {
                txtTaux.Text = "Taux du jour";
            }
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text == "Entrez le matricule Eleve") txtReseach.Text = "";
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text == "") txtReseach.Text = "Entrez le matricule Eleve";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérification si le champs sont remplis 
            if (comboBox1.Text!="" && (txtReseach.Text!="" & txtReseach.Text!= "Entrez le matricule Eleve"))
            {
                try
                {
                    MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + comboBox1.Text + "'", conn.conndb);
                    conn.conndb.Open();
                    MySqlDataReader rd = cd.ExecuteReader();
                    int idAnne = 0;
                    if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();
                    MySqlCommand cmd = new MySqlCommand("SELECT inscrire.id_inscription,inscrire.code_class,inscrire.code_option, students.num_mat,students.stdnames, inscrire.id_annee_scol FROM inscrire,students WHERE inscrire.student=students.num_mat && (inscrire.student='" + txtReseach.Text + "' && inscrire.id_annee_scol='" + idAnne + "')", conn.conndb);
                    MySqlDataReader rrd = cmd.ExecuteReader();
                    if (rrd.Read())
                    {
                        txtNom.Text = rrd[4].ToString();
                        txtClasse.Text = rrd[1].ToString();
                        txtInscription.Text = rrd[0].ToString();
                        txtOption.Text = rrd[2].ToString();
                    }
                    else MessageBox.Show("Le matricule est introuvable!!!!!!! \n veuillez composer un autre correctement");
                    rrd.Close();
                    conn.conndb.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.conndb.Close();
                }
                

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
            catch( Exception ex )
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
                comboBox1.Items.Clear();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd[1]).ToString();
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
                    //txtScope.Text = rd[0].ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) {
                
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
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
               conn.conndb.Close();
            }
           
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaux.Text != "" && txtTaux.Text != "Taux du jour")
                {
                    montantPaeyer = (float.Parse(txtMontantPaye.Text) / float.Parse(txtTaux.Text));
                    txtMontantPaye.Text = montantPaeyer.ToString();

                }
                // Vérification de champs
                if (cmbDevise.Text != "" && cmbSemestre.Text != "" && cmbCategorieFrais.Text != "" && txtInscription.Text != "")
                {
                    if (cmbDevise.Text == "Franc Congolais" && (txtTaux.Text == "" || txtTaux.Text == "Taux du jour" || txtTaux.Text == "Entrez le taux du jour"))
                    {
                        txtTaux.ForeColor = Color.Red;
                        txtTaux.Text = "Entrez le taux du jour";
                    }
                    else
                    {
                        txtTaux.ForeColor = Color.AliceBlue;
                        DialogResult reponse = MessageBox.Show("Voulez vous enregistrer ces informations? \n Noms :" + txtNom.Text + " \n CLASSE :" + txtClasse.Text + "\n OPTION :" + txtOption.Text + "\n VIENT PAYER LE" + cmbCategorieFrais.Text + "\n MONTANT DE " + txtMontantPaye.Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reponse == DialogResult.Yes)
                        {
                            // Conversion de date
                            string datePaie = string.Format("{0}-{1}-{2}", datePaiement.Value.Year, datePaiement.Value.Month, datePaiement.Value.Day);
                            double montants = double.Parse(txtMontantPaye.Text.Replace(",", "."));
                            if (frais.paiement_frais_scolaires(datePaie, montants, cmbDevise.Text, int.Parse(txtTaux.Text), cmbCategorieFrais.Text, cmbSemestre.Text, int.Parse(txtInscription.Text), comboBox1.Text, txtOption.Text, txtClasse.Text, cmbMois.Text, txtLibelle.Text) == true)
                            {
                                MessageBox.Show("Paiement effectué");
                            }
                            else MessageBox.Show("Echec");
                        }
                        else MessageBox.Show("Opération annulée");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez remplire tous les champs");
                }
            }catch(FormatException ex)
            {
                MessageBox.Show("Format incorect "+ex.Message);
            }
        }

        private void txtMontantPaye_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaux_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
