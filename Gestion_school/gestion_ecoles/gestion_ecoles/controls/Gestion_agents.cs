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
    public partial class Gestion_agents : UserControl
    {
        // Création de l'instance 
        //Gestion_agents agents = new Gestion_agents();
        models.connection conn = new models.connection();
        models.Cl_agents agent = new models.Cl_agents();

        private static Gestion_agents cl_agents;

        public static Gestion_agents instance
        {
            get
            {
                if (cl_agents == null)
                {
                    cl_agents = new Gestion_agents();
                }
                return cl_agents;
            }


        }
        public Gestion_agents()
        {
            InitializeComponent();
            afficher("");
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Formulaires.AjouteAgent agent = new Formulaires.AjouteAgent();
            agent.ShowDialog();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            afficher("");
        }

        void afficher(string recher)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `agent` WHERE noms_agent LIKE '%"+recher+"%'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                dgvAgent.Rows.Clear();
                int num = 0;
                while (rd.Read())
                {
                    num++;
                    dgvAgent.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[4].ToString(), rd[3].ToString(), rd[5].ToString());

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
            if (txtReseach.Text=="") txtReseach.Text = "Recherche ......................";
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text == "Recherche ......................") txtReseach.Text = "";
        }

        private void txtReseach_TextChanged(object sender, EventArgs e)
        {
            if (txtReseach.Text != "Recherche ......................" && txtReseach.Text != "")
                afficher(txtReseach.Text);
            else
                afficher("");

        }

        private void sUPRIMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // SUPPRESISION 

            if (dgvAgent.CurrentRow != null)
            {
                // Index

                string index = dgvAgent.CurrentRow.Cells[0].Value.ToString();

                txtid.Text = index;
                if (agent.supprimer(index)==true)
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

        private void mODIFIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Modification 
            Formulaires.AjouteAgent agentss = new Formulaires.AjouteAgent();


            if (dgvAgent.CurrentRow != null)
            {
                // Index

                string index = dgvAgent.CurrentRow.Cells[0].Value.ToString();
                agentss.txtMatriculeAgent.Enabled = false;
                agentss.txtPostnomAgent.Visible = false;
                agentss.txtPrenomAgent.Visible = false;
                agentss.btnAddClasse.Visible = false;
                agentss.label2.Visible = false;
                agentss.label3.Visible = false;
                agentss.txtMatriculeAgent.Text = dgvAgent.CurrentRow.Cells[0].Value.ToString();
                agentss.txtnomAgent.Text = dgvAgent.CurrentRow.Cells[1].Value.ToString();
                agentss.cmbGenreAgent.Text = dgvAgent.CurrentRow.Cells[2].Value.ToString();
                agentss.txtfonction.Text = dgvAgent.CurrentRow.Cells[3].Value.ToString();
                agentss.txtGrade.Text = dgvAgent.CurrentRow.Cells[4].Value.ToString();
                agentss.txtPhone.Text = dgvAgent.CurrentRow.Cells[5].Value.ToString();
                agentss.ShowDialog();
            }


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            afficher("");
        }
    }
}