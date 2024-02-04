using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace gestion_ecoles.Formulaires
{
    public partial class Fr_inscrire_Student : Form
    {
        // création de l'instance de la classe Student
        models.Cl_etudiant eleve = new models.Cl_etudiant();

        // La connxion 
        models.connection conn = new models.connection();
        public Fr_inscrire_Student()
        {
            InitializeComponent();

            // Initilisation au lancement de l application 
            remplireAnneeScolaire();
            remplireCmbClasse();
            remplireCmbOption();
            remplireEcole();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "|*.PNG;*.JPG;*.GIF;*.BMP;*.TIF";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pctImageEleve.Image = System.Drawing.Image.FromFile(op.FileName);
               // pctImageEleve.Image =Image.FromFile(op.FileName);
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                // Convertir image en format byte
                // Ajouter System.IO
                MemoryStream mr = new MemoryStream();
                pctImageEleve.Image.Save(mr, pctImageEleve.Image.RawFormat);
                byte[] EleveImage = mr.ToArray(); // Convertir image en format byte

                // enregistrement de l'elève
                if (obligatoirChamp() == null)
                {
                    // Création de matricule de l'élève
                    string matEleve1 = txtnomEleve.Text.Substring(0, 2);
                    string matEleve2 = txtPostnomEleve.Text.Substring(0, 2);
                    string matricule = matEleve1 + "" + matEleve2;
                    string noms = txtnomEleve.Text + " " + txtPostnomEleve.Text + " " + txtPrenomEleve.Text;
                    //Conversion du format de la date
                    string dateNaissance = string.Format("{0}-{1}-{2}", dateNaissnceEleve.Value.Year, dateNaissnceEleve.Value.Month, dateNaissnceEleve.Value.Day);
                    string dateInscripti = string.Format("{0}-{1}-{2}", dateInscription.Value.Year, dateInscription.Value.Month, dateInscription.Value.Day);
                    string annee = dateInscripti.Substring(0, 4);
                    // Appel de la classe d'enregistrement de l'élève
                    if (eleve.ajouter(matricule, noms, cmbGenreEleve.Text, txtLieuNaissanceEleve.Text, dateNaissance, EleveImage, txtEcoleProv.Text, txtReligion.Text, txtAdresse.Text, txtDocDeposes.Text, txtNomTuteur.Text, txtTelephoneTuteur.Text, txtNomPere.Text, txtProfessionPere.Text, txtNomMere.Text, annee) == true)
                    {
                        eleve.inscrire_Student(dateInscripti, cmbClasse.Text, cmbOption.Text, cmbAnneeScolaire.Text, txtSecope.Text);
                        MessageBox.Show("Enregistrement élève réussi");
                    }
                    else
                    {
                        MessageBox.Show("Un problème s'est produit lors de l'opération réessayer");
                    }
                }
                else
                {
                    MessageBox.Show(obligatoirChamp());
                }

            }
            catch ( Exception ex){ 
            MessageBox.Show(ex.Message );
            }

        }


        // Vérification de champs
        string obligatoirChamp()
        {
            if (txtnomEleve.Text == "") return "Entrez le nom de l'élève";
            if (txtPostnomEleve.Text == "") return "Entrez le Postnom de l'élève";
            if (txtPrenomEleve.Text == "") return "Entrez le Prenom de l'élève";
            if (cmbGenreEleve.Text == "") return "Chosissez le genre de l'élève";
            //if (txtLieuNaissanceEleve.Text == "") return "Entrez le lieu de naissance de l'élève";
            //if (txtEcoleProv.Text== "") return "Entrez l\'école de l'élève";
            //if (txtDocDeposes.Text == "") return "Entrez le documents deposé par l'élève";
            //if (txtReligion.Text== "") return "Entrez la religion  de l\'élève";
            if (txtAdresse.Text == "") return "Entrez l\'adresse de l'élève";

            // Parents
            //if (txtNomPere.Text == "") return "Entrez les noms du Père";
            //if (txtNomMere.Text == "") return "Entrez les noms de la Mère";
            //if (txtProfessionPere.Text == "") return "Entrez la profession du tuteur";
            //if (txtTelephoneTuteur.Text == "") return "Entrez les numéro de téléphone du tuteur";
            //if (cmbClasse.Text == "") return "Chsoisissez la classe d'incription de l\'élève";
            //if (cmbOption.Text == "") return "Chsoisissez l\'option d'incription de l\'élève";
            //if (cmbAnneeScolaire.Text == "") return "Chsoisissez l\'année scolaire d'incription de l\'élève";
            //if (pctImageEleve.Image == null) return "Choisissez l\'image de l\'élève";

            return null;
        }

        // Methode 
        void remplireCmbClasse()
        {

            try
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                conn.conndb.Close();
            }
            
            
        }

        void remplireCmbOption()
        {
            try
            {
                // Ouverture de la connexion à la BDD
                conn.conndb.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM options", conn.conndb);
                MySqlDataReader rd = cmd.ExecuteReader();
                cmbOption.Items.Clear();
                while (rd.Read())
                {
                    cmbOption.Items.Add(rd[0]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
            }
           
        }

        void remplireAnneeScolaire()
        {

            try {
                // Ouverture de la connexion à la BDD
                conn.conndb.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school_year", conn.conndb);



                MySqlDataReader rd = cmd.ExecuteReader();
                cmbAnneeScolaire.Items.Clear();
                while (rd.Read())
                {
                    cmbAnneeScolaire.Items.Add(rd[1]).ToString();
                }
                rd.Close();
                conn.conndb.Close();
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();

            }
            
            
        }

        void remplireEcole()
        {
            try
            {
                conn.conndb.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school", conn.conndb);

                // Ouverture de la connexion à la BDD
                

                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtSecope.Text = rd[0].ToString();
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //if (eleve.modifier(txtMat.Text,txtnomEleve.Text,cmbGenreEleve.Text,txtLieuNaissanceEleve.Text,dateNaissnceEleve,photo_eleve,txtEcoleProv.Text,txtReligion.Text,txtAdresse.Text,txtDocDeposes.Text,txtNomTuteur.Text,txtTelephoneTuteur.Text,txtNomPere.Text,txtProfessionPere.Text,txtNomMere.Text)==true)
            //{
            //    MessageBox.Show("Modification réussie");
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Modification échouée");
            //}
        }
    }
}
