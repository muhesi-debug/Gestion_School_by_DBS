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
    public partial class AjouteAgent : Form
    {
        models.connection conn = new models.connection();
        models.Cl_agents agents = new models.Cl_agents();
        public AjouteAgent()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbOption();
            remplireEcole();
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
                    txtSecop.Text = rd[0].ToString();
                }
                rd.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();

            }


        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            // Enregistrement d'un nouvel agent 
            if (obligatoirChamp() == null)
            {
                // Matricule
                string agent = txtnomAgent.Text.Substring(0, 2)+""+txtPostnomAgent.Text.Substring(0,2);
                string noms = txtnomAgent.Text + " " + txtPostnomAgent.Text + " " + txtPrenomAgent.Text;
                if (agents.ajouter(agent,noms,cmbGenreAgent.Text,txtGrade.Text,txtfonction.Text,txtPhone.Text,txtSecop.Text)==true)
                {
                    agents.affecter_agent_in_option(cmbOption.Text, cmbAnneescolaire.Text);
                    MessageBox.Show("Enregistrement effectué avec succès");
                    vider();

                } else MessageBox.Show("Echec d'enregistrement");
            }
            else MessageBox.Show(obligatoirChamp());
        }


        void remplireCmbOption()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                conn.conndb.Close();
            }
        }

        // Vérification de champs
        string obligatoirChamp()
        {
            if (txtnomAgent.Text == "") return "Entrez le nom de l'agent";
            if (txtPostnomAgent.Text == "") return "Entrez le Postnom de l'agent";
            if (cmbGenreAgent.Text == "") return "Chosissez le genre de l'agent";
           // if (txtPhone.Text == "") return "Entrez le numéro de téléphone";
            if (txtfonction.Text == "") return "Entrez la fonction de l'agent";
            if (txtGrade.Text == "") return "Entrez le niveau d'étude de l'agent";
            if (cmbAnneescolaire.Text == "") return "Choisissez l'année scolaire d'affectation";
            if (cmbOption.Text == "") return "Choisissez l'option d'affectation";

            return null;
        }
        void vider()
        {
            txtnomAgent.Text ="";
            txtPostnomAgent.Text = "";
            cmbGenreAgent.Text = "";
            txtPhone.Text =""; 
            txtfonction.Text = ""; 
            txtGrade.Text = "";
            cmbAnneescolaire.Text = "";
            cmbOption.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (agents.modifier(txtMatriculeAgent.Text,txtnomAgent.Text,cmbGenreAgent.Text,txtGrade.Text,txtfonction.Text,txtPhone.Text)==true)
            {
                MessageBox.Show("Modification réussi");
                Close();
                
            }
            else
            {
                MessageBox.Show("Modification échouée");
            }
        }
    }
}
