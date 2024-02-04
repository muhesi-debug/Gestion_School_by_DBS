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
    public partial class Frm_School : Form
    {
        models.Cl_School school = new models.Cl_School();
        public Frm_School()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Services.MsgFRM msg = new Services.MsgFRM();
            try
            {
                if (txtNumSecop.Text != "" && txtNomEcole.Text != "" && txtAdresse.Text != "" && txtRx.Text != "")
                {
                    if (school.ajouter(txtNumSecop.Text, txtNomEcole.Text, txtAdresse.Text, txtRx.Text,txtPays.Text,txtPronvince.Text,txtVille.Text,txtCommune.Text) == true) MessageBox.Show("Enregistrement réussi");
                    else MessageBox.Show("Echec");
                    txtAdresse.Clear();
                    txtNumSecop.Clear();
                    txtNomEcole.Clear();
                    txtRx.Clear();
                    msg.getInfo("succes");

                }
                else MessageBox.Show("Tous les champs sont nécessaires");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            
    }
}
