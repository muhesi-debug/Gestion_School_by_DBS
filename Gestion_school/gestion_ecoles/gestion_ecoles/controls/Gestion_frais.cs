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

namespace gestion_ecoles.controls
{
    public partial class Gestion_frais : UserControl
    {
        // Création de l'instance 
        //Gestion_frais frais = new Gestion_frais();

        // Connexion 
        models.connection conn = new models.connection();

        private static Gestion_frais cl_frais;

        public static Gestion_frais instance
        {
            get
            {
                if (cl_frais == null)
                {
                    cl_frais = new Gestion_frais();
                }
                return cl_frais;
            }


        }
        public Gestion_frais()
        {
            InitializeComponent();
            afficher("", "", "", "");
            afficherAnnee();
            afficherClasse();
            affiherOption();
            afficherTrimestre();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Formulaires.Frm_paiement_frais_scolaire scolaire = new Formulaires.Frm_paiement_frais_scolaire();
            scolaire.ShowDialog();
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text == "") txtReseach.Text = "Recherche ......................";
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text == "Recherche ......................") txtReseach.Text = "";
        }


        // Affichage de paiement frais scolaire 
        void afficher(string classe, string options, string annee, string trimestre)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("select * from students,inscrire,payement_frais)", conn.conndb);
                //conn.conndb.Open();
                //MySqlDataReader rd = cmd.ExecuteReader();
                //dgvFraisScolaire.Rows.Clear();
                //int num = 0;
                //while (rd.Read())
                //{
                //    num++;
                //    dgvFraisScolaire.Rows.Add(num, rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[3].ToString().Replace(".",","), rd[4].ToString(), rd[5].ToString(),"Supprimer","Modifier");

                //}
                //rd.Close();
                //conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTrimestre.Text != "" && cmbAnnee.Text != "" && cmbClasse.Text != "" && cmbOption.Text != "") 
                afficher(cmbClasse.Text, cmbOption.Text, cmbAnnee.Text, cmbTrimestre.Text);
            else
                afficher("", "", "", "");
        }

        // Selection de 
        void afficherClasse()
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

        void affiherOption()
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

        void afficherAnnee()
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
        void afficherTrimestre()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM semestre", conn.conndb);

            // Ouverture de la connexion à la BDD
            conn.conndb.Open();

            MySqlDataReader rd = cmd.ExecuteReader();
            cmbTrimestre.Items.Clear();
            while (rd.Read())
            {
                cmbTrimestre.Items.Add(rd[1]).ToString();
            }
            rd.Close();
            conn.conndb.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formulaires.FrAffect_frais aff = new Formulaires.FrAffect_frais();
            aff.ShowDialog();
        }
    }
}
