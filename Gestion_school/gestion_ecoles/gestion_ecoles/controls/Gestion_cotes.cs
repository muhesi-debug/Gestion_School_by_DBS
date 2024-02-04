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
    public partial class Gestion_cotes : UserControl
    {
        // Création de l'instance 
        //Gestion_cotes cotes = new Gestion_cotes();
        models.Cl_cotes cote = new models.Cl_cotes();
        models.connection conn = new models.connection();

        private static Gestion_cotes cl_cotes;

        public static Gestion_cotes instance
        {
            get
            {
                if (cl_cotes == null)
                {
                    cl_cotes = new Gestion_cotes();
                }
                return cl_cotes;
            }


        }
        public Gestion_cotes()
        {
            InitializeComponent();
            remplireAnneeScolaire();
            remplireCmbClasse();
            remplireCmbOption();
            remplirePeriode();
        }

        private void cmbAnneeScolaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnneeScolaire.Text!="" && txtReseach.Text!="" && txtReseach.Text!= "Entrez le matricule Eleve")
            {
                // Récupération de l'élève
                // Selection de l'id 
                MySqlCommand cm = new MySqlCommand("SELECT inscrire.id_inscription,students.stdnames,classes.code_class,options.code_option FROM students,inscrire,school_year,options,classes WHERE (students.num_mat=inscrire.student AND inscrire.id_annee_scol=school_year.id_annee_scol) AND (inscrire.student='"+txtReseach.Text+"' AND school_year.description_annee='"+cmbAnneeScolaire.Text+"') AND (inscrire.code_class=classes.code_class AND inscrire.code_option=options.code_option)", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rde = cm.ExecuteReader();
                cmbCategorieCote.Items.Clear();
                if (rde.Read())
                {
                    txtInscription.Text = rde[0].ToString();
                    txtNoms.Text = rde[1].ToString(); 
                    txtClasse.Text = rde[2].ToString();
                    txtOption.Text = rde[3].ToString();
                }rde.Close();

                if (txtClasse.Text != "" && txtOption.Text != "")
                {
                    // Selection de l'id 
                    MySqlCommand cmd = new MySqlCommand("SELECT categorie_cote.id_categ_cote,courses.descrption_cours FROM affecter_cours,categorie_cote,courses,school_year,options,classes WHERE (affecter_cours.cours=courses.id_cours and affecter_cours.id_affecter_cours=categorie_cote.id_affecter_cours AND options.code_option=affecter_cours.code_option) and (school_year.id_annee_scol=affecter_cours.id_annee_scol AND classes.code_class=affecter_cours.code_class) AND (school_year.description_annee='" + cmbAnneeScolaire.Text + "' AND options.code_option='" + txtOption.Text + "' AND classes.code_class='" + txtClasse.Text + "')", conn.conndb);

                    MySqlDataReader rd = cmd.ExecuteReader();
                    
                    while (rd.Read()) cmbCategorieCote.Items.Add(rd[1].ToString()); rd.Close(); conn.conndb.Close();
                }
            }
            else
            {
                MessageBox.Show("Complétez le matricule");
            }
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            DialogResult reponses = MessageBox.Show("Voulez - vous Enregistrer les cotes ? \n Elève :"+txtNoms.Text+"\n OPTION :"+txtOption.Text+"\n CLASSE : "+txtClasse.Text+"\n COURS :"+cmbCategorieCote.Text+"\n COTE OBTENUE :"+txtCoteObtenue.Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponses == DialogResult.Yes)
            {
                if (cote.coter_eleve(txtCoteObtenue.Text, cmbPeriode.Text, int.Parse(txtAffecter.Text), int.Parse(txtInscription.Text)) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                    txtCoteObtenue.Clear();
                    txtInscription.Clear();
                    txtAffecter.Clear();
                    txtOption.Text = "";
                    txtClasse.Text = "";
                    txtReseach.Text = "Entrez le matricule Eleve";
                    cmbCategorieCote.Text = "";
                    cmbPeriode.Text = "";
                    cmbAnneeScolaire.Text = "";
                    txtNoms.Clear();

                }
                else MessageBox.Show("Echec");

            }

            else 
            { 
                MessageBox.Show("Annulé");
                txtCoteObtenue.Clear();
                txtInscription.Clear();
                txtAffecter.Clear();
                txtOption.Text = "";
                txtClasse.Text = "";
                txtReseach.Text = "Entrez le matricule Eleve";
                cmbCategorieCote.Text = "";
                cmbPeriode.Text = "";
                cmbAnneeScolaire.Text = "";
                txtNoms.Clear();
            }
        }

        private void cmbCategorieCote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnneeScolaire.Text != "" && txtOption.Text != "" && txtClasse.Text != "" && cmbCategorieCote.Text!="")
            {
                // Selection de l'id 
                MySqlCommand cmd = new MySqlCommand("SELECT categorie_cote.id_categ_cote,courses.descrption_cours FROM affecter_cours,categorie_cote,courses,school_year,options,classes WHERE (affecter_cours.cours=courses.id_cours and affecter_cours.id_affecter_cours=categorie_cote.id_affecter_cours AND options.code_option=affecter_cours.code_option) and (school_year.id_annee_scol=affecter_cours.id_annee_scol AND classes.code_class=affecter_cours.code_class AND courses.descrption_cours='" + cmbCategorieCote.Text+"') AND (school_year.description_annee='" + cmbAnneeScolaire.Text + "' AND options.code_option='" + txtOption.Text + "' AND classes.code_class='" + txtClasse.Text + "')", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) txtAffecter.Text=rd[0].ToString(); rd.Close(); conn.conndb.Close();
            }
        }


        // Methode 
        void remplireCmbClasse()
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

        void remplireCmbOption()
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

        void remplireAnneeScolaire()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);

            // Ouverture de la connexion à la BDD
            conn.conndb.Open();

            MySqlDataReader rd = cmd.ExecuteReader();
            cmbAnneeScolaire.Items.Clear();
            comboBox4.Items.Clear();
            while (rd.Read())
            {
                cmbAnneeScolaire.Items.Add(rd[1]).ToString();
                comboBox4.Items.Add(rd[1]).ToString();
            }
            rd.Close();
            conn.conndb.Close();
        }
        void remplirePeriode()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `periode`", conn.conndb);

            // Ouverture de la connexion à la BDD
            conn.conndb.Open();

            MySqlDataReader rd = cmd.ExecuteReader();
            cmbPeriode.Items.Clear();
            while (rd.Read())
            {
                cmbPeriode.Items.Add(rd[4]).ToString();
            }
            rd.Close();
            conn.conndb.Close();
        }

        private void txtReseach_Enter(object sender, EventArgs e)
        {
            if (txtReseach.Text== "Entrez le matricule Eleve")
            {
                txtReseach.Text = "";
            }
        }

        private void txtReseach_Leave(object sender, EventArgs e)
        {
            if (txtReseach.Text == "")
            {
                txtReseach.Text = "Entrez le matricule Eleve";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            // Modification 
        }
    }
}
