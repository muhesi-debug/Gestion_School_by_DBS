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
    public partial class Frm_Sortie_depenses : Form
    {
        private int iddepense;
        models.Cl_agents depense = new models.Cl_agents();
        models.connection conn = new models.connection();
        public Frm_Sortie_depenses()
        {
            InitializeComponent();
            pnlForm.Visible = false;
            remplireAnneeScolaire();
            remplireCmbCtaegorie();
            remplireUser();
            Afficher();
            remplireCmbMois();
            remplireNumeSecop();
            remplireSemestre();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = !pnlForm.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Random rad = new Random();
                iddepense = rad.Next();
                // Enregistrement d'une depense
                if (obligatoireChamp() == null)
                {
                    string montaDepense = txtMontantDepenses.Text.Replace(",", ".");
                    string datedeDep = string.Format("{0}-{1}-{2}", dateDepenses.Value.Year, dateDepenses.Value.Month, dateDepenses.Value.Day);
                    if (depense.depenses(iddepense, datedeDep, txtMotif.Text) == true)
                    {
                        depense.aff_depneses(iddepense, datedeDep, decimal.Parse(txtMontantDepenses.Text), cmbCategorie.Text, cmbAnnee.Text, cmbMois.Text, cmbSemestre.Text);
                        MessageBox.Show("Enregistrement réussi");
                        vider();
                    }
                    else MessageBox.Show("Echec");

                }
                else MessageBox.Show(obligatoireChamp());
            }
            catch(FormatException ed)
            {
                MessageBox.Show(ed.Message);
            }

        }

        // Vérification de champs 
        string obligatoireChamp()
        {
            if (txtMontantDepenses.Text == "") return"Completez le montant";
            if (txtMotif.Text == "") return "Completez le motif";
            if (cmbAnnee.Text == "") return "Completez l'année scolaire";
            if (cmbCategorie.Text == "") return "Completez  La base de la dépense";
            //if (txtObervation.Text == "") return "Completez l'observation";
            return null;
        }
        void vider()
        {
            txtMontantDepenses.Text = "";
            txtMotif.Text = "";
            cmbAnnee.Text ="";
            cmbCategorie.Text = "";
            txtObervation.Text = "";
        }

        void remplireAnneeScolaire()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnnee.Items.Clear();
                while (rd.Read())
                {
                    cmbAnnee.Items.Add(rd[1]).ToString();
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

        void remplireUser()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE fonction='Pref'", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtUser.Text = rd[0].ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
                conn.conndb.Close();
            }
            
        }



        void remplireSemestre()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM semestre ", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbSemestre.Items.Clear();
                if (rd.Read())
                {
                    cmbSemestre.Items.Add( rd[1].ToString());
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
                cmbCategorie.Items.Clear();
                while (rd.Read())
                {
                    cmbCategorie.Items.Add(rd[1]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message );
                conn.conndb.Close();
            
            }
            
        }

        void remplireNumeSecop()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `school`", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    numSecop.Text = rd[0].ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message );
            }
            
        }
        // Recupération  Mois
        void remplireCmbMois()
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
            { MessageBox.Show(ex.Message ); 
            conn.conndb.Close() ;
            }
            
        }

        void Afficher()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM depenses, aff_depenses WHERE depenses.id_depense=aff_depenses.id_depense ", conn.conndb);
                // Ouverture de la connexion à la BDD
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvDepense.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvDepense.Rows.Add(num, rd[0].ToString().Replace(".", ","), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString());
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message );
                conn.conndb.Close();          
            }
     
        }

        private void numSecop_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
