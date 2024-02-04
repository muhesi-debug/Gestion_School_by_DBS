using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_ecoles.models
{
    public class Cl_Cumule
    {
        models.connection conn = new connection();
        public bool cumuler(int id, decimal montant)
        {
            decimal cml = 0;
            MySqlCommand cmdm = new MySqlCommand("SELECT cumule FROM payement_frais WHERE id_payement_frais='"+id+"'",conn.conndb);
            conn.conndb.Open();
            MySqlDataReader rd = cmdm.ExecuteReader();
            if (rd.Read())
            {
                cml = decimal.Parse(rd[0].ToString()) + montant;
            }
            rd.Close();


            MySqlCommand cmd = new MySqlCommand("UPDATE payement_frais SET cumule='"+cml+ "' WHERE id_payement_frais='"+id+"'", conn.conndb);
            if (cmd.ExecuteNonQuery()==1)
            {
                conn.conndb.Close();
                return true;
            }
            return false;
        }
    }
}
