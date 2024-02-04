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
    public partial class Gestion_users : UserControl
    {
        // Création de l'instance 
        //Gestion_users users = new Gestion_users();

        private static Gestion_users cl_users;

        models.connection conn = new models.connection();
        models.Cl_users user = new models.Cl_users();
        public static Gestion_users instance
        {
            get
            {
                if (cl_users == null)
                {
                    cl_users = new Gestion_users();
                }
                return cl_users;
            }


        }
        public Gestion_users()
        {
            InitializeComponent();
            afficher("");
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Formulaires.Frm_ajouterUsers users = new Formulaires.Frm_ajouterUsers();
            users.button2.Visible = false;
            users.btnClient.Visible = true;
            users.label4.Text = "ENREGISTRER UN NOUVEAU AGENT";
            users.ShowDialog();
        }

        private void txtReseach_TextChanged(object sender, EventArgs e)
        {
            if (txtReseach.Text != "Recherche ......................" && txtReseach.Text != "")
                afficher(txtReseach.Text);
            else
                afficher("");
        }

        void afficher(string recher)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE username LIKE '%" + recher + "%' || fonction like '%"+recher+"%'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvUsers.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvUsers.Rows.Add(num,rd[0].ToString(),rd[1].ToString(), rd[3].ToString(), rd[2].ToString());

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

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text == "") txtReseach.Text = "Recherche ......................";
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text == "Recherche ......................") txtReseach.Text = "";
        }

        private void sUPPRIMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Supprimer
            if (dgvUsers.CurrentRow != null)
            {
                // Index

                int index = int.Parse(dgvUsers.CurrentRow.Cells[1].Value.ToString());
                if (index != null) 
                {
                    if (user.supprimer(index) == true)
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
        }

        private void mODIFIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Modifier
            Formulaires.Frm_ajouterUsers users = new Formulaires.Frm_ajouterUsers();
            users.label4.Text = "MODIFICATION DE L\' UTILISATEUR";
            users.btnClient.Visible = false;
            users.button2.Visible = true;
            
            if (dgvUsers.CurrentRow != null)
            {
                // Index

                int index = int.Parse(dgvUsers.CurrentRow.Cells[1].Value.ToString());
                if (index != null)
                {
                    users.txtId.Text = index.ToString();
                    users.txtNomUtilisateur.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
                    users.txtMotDePasse.Text = dgvUsers.CurrentRow.Cells[4].Value.ToString();
                    users.cmbFonction.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();

                    users.ShowDialog();
                }
                else MessageBox.Show("Veuillez selectionner un utilisateur à modifier");
            }
        }

        private void aCTUALISERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Actualiser 
            afficher("");
        }
    }
}
