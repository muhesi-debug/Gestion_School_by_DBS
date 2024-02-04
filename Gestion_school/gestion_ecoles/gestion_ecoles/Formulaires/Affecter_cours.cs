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
    public partial class Affecter_cours : Form
    {
        models.Cl_cours cours = new models.Cl_cours();
        models.connection conn = new models.connection();
        public Affecter_cours()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbClasse();
            remplireCmbOption();
            remplireEcole();
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            // Affectation de  
            if (ObligatoireXhamp() == null)
            {
                if (cours.affecter_cours(int.Parse(txtNombreHeur.Text), int.Parse(txtPoderation.Text),cmbOption.Text,cmbClasse.Text,cmbAnneeScolaire.Text,txtScope.Text,txtIdCours.Text) ==true)
                {
                    MessageBox.Show("Affectation effectuée avec succès");
                    Close();
                }
            }
            else MessageBox.Show(ObligatoireXhamp());
        }

        // Vérification de champs 
        string ObligatoireXhamp()
        {
            if (cmbClasse.Text == "") return "Choisissez la classe";
            if (cmbOption.Text == "") return "Choisissez l'option";
            if (cmbAnneeScolaire.Text == "") return "Choisissez l'année scolaire";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
            
        }
    }
}
