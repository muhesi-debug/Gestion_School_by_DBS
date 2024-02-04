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
using MySql.Data.MySqlClient;
using gestion_ecoles.models;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace gestion_ecoles
{
    public partial class Rlivre : Form
    {
        public Rlivre()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            rempliresemestre();
            remplireFrais();
            remplireMois();
        }
        models.connection conn=new models.connection();
        private void Rlivre_Load(object sender, EventArgs e)
        {
            models.connection conn = new models.connection();
        }


        void remplireAnneeScolaire()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnnee.Items.Clear();
                while (rd.Read())
                {
                    cmbAnnee.Items.Add(rd[1]).ToString();
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

        void remplireMois()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mois", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbMois.Items.Clear();
                while (rd.Read())
                {
                    cmbMois.Items.Add(rd[1]).ToString();
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

        void remplireFrais()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM categorie_frais", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbFrais.Items.Clear();
                while (rd.Read())
                {
                    cmbFrais.Items.Add(rd[1]).ToString();
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


        void rempliresemestre()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM semestre", conn.conndb);

                // Ouverture de la connexion à la BDD
                conn.conndb.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                cmbSemestre.Items.Clear();
                while (rd.Read())
                {
                    cmbSemestre.Items.Add(rd[1]).ToString();
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

        private void btnaffiche_Click(object sender, EventArgs e)
        {
            try
            {
                models.connection con = new models.connection();
                CrystalReport1 fcli = new CrystalReport1();

                if (con.conndb.State != ConnectionState.Open)
                {
                    con.conndb.Open();
                }
                MySqlCommand cmd = new MySqlCommand("select * from caisse_depenses where description_annee='"+cmbAnnee.Text + "' AND description_frais='"+cmbFrais.Text+"' AND description_sem='" + cmbSemestre.Text+"'", con.conndb);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                //DataSet2 ds=new DataSet2();
                DataSet1 ds = new DataSet1();
                ada.Fill(ds, "caisse_depenses");
                fcli.SetDataSource(ds.Tables["caisse_depenses"]);
                crystalReportViewer1.ReportSource = fcli;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.conndb.Close();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnrecettes_Click(object sender, EventArgs e)
        {
            try
            {
                models.connection con = new models.connection();
               CrystalReport2 fcli = new CrystalReport2();

                if (con.conndb.State != ConnectionState.Open)
                {
                    con.conndb.Open();
                }
                MySqlCommand cmd = new MySqlCommand("select * from caisse_recette where description_annee='" + cmbAnnee.Text + "' AND description_frais='" + cmbFrais.Text + "' AND description_sem='" + cmbSemestre.Text + "'", con.conndb);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet1 ds = new DataSet1();
                ada.Fill(ds, "caisse_recette");
               fcli.SetDataSource(ds.Tables["caisse_recette"]);
               crystalReportViewer1.ReportSource = fcli;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.conndb.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                models.connection con = new models.connection();
              CrystalReport3 fcli = new CrystalReport3();

                if (con.conndb.State != ConnectionState.Open)
                {
                    con.conndb.Open();
                }
                MySqlCommand cmd = new MySqlCommand("select * from solde_globale where description_annee='" + cmbAnnee.Text + "'", con.conndb);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet1 ds = new DataSet1();
                ada.Fill(ds, "solde_globale");
              fcli.SetDataSource(ds.Tables["solde_globale"]);
                crystalReportViewer1.ReportSource = fcli;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.conndb.Close();
        }

        private void tabdepenses_Click(object sender, EventArgs e)
        {
           if(tabdepenses.SelectedIndex == 2)
            {
                label2.Visible = false;
                cmbSemestre.Visible= false;
                label3.Visible = false;
                cmbFrais.Visible= false;
            }
           else if(tabdepenses.SelectedIndex==3){
                label2.Visible = false;
                cmbSemestre.Visible =false; 
                label4.Visible = true;
                cmbMois.Visible = true;
                label3.Visible = false;
                cmbFrais.Visible = false;
            }
            else
            {
                label2.Visible = true;
                cmbSemestre.Visible = true;
                label4.Visible = false;
                cmbMois.Visible = false;
                label3.Visible = true;
                cmbFrais.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                models.connection con = new models.connection();
                liste_paie_agent fcli = new liste_paie_agent();

                if (con.conndb.State != ConnectionState.Open)
                {
                    con.conndb.Open();
                }
                MySqlCommand cmd = new MySqlCommand("select * from liste_paie where description_annee='" + cmbAnnee.Text + "' AND description_mois='"+ cmbMois.Text+"'", con.conndb);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet1 ds = new DataSet1();
                ada.Fill(ds, "liste_paie");
                fcli.SetDataSource(ds.Tables["liste_paie"]);
                crystalReportViewer1.ReportSource = fcli;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.conndb.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
