using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gestion_ecoles
{
    
    public partial class ListeEleveclasseannée : Form
    {
        models.connection conn = new models.connection();
        public ListeEleveclasseannée()
        {
            InitializeComponent();
            afficherAnnee();
            afficherClasse();
            affiherOption();
        }

        private void ListeEleveclasseannée_Load(object sender, EventArgs e)
        {
            
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
            cmbAnneeScolaire.Items.Clear();
            while (rd.Read())
            {
                cmbAnneeScolaire.Items.Add(rd[1]).ToString();
            }
            rd.Close();
            conn.conndb.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.Liste_d_élèves_dans_une_classe_et_option_en_une_année_scolaire'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
           // this.Liste_d_élèves_dans_une_classe_et_option_en_une_année_scolaireTableAdapter.Fill(this.DataSet1.Liste_d_élèves_dans_une_classe_et_option_en_une_année_scolaire, cmbOption.Text, cmbClasse.Text, cmbAnneeScolaire.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
