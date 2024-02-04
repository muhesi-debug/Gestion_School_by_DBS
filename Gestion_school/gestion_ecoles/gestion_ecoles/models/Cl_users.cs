using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gestion_ecoles.models
{
    class Cl_users
    {

        // Appel de la classe de la connexion 
        connection conn = new connection();

        public bool ajouter(string username,string password, string fonction)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into users(`username`, `password`, `fonction`) VALUES('" + username + "','" + password + "','" + fonction + "')", conn.conndb);

                // Ouverture de la connexion
                conn.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return false;
        }

        // Modification
        public bool modifier(int index,string username, string password, string fonction)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE users SET `username`='" + username + "', `password`='" + password + "', `fonction`='" + fonction + "' WHERE id_user='" + index + "'", conn.conndb);

                // Ouverture de la connexion
                conn.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            
            return false;
        }

        // Suppression
        public bool supprimer(int index)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM users  WHERE id_user='" + index + "'", conn.conndb);

                // Ouverture de la connexion
                conn.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();

            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return false;
        }
    }
}
