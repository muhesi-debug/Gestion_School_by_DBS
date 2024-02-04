using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
    
    class Cl_cotes
    {
        connection conn = new connection();

        public bool ajouter(string description,string id_affecter_cours,string anneescolaire)
        {
            try
            {
                MySqlCommand periode = new MySqlCommand("SELECT affecter_cours.id_affecter_cours FROM affecter_cours,school_year WHERE (school_year.id_annee_scol=affecter_cours.id_annee_scol && school_year.description_annee='" + anneescolaire + "') && cours='" + id_affecter_cours + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdPeriode = periode.ExecuteReader();
                int idAffectecours = 0;
                if (rdPeriode.Read()) idAffectecours = int.Parse(rdPeriode[0].ToString()); rdPeriode.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO categorie_cote(`description`, `id_affecter_cours`) VALUES('" + description + "','" + idAffectecours + "')", conn.conndb);
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
            // Selection de l'id affectation cours

           

            return false;
        }

        // cote des eleves 
        public bool coter_eleve(string cote_obtenue, string id_periode, int id_categ_cote, int id_inscription)
        {
            try
            {
                // Selection de l'id peridoe
                MySqlCommand periode = new MySqlCommand("SELECT * FROM `periode` WHERE description='" + id_periode + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdPeriode = periode.ExecuteReader();
                int idPeriode = 0;
                if (rdPeriode.Read()) idPeriode = int.Parse(rdPeriode[0].ToString()); rdPeriode.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO cote_eleve(`cote_obtenue`, `id_periode`, `id_categ_cote`, `id_inscription`) VALUES('" + cote_obtenue + "','" + idPeriode + "','" + id_categ_cote + "','" + id_inscription + "')", conn.conndb);
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

    }
}
