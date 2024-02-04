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
    public partial class FrmCategorieCotes : Form
    {
        models.Cl_cotes categorie = new models.Cl_cotes();
        models.connection conn = new models.connection();
        public FrmCategorieCotes()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCours();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            // Add
            if (txtDescription.Text != "")
            {
                if (categorie.ajouter(txtDescription.Text,cmbCours.Text,cmbAnneeScolaire.Text) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                }
                else MessageBox.Show("Echec");
            }
            else MessageBox.Show("Completez le champs");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
            
        }

        void remplireCours()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM affecter_cours", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbCours.Items.Clear();
                while (rd.Read())
                {
                    cmbCours.Items.Add(rd[7]).ToString();
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
}
