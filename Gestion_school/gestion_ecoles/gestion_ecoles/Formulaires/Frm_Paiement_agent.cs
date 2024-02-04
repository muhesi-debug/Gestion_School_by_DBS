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
    public partial class Frm_Paiement_agent : Form
    {
        models.Cl_agents paiement = new models.Cl_agents();
        models.connection conn = new models.connection();
        public Frm_Paiement_agent()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbCtaegorie();
            remplireMois();
           Afficher();
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text== "Entrez le matricule de l'Agent")
            {
                txtReseach.Text = "";
            }
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text=="")
            {
                txtReseach.Text = "Entrez le matricule de l'Agent";
            }
            if (txtReseach.Text != "Entrez le matricule de l'Agent" && txtReseach.Text != "")
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT affecter_agent_options.id_affecter_ag_opt,agent.id_agent,agent.noms_agent FROM affecter_agent_options, agent WHERE agent.id_agent=affecter_agent_options.id_agent && affecter_agent_options.id_agent='" + txtReseach.Text + "' ", conn.conndb);

                    // Ouverture de la connexion à la BDD
                    conn.conndb.Open();

                    MySqlDataReader rd = cmd.ExecuteReader();
                    txtNom.Clear();
                    txtPostnom.Clear();
                    if (rd.Read())
                    {
                        txtNom.Text = rd[2].ToString();
                        txtPostnom.Text = rd[1].ToString();
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
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            string datefin = string.Format("{0}-{1}-{2}", dateFin.Value.Year, dateFin.Value.Month, dateFin.Value.Day);
            // Enregistrement de paiement des agents 
            if (txtNom.Text != "" && cmbMois.Text != "" && cmbCategoriFrais.Text != "" && cmbAnneescolaire.Text != "")
            {
                if (paiement.paiement_prime_agent(float.Parse(txtMontantPaye.Text), txtLibelle.Text, cmbCategoriFrais.Text, txtPostnom.Text,cmbMois.Text,cmbAnneescolaire.Text, datefin) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                }
                else MessageBox.Show("Echec");
            }
            else MessageBox.Show("Tous les champs sont obligatoires");
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
                cmbCategoriFrais.Items.Clear();
                while (rd.Read())
                {
                    cmbCategoriFrais.Items.Add(rd[1]).ToString();
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

        void remplireAnneeScolaire()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnneescolaire.Items.Clear();
                while (rd.Read())
                {
                    cmbAnneescolaire.Items.Add(rd[1]).ToString();
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

        void Afficher()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT agent.noms_agent,agent.id_agent,payement_prime_agent.montant_prime,payement_prime_agent.datePaiment FROM payement_prime_agent,agent,affecter_agent_options WHERE (payement_prime_agent.id_agent=agent.id_agent AND agent.id_agent=affecter_agent_options.id_agent)", conn.conndb);
                // Ouverture de la connexion à la BDD
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvPaiementAgent.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvPaiementAgent.Rows.Add(num, rd[0].ToString(), rd[1].ToString(), rd[3].ToString(), rd[2].ToString() + " $");
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

        private void Frm_Paiement_agent_Click(object sender, EventArgs e)
        {
            Afficher();
        }
    }
}
