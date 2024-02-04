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
    public partial class frmCateFrais : Form
    {
        // Instance de la classe frais
        models.connection conn = new models.connection();
        models.Cl_frais frais = new models.Cl_frais();
        public frmCateFrais()
        {
            InitializeComponent();
            afficher();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text != "")
            {
                if (frais.categorie_frais(txtDescription.Text) == true)
                {
                    MessageBox.Show("Catégorie ajoutée");
                }
                else MessageBox.Show("Echec d'enregistrement");
            }
            else MessageBox.Show("Completer le champ");
        }

        void afficher()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `categorie_frais`", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvCatégorieFrais.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvCatégorieFrais.Rows.Add(rd[0].ToString(), num, rd[1].ToString());

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

        private void frmCateFrais_Click(object sender, EventArgs e)
        {
            afficher();
        }
    }
}
