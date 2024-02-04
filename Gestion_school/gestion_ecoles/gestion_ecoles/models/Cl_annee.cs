using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
    class Cl_annee
    {
        connection con = new connection();
        public bool ajoute(string description)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO school_year(`description_annee`) VALUES('" + description + "')", con.conndb);
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
        public bool supprimer(int index)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM school_year WHERE id_annee_scol='" + index + "' ", con.conndb);
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

        public bool modifier(int index,string description)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE school_year SET description_annee='" + description + "' WHERE id_annee_scol='" + index + "' ", con.conndb);
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
    }
}
