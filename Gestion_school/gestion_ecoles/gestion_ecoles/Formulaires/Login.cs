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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace gestion_ecoles.Formulaires
{
    public partial class Login : Form
    {
        connection con = new connection();
        
        public Login()
        {

            con.conndb.Open();//appell de la classe de connexion 
            InitializeComponent();
            btnInvisible.Visible = false;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '*';
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "  Nom d'utilisateur ") txtUsername.Text = "";
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "") txtUsername.Text = "  Nom d'utilisateur ";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "   Mot de passe")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '*';
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "   Mot de passe";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddClasse_Click(object sender, EventArgs e)
        {
            // Connexion de l'utilisateur
            try
            {

                var db = new MySqlCommand("select from users where username=" + txtUsername.Text + " and password=" + txtPassword.Text + "", con.conndb);
                Form1 princiapl = new Form1();
                princiapl.ShowDialog();
                this.Close();
                if (txtPassword.Text == "" && txtUsername.Text == "")
                {
                    MessageBox.Show("Verifie les champs vide");
                }
                else MessageBox.Show("Coordonnés incorects");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {

                con.conndb.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checkBox1.Checked = true;
        }

        private void btnInvisible_Click(object sender, EventArgs e)
        {
            // rendre invisible
            // checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "   Mot de passe")
            {
                if (checkBox1.Checked == false)
                {
                    button2.Visible = false;
                    btnInvisible.Visible = true;
                    txtPassword.UseSystemPasswordChar = true;

                }
                else
                {
                    button2.Visible = true;
                    btnInvisible.Visible = false;
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.PasswordChar = '*';
                }
            }
        }

        private void btnInvisible_Enter(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void button2_Enter(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}