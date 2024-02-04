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
    public partial class Frm_ajouterUsers : Form
    {
        // Appel de la classe users
        models.Cl_users user = new models.Cl_users();
        public Frm_ajouterUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (txtMotDePasse.Text != "" && txtNomUtilisateur.Text != "")
            {
                if (user.ajouter(txtNomUtilisateur.Text, txtMotDePasse.Text, cmbFonction.Text) == true)
                {
                    MessageBox.Show("Enregistrement réussi");
                }
                else MessageBox.Show("Echec");
            }
            else MessageBox.Show("Les champs sont obligatoires");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Modifier
            if (user.modifier(int.Parse(txtId.Text),txtNomUtilisateur.Text,txtMotDePasse.Text,cmbFonction.Text) == true)
            {
                MessageBox.Show("Modification résussie");
                Close();
            }
            else MessageBox.Show("Modification échouée");
        }
    }
}
