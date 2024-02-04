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
    public partial class FrmAjouterAnnee : Form
    {
        models.Cl_annee annee = new models.Cl_annee();
        models.connection conn = new models.connection();
        MySqlCommand cmdUpdate;
        public FrmAjouterAnnee()
        {
            InitializeComponent();
            affichAnnee();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAnneeScolaire_Enter(object sender, EventArgs e)
        {
            if (txtAnneeScolaire.Text == "Entrez annee scolaire") txtAnneeScolaire.Text = "";
        }

        private void txtAnneeScolaire_Leave(object sender, EventArgs e)
        {
            if (txtAnneeScolaire.Text == "") txtAnneeScolaire.Text = "Entrez annee scolaire";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAnneeScolaire.Text!="" && txtAnneeScolaire.Text!= "Entrez annee scolaire")
            {
               
                if (annee.ajoute(txtAnneeScolaire.Text) == true) MessageBox.Show("Enregistrement effectué");
                else MessageBox.Show("Echec");
                txtAnneeScolaire.Text = "Entrez annee scolaire";
                affichAnnee();
            }
            else MessageBox.Show("Champs obligatoire");
        }


       

        void affichAnnee()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from school_year", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvAnneeScolaire.Rows.Clear();
                //int num = 0;
                while (rd.Read())
                {
                   // num++;
                    dgvAnneeScolaire.Rows.Add(rd[0].ToString(),rd[1].ToString());

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

        //private void dgvAnneeScolaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void dgvAnneeScolaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAnneeScolaire.Rows.Count > 0)
            {
                txtAnneeScolaire.Text = dgvAnneeScolaire.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("voulez vous vraiment supprimer  l annee scolaire'" + txtAnneeScolaire.Text + "'", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (reponse == DialogResult.OK)
            {
                try
                {
                    
                    Services.MsgFRM msg=new Services.MsgFRM();
                    //ici on met le code qu'on veut executer
                    conn.conndb.Open();
                    //code pour inserer
                 
                    cmdUpdate = conn.conndb.CreateCommand();//creation de la commande
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.CommandText = " delete from school_year where description_annee='" + txtAnneeScolaire.Text + "'";
                    cmdUpdate.ExecuteNonQuery();
                    msg.getInfo("Suppression  faite avec succe");
                    conn.conndb.Close();
                    affichAnnee();

                }
                catch (Exception ex)
                {
                    //ici on met le message d'erreur si l'execution a rencontré une erreure
                    MessageBox.Show(ex.Message.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    // ici on met le code qui succede l'execution meilleure du code essayé
                    conn.conndb.Close();
                }
            }
            else
            {
                MessageBox.Show("rien  a supprimer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }
    }
}
