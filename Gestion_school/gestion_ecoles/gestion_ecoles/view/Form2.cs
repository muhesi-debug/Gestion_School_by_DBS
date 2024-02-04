using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gestion_ecoles.view
{
    public partial class Form2 : Form
    {
        models.connection conn = new models.connection();
        float someR = 0;
        float someD = 0;
        public Form2()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireMois();
            
        }

        void DgvDepense(string mois, string annee) 
        {
            MySqlCommand cmd = new MySqlCommand("SELECT depenses.date_depense,depenses.id_depense,depenses.motif,depenses.montant_depense,depenses.observation FROM depenses,school_year,categorie_frais,mois,school WHERE (depenses.id_annee_scol=school_year.id_annee_scol AND depenses.id_categ_frais=categorie_frais.id_categ_frais AND school_year.description_annee='"+annee+"') AND (mois.id_mois=depenses.mois AND mois.description_mois='"+mois+"')",conn.conndb);
            conn.conndb.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            dgvDepenses.Rows.Clear();
            while (rd.Read()) {
                dgvDepenses.Rows.Add(rd[0].ToString(),rd[1].ToString(),rd[2].ToString(),rd[3].ToString().Replace(".",","),rd[4].ToString());
            } rd.Close();
            conn.conndb.Close();

        }


        void DgvRecette(string mois, string annee)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT payement_frais.date_paie,payement_frais.id_payement_frais,payement_frais.motif,payement_frais.montant_paye FROM payement_frais,school_year,mois,inscrire WHERE (payement_frais.mois=mois.id_mois AND description_mois='" + mois+"') AND (school_year.id_annee_scol=inscrire.id_annee_scol AND school_year.description_annee='"+annee+"' AND inscrire.id_inscription=payement_frais.id_inscription)", conn.conndb);
            conn.conndb.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            dgvRecette.Rows.Clear();
            while (rd.Read())
            {
                dgvRecette.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[3].ToString().Replace(".",","));
            } rd.Close();
            conn.conndb.Close();

        }


        void remplireAnneeScolaire()
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

        void remplireMois()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAnneeScolaire.Text != "" && cmbMois.Text != "")
            {
                DgvDepense(cmbMois.Text, cmbAnneeScolaire.Text);
                DgvRecette(cmbMois.Text, cmbAnneeScolaire.Text);

                

                for (int i = 0; i < dgvRecette.Rows.Count; i++)
                {
                    //for(int j=1; j<dgvRecette.Rows.Count; j++)
                    //{

                    //    txtMontantRecette.Text = (float.Parse(dgvRecette.Rows[i].Cells[3].Value.ToString()) + float.Parse(dgvRecette.Rows[j].Cells[3].Value.ToString())).ToString();
                    //}  
                    someR += float.Parse(dgvRecette.Rows[i].Cells[3].Value.ToString());

                }
                txtMontantRecette.Text = someR.ToString();


                for (int i = 0; i < dgvDepenses.Rows.Count; i++)
                {
                     
                    someD += float.Parse(dgvDepenses.Rows[i].Cells[3].Value.ToString());

                }
                txtMontatDep.Text = someD.ToString();

                float total = (someR - someD);

                if (total < 0) txtSolde.BackColor = Color.Red;
                else txtSolde.BackColor = Color.White;
                txtSolde.Text = total.ToString();
            }
            else {
                DgvDepense("", "");
                DgvRecette("", "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog dllg = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            //{
            //    if (dllg.ShowDialog()==DialogResult.OK)
            //    {
            //        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //        Workbook wp = app.Workbooks.Add(XlSheetType.xlWorksheet);
            //        Worksheet ws = (Worksheet)app.ActiveSheet;
            //        app.Visible = false;

            //        // L'en tete
                   
            //        ws.Cells[1, 1] = "REPUBLIQUE DEMOCRATIQUE DU CONGO";
            //        ws.Cells[2, 1] = "PROVINCE DU NORD KIVU";
            //        ws.Cells[3, 1] = "EDUCATION NATIONNALE";
            //        ws.Cells[4, 1] = "RESEAU : ";
            //        ws.Cells[5, 1] = "ECOLE : ";
            //        ws.Cells[6, 1] = "MATRICULE : ";


            //        ws.Cells[8, 3] = "RECETTE";

            //        ws.Cells[9, 1] = "DATE";
            //        ws.Cells[9, 2] = "N°";
            //        ws.Cells[9, 3] = "LIBELLE";
            //        ws.Cells[9, 4] = "MONTANT";
            //        ws.Cells[9, 5] = "Obs";



            //        ws.Cells[8, 9] = "DEPENSES";

            //        ws.Cells[9, 7] = "DATE";
            //        ws.Cells[9, 8] = "N°";
            //        ws.Cells[9, 9] = "LIBELLE";
            //        ws.Cells[9, 10] = "MONTANT";
            //        ws.Cells[9, 11] = "ObsT";


            //        // Les valeur
            //        int ll = 9;
            //        int i = 9;
            //        for (int j = 0; j < dgvRecette.Rows.Count; j++)
            //        {
            //            i += 1;

            //            ws.Cells[i, 1] = dgvRecette.Rows[j].Cells[0].Value.ToString();
            //            ws.Cells[i, 2] = dgvRecette.Rows[j].Cells[1].Value.ToString();
            //            ws.Cells[i, 3] = dgvRecette.Rows[j].Cells[2].Value.ToString();
            //            ws.Cells[i, 4] = dgvRecette.Rows[j].Cells[3].Value.ToString().Replace(".",",");
                        


            //        }
            //        ws.Cells[i+1, 3] = "TOTAL";
            //        ws.Cells[i + 1, 4] = someR;

            //        for (int l = 0; l < dgvDepenses.Rows.Count; l++)
            //        {
            //            ll += 1;

            //            ws.Cells[ll, 7] = dgvDepenses.Rows[l].Cells[0].Value.ToString();
            //            ws.Cells[ll, 8] = dgvDepenses.Rows[l].Cells[1].Value.ToString();
            //            ws.Cells[ll, 9] = dgvDepenses.Rows[l].Cells[2].Value.ToString();
            //            ws.Cells[ll, 10] = dgvDepenses.Rows[l].Cells[3].Value.ToString().Replace(".",",");
                        

            //        }

            //        // Total 
            //        ws.Cells[ll + 1, 9] = "TOTAL";
            //        ws.Cells[ll + 1, 10] = someD;
            //        ws.Cells[ll + 2, 9] = "SOLDE : ";
            //        ws.Cells[ll + 2, 10] = txtSolde.Text.Replace(".",",");

            //        wp.SaveAs(dllg.FileName);
            //        app.Quit();
            //        MessageBox.Show("Enregistrement réusie");
            //    }



            //}
        }
    }
}
