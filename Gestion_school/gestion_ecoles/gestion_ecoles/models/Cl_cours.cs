using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
    class Cl_cours
    {
        connection conn = new connection();
        string id_cours;
        public bool ajouet(string descrption_cours)
        {
            try
            {
                string partCode = descrption_cours.Substring(0, 4);

                MySqlCommand cd = new MySqlCommand("SELECT COUNT(id_cours) FROM courses", conn.conndb);
                conn.conndb.Open();

                MySqlDataReader rd = cd.ExecuteReader();
                int num = 0;
                if (rd.Read()) num = int.Parse(rd[0].ToString()) + 1; rd.Close();

                // Code 
                id_cours = partCode + " " + num;
                MySqlCommand cmd = new MySqlCommand("INSERT INTO courses(`id_cours`, `descrption_cours`) VALUES( '" + id_cours + "','" + descrption_cours + "')", conn.conndb);
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
            // code cours
           
            return false;
        }

        // Affectation du cours 
        public bool affecter_cours(int nbre_heures, int ponderation, string code_option, string code_class, string id_annee_scol, string num_secope, string cours)
        {
            try
            {
                MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cd.ExecuteReader();
                int idAnne = 0;
                if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO  affecter_cours(`nbre_heures`, `ponderation`, `code_option`, `code_class`, `id_annee_scol`, `num_secope`, `cours`) VALUES('" + nbre_heures + "','" + ponderation + "','" + code_option + "','" + code_class + "','" + idAnne + "','" + num_secope + "','" + cours + "')", conn.conndb);
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


        // Suppresssion 
        public bool supprimer(string index) 
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM courses WHERE id_cours='" + index + "'", conn.conndb);
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

        // Modification 
        public bool modifier(string index, string description) 
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE courses SET `descrption_cours`='" + description + "' WHERE id_cours='" + index + "'", conn.conndb);
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
               MessageBox.Show(ex.InnerException.Message);
            }
            return false;
            }
            
    }
}
