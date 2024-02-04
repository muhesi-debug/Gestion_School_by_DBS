using gestion_ecoles.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace gestion_ecoles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pnlParametre.Visible = false;
            pnlParametre.Size = new Size(330, 234);
            parametre.Visible = false;
            pnlMenu.Size = new Size(235, 491);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pnlParametre.Size = new Size(330, 234);
            parametre.Visible = false;
            pnlParametre.Visible = !pnlParametre.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_studient.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_studient.instance);
                controls.Gestion_studient.instance.Dock = DockStyle.Fill;
                controls.Gestion_studient.instance.BringToFront();
            }
            else
            {
                controls.Gestion_studient.instance.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Cl_Gestion_salle.instance))
            {
                pnlAccueil.Controls.Add(controls.Cl_Gestion_salle.instance);
                controls.Cl_Gestion_salle.instance.Dock = DockStyle.Fill;
                controls.Cl_Gestion_salle.instance.BringToFront();
            }
            else
            {
                controls.Cl_Gestion_salle.instance.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_cours.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_cours.instance);
                controls.Gestion_cours.instance.Dock = DockStyle.Fill;
                controls.Gestion_cours.instance.BringToFront();
            }
            else
            {
                controls.Gestion_cours.instance.BringToFront();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_cotes.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_cotes.instance);
                controls.Gestion_cotes.instance.Dock = DockStyle.Fill;
                controls.Gestion_cotes.instance.BringToFront();
            }
            else
            {
                controls.Gestion_cotes.instance.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_frais.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_frais.instance);
                controls.Gestion_frais.instance.Dock = DockStyle.Fill;
                controls.Gestion_frais.instance.BringToFront();
            }
            else
            {
                controls.Gestion_frais.instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_agents.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_agents.instance);
                controls.Gestion_agents.instance.Dock = DockStyle.Fill;
                controls.Gestion_agents.instance.BringToFront();
            }
            else
            {
                controls.Gestion_agents.instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!pnlAccueil.Controls.Contains(controls.Gestion_users.instance))
            {
                pnlAccueil.Controls.Add(controls.Gestion_users.instance);
                controls.Gestion_users.instance.Dock = DockStyle.Fill;
                controls.Gestion_users.instance.BringToFront();
            }
            else
            {
                controls.Gestion_users.instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Déconnexion de l'utilisateur 
            Formulaires.Login logl = new Formulaires.Login();
            logl.ShowDialog();
            
        }

        private void button15_Move(object sender, EventArgs e)
        {
            parametre.Visible = true;
        }

        private void button15_Leave(object sender, EventArgs e)
        {

        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            parametre.Visible = true;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            parametre.Visible = !parametre.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width== 235)
            {
                pnlMenu.Size = new Size(60, 491);
            }
            else
            {
                
                pnlMenu.Size = new Size(235, 491);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            Formulaires.Frm_Sortie_depenses depense = new Formulaires.Frm_Sortie_depenses();
            depense.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Formulaires.FrmCategorieCotes cotes = new Formulaires.FrmCategorieCotes();
            cotes.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Formulaires.Frm_Paiement_agent salaire = new Formulaires.Frm_Paiement_agent();
            salaire.ShowDialog();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Formulaires.FrmCategorieCotes cateCote = new Formulaires.FrmCategorieCotes();
            cateCote.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Formulaires.FrmAjouterMois mois = new Formulaires.FrmAjouterMois();
            mois.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Formulaires.FrmAjouterAnnee annee = new Formulaires.FrmAjouterAnnee();
            annee.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Formulaires.frmCateFrais semestre = new Formulaires.frmCateFrais();
            semestre.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Formulaires.Frm_semestre semestre = new Formulaires.Frm_semestre();
            semestre.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Formulaires.FrmPeriode periode = new Formulaires.FrmPeriode();
            periode.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Formulaires.Frm_School school = new Formulaires.Frm_School();
            school.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Formulaires.Fr_fixation_frais fixation = new Formulaires.Fr_fixation_frais();
            fixation.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Rlivre rp = new Rlivre();
            rp.ShowDialog();
        }

        private void cmdbackup_Click(object sender, EventArgs e)
        {
            frmbackupdatabase fb = new frmbackupdatabase();
            fb.ShowDialog();
        }
    }
}
