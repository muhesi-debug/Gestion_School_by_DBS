using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
     class Cl_mois
    {
        connection con = new connection();
        public bool ajouter(String description)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO mois(`description_mois`) VALUES('" + description + "')", con.conndb);
                con.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    con.conndb.Close();
                    return true;
                }
                con.conndb.Close();
            }
            catch (Exception ex)
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM mois WHERE id_mois='" + index + "'", con.conndb);
                con.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    con.conndb.Close();
                    return true;
                }
                con.conndb.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
            return false;
        }

         // Mofdification
        public bool modifier(int index, string description)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE mois SET description_mois='" + description + "' WHERE id_mois='" + index + "'", con.conndb);
                con.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    con.conndb.Close();
                    return true;
                }
                con.conndb.Close();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            return false;
        }
    }
}
