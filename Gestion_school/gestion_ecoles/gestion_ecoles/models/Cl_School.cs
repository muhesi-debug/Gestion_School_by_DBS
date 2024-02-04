using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
    class Cl_School
    {
        connection conn = new connection();

        public bool ajouter(string num_secope, string nom_ecole,string adresse_ecole,string Rx,string pays, string province, string ville_territoire, string commune_chefferi)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO school(`num_secope`, `nom_ecole`, `reseau`, `pays`, `province`, `ville_territoire`, `commune_chefferi`) VALUES('" + num_secope + "','" + nom_ecole + "','" + adresse_ecole + "','" + Rx + "','"+pays+"','"+province+"','"+ville_territoire+"','"+commune_chefferi+"')", conn.conndb);
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
    }
}
