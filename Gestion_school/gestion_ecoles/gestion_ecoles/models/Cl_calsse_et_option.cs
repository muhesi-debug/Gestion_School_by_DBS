using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
     class Cl_calsse_et_option
    {
        // Connexion à la base de données
        connection con = new connection();
         // Ajout de la classe
        public bool ajouter_classe(string code, string desc)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO classes(`code_class`, `description_class`) VALUES('" + code + "','" + desc + "')", con.conndb);
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

        // Ajout de l'option
        public bool ajouter_option(string code, string desc)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO options(code_option, description_option) VALUES('" + code + "','" + desc + "')", con.conndb);
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
        public bool supprimeClasse(string index) 
        {

            try
            {

                MySqlCommand cmd = new MySqlCommand("DELETE FROM classes WHERE code_class='" + index + "'", con.conndb);
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

        public bool supprimeOption(string index)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("DELETE FROM options WHERE code_option='" + index + "'", con.conndb);
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
        public bool modiOption(string index, string description)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("UPDATE options SET description_option='" + description+"'  WHERE code_option='" + index + "'", con.conndb);
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
        public bool modiClasse(string index, string description)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("UPDATE classes SET description_class='" + description + "'  WHERE code_class='" + index + "'", con.conndb);
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
