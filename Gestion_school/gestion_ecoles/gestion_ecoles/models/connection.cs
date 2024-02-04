using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using gestion_ecoles.Properties;
using gestion_ecoles.Services;
namespace gestion_ecoles.models
{
    class connection
    {
        public static string ip_ { set; get; }
        public static string port_ { set; get; }
        public static string mode_ { set; get; }
        public static string database_ { set; get; }
        public static string username_ { set; get; }
        public static string password_ { set; get; }


        public MySqlConnection conndb;
        public connection()
        {
            try
            {
                
                string host = "localhost";
                string database = "dbschool";
                string username = "root";
                string password = "hervainliko98";
                string connection_string = "datasource =" + host + "; database=" + database + ";username=" + username + ";password=" + password + "";
                conndb = new MySqlConnection(connection_string);

            }
            catch ( Exception e){ 
            
              MessageBox.Show(e.Message);
            }
        }


        public static void try_connexion()
        {
            try
            {
                //creation et instentiation de la variable de test de connection conn_
                MySqlConnection conn_ = new MySqlConnection();

                string connection_string = "server=" + ip_ + "; port=" + port_ + "; user=" + username_ + "; password=" + password_ + "; database=" + database_ + "; Max Pool Size=50000; Pooling=True";

                conn_ = new MySqlConnection(connection_string);

                if (conn_.State == ConnectionState.Closed)
                {
                    conn_.Open();
                    System.Runtime.Remoting.Services.MsgFRM msg = new System.Runtime.Remoting.Services.MsgFRM();
                    msg.getInfo("Connexion établie");

                }
                else
                {
                    conn_.Close();
                    System.Runtime.Remoting.Services.MsgFRM msg = new System.Runtime.Remoting.Services.MsgFRM();
                    msg.getError("Connexion échouer");
                }
            }
            catch (Exception)
            {
                System.Runtime.Remoting.Services.MsgFRM msg = new System.Runtime.Remoting.Services.MsgFRM();
                msg.getError("Connexion échouer");
            }
        }

    }
}
