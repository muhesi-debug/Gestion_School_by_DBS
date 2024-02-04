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
    public partial class FrmAjouterMois : Form
    {
        models.Cl_mois mois = new models.Cl_mois();
        models.connection conn = new models.connection();
        public FrmAjouterMois()
        {
            InitializeComponent();
            affichMois();
        }

        private void txtNomCours_Leave(object sender, EventArgs e)
        {
            if (txtNomCours.Text == "") txtNomCours.Text = "Description mois";
        }

        private void txtNomCours_Enter(object sender, EventArgs e)
        {
            if (txtNomCours.Text == "Description mois") txtNomCours.Text = "";
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            // Enregistrement mois 
            if (txtNomCours.Text != "" && txtNomCours.Text != "Description mois")
            {
                if (mois.ajouter(txtNomCours.Text) == true) MessageBox.Show("Enregistrement réussi");
                else MessageBox.Show("Echec");
                txtNomCours.Text = "Description mois";
            }
            else MessageBox.Show("Champ obligatoire");
        }


        void affichMois()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from mois", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvMois.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvMois.Rows.Add(rd[0].ToString(), num, rd[1].ToString());

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

        private void FrmAjouterMois_Click(object sender, EventArgs e)
        {
            affichMois();
        }
    }
}
