using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
   class Cl_periode
    {
        // Addd période 
        connection connexion = new connection();
        public bool ajouter(string semestre, string description,String dateDebut, string dateFin)
        {
            try
            {
                MySqlCommand cm = new MySqlCommand("SELECT * from semestre WHERE description_sem='" + semestre + "'", connexion.conndb);
                connexion.conndb.Open();
                MySqlDataReader rd = cm.ExecuteReader();
                int id = 0;
                if (rd.Read())
                {
                    id = int.Parse(rd[0].ToString());

                }
                rd.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO periode(`date_debut`, `date_fin`, `id_semestre`, `description`) VALUES('" + dateDebut + "','" + dateFin + "','" + id + "','" + description + "')", connexion.conndb);

                // Ouverture de la connexion

                if (cmd.ExecuteNonQuery() == 1)
                {
                    connexion.conndb.Close();
                    return true;
                }
                else
                {
                    connexion.conndb.Close();
                   
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
            
        }


        // suppression de la période 
        public bool supprimer(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM periode WHERE id_periode='" + id + "'", connexion.conndb);
                connexion.conndb.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    connexion.conndb.Close();
                    return true;
                }
                else
                {
                    connexion.conndb.Close();
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        
    }
}
