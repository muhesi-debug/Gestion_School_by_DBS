using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
     class Cl_semestre
    {
        // Addd période 
        connection connexion = new connection();
        public bool ajouter(string description, string dateDebut, string dateFin)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO semestre(`date_debut_sem`, `date_fin_sem`,`description_sem`) VALUES('" + dateDebut + "','" + dateFin + "','" + description + "')", connexion.conndb);

                // Ouverture de la connexion
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
