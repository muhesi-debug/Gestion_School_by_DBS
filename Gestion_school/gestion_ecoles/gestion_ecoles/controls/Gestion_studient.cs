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

    public partial class Gestion_studient : UserControl
    {

        // Création de l'instance 
        //Gestion_studient student = new Gestion_studient();

        private static Gestion_studient cl_student;
        models.connection conn = new models.connection();
        models.Cl_etudiant eleve = new models.Cl_etudiant();

        public static Gestion_studient instance
        {
            get
            {
                if (cl_student == null)
                {
                    cl_student = new Gestion_studient();
                }
                return cl_student;
            }


        }
        public Gestion_studient()
        {
            InitializeComponent();
            afficher("");
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Formulaires.Fr_inscrire_Student student = new Formulaires.Fr_inscrire_Student();
            student.ShowDialog();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            afficher("");
        }

        void afficher( string recherch)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `students` WHERE stdnames LIKE '%" + recherch + "%'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvStudient.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvStudient.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[8].ToString(), rd[11].ToString(), rd[3].ToString(),rd[4].ToString(), rd[10].ToString(), rd[9].ToString(), rd[12].ToString(), rd[14].ToString(), rd[13].ToString(), rd[6].ToString(), rd[7].ToString());

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

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text == "Recherche ......................")
                txtReseach.Text = "";
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text == "")
                txtReseach.Text = "Recherche ......................";
        }

        private void txtReseach_TextChanged(object sender, EventArgs e)
        {
            if (txtReseach.Text != "Recherche ......................" && txtReseach.Text != "")
                afficher(txtReseach.Text);
            else
                afficher("");
                
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvStudient.CurrentRow != null)
            {
                // Index

                string index = dgvStudient.CurrentRow.Cells[0].Value.ToString();
                if (eleve.supremmer(index) == true)
                {
                    MessageBox.Show("Suppression reussie");
                    afficher("");
                }
                else
                {
                    MessageBox.Show("Echec");
                }
            }
        }

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficher("");
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulaires.Fr_inscrire_Student student = new Formulaires.Fr_inscrire_Student();
            student.btnClient.Visible = false;
            student.button2.Visible = true;
            student.button1.Visible = false;
            
            if (dgvStudient.CurrentRow != null)
            {
                // Index

                string index = dgvStudient.CurrentRow.Cells[0].Value.ToString();
                if (index!=null)
                {
                    
                    student.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Echec");
                }
            }
        }
    }
}
