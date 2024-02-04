using gestion_ecoles.Formulaires;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
    class Cl_etudiant
    {
        public string mat;
        connection conn = new connection();
        string num = "00000";
        int compt;
        public bool ajouter(string num_mat, string stdnames, string genre, string lieu_naissance, string date_naissance, byte[] photo_eleve, string ecole_provenance, string religion, string adresse, string documents_deposes, string tuteur, string tele_tuteur, string noms_pere, string profession_pere, string noms_mere, string annee)
        {
            // Création de matricule de l'élève 
            try
            {

                // Compteur 
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(num_mat) as compte from students", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    compt = int.Parse(rd[0].ToString()) + 1;
                }
                rd.Close();
                mat = num_mat + "" + compt + "/" + annee;

                // Enregistrement
                MySqlCommand cm = new MySqlCommand("INSERT INTO students(`num_mat`, `stdnames`, `genre`, `lieu_naissance`, `date_naissance`, `photo_eleve`, `ecole_provenance`, `religion`, `adresse`, `documents_deposes`, `tuteur`, `tele_tuteur`, `noms_pere`, `profession_pere`, `noms_mere`) VALUES('" + mat + "','" + stdnames + "', '" + genre + "','" + lieu_naissance + "','" + date_naissance + "','" + photo_eleve + "','" + ecole_provenance + "', '" + religion + "','" + adresse + "','" + documents_deposes + "','" + tuteur + "','" + tele_tuteur + "','" + noms_pere + "','" + profession_pere + "','" + noms_mere + "')", conn.conndb);
                if (cm.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
                return false;
            }
            conn.conndb.Close();
            return false;
        }

        // Inscription eleve 
        public bool inscrire_Student(string date_inscription, string code_class, string code_option, string id_annee_scol, string num_secope)
        {
            try
            {
                MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cd.ExecuteReader();
                int idAnne = 0;
                if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();
                MySqlCommand inscrire = new MySqlCommand("INSERT INTO  inscrire(`date_inscription`, `code_class`, `code_option`, `id_annee_scol`, `num_secope`, `student`) VALUES('" + date_inscription + "','" + code_class + "','" + code_option + "', '" + idAnne + "', '" + num_secope + "','" + mat + "')", conn.conndb);

                if (inscrire.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
                return false;
            }
            conn.conndb.Close();
            return false;
        }

        public bool modifier(string num_mat, string stdnames, string genre, string lieu_naissance, string date_naissance, byte[] photo_eleve, string ecole_provenance, string religion, string adresse, string documents_deposes, string tuteur, string tele_tuteur, string noms_pere, string profession_pere, string noms_mere, string annee)
        {
            // Création de matricule de l'élève 
            try
            {

                // Compteur 
                //MySqlCommand cmd = new MySqlCommand("SELECT COUNT(num_mat) as compte from students", conn.conndb);
                //conn.conndb.Open();
                //MySqlDataReader rd = cmd.ExecuteReader();
                //if (rd.Read())
                //{
                //    compt = int.Parse(rd[0].ToString()) + 1;
                //}
                //rd.Close();
                //mat = num_mat + "" + compt + "/" + annee;

                // Enregistrement
                MySqlCommand cm = new MySqlCommand("UPDATE  students SET `num_mat`='" + num_mat + "', `stdnames`='" + stdnames + "', `genre`='" + genre + "', `lieu_naissance`='" + lieu_naissance + "', `date_naissance`='" + date_naissance + "', `photo_eleve`='" + photo_eleve + "', `ecole_provenance`='" + ecole_provenance + "', `religion`='" + religion + "', `adresse`='" + adresse + "', `documents_deposes`='" + documents_deposes + "', `tuteur`='" + tuteur + "', `tele_tuteur`='" + tele_tuteur + "', `noms_pere`='" + noms_pere + "', `profession_pere`='" + profession_pere + "', `noms_mere`='" + noms_mere + "' WHERE `num_mat`='" + num_mat + "' ", conn.conndb);
                conn.conndb.Open();
                if (cm.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conndb.Close();
                return false;
            }

            return false;
        }

        public bool supremmer(string mat)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM students WHERE num_mat='" + mat + "'", conn.conndb);
                conn.conndb.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;

                }
                else
                {
                    conn.conndb.Close();
                   
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
