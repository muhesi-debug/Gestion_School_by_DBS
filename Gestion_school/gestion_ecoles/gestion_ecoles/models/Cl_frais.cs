using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_ecoles.models
{
     class Cl_frais
    {
        connection conn = new connection();
        public bool ajouet(float  montant, string id_categ_frais, string num_secope, string code_option, string code_class, string id_annee_scol)
        {
            try
            {
                //Récupération de l'Id catégorie 

                MySqlCommand cd = new MySqlCommand("SELECT * FROM `categorie_frais` WHERE categorie_frais.description_frais='" + id_categ_frais + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cd.ExecuteReader();
                int idCate = 0;
                if (rd.Read()) idCate = int.Parse(rd[0].ToString()); rd.Close();


                // Récupération de l'id
                MySqlCommand cdz = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                MySqlDataReader rde = cdz.ExecuteReader();
                int idAnne = 0;
                if (rde.Read()) idAnne = int.Parse(rde[0].ToString()); rde.Close();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO frais(`montant`, `id_categ_frais`, `num_secope`, `code_option`, `code_class`, `id_annee_scol`) VALUES( '" + montant + "','" + idCate + "','" + num_secope + "','" + code_option + "','" + code_class + "','" + idAnne + "')", conn.conndb);
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

        // Affectation du cours 
        public bool categorie_frais(string description_frais)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO categorie_frais(`description_frais`) VALUES('" + description_frais + "')", conn.conndb);
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


        // Paiement de frais scolaire 
        public bool paiement_frais_scolaires(string date_paie, double montant_paye, string devise,int taux, string id_categ_frais, string id_semestre, int id_inscription,string id_annee_scol,string option, string classes,string mois,string libelle)
        {

            try
            {
                MySqlCommand moiss = new MySqlCommand("SELECT * FROM mois WHERE description_mois='" + mois + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdMois = moiss.ExecuteReader();
                int idMois = 0;
                if (rdMois.Read()) idMois = int.Parse(rdMois[0].ToString()); rdMois.Close();

                // Selection de l'id de Semestre
                MySqlCommand cateFrais = new MySqlCommand("SELECT * FROM `categorie_frais` WHERE description_frais='" + id_categ_frais + "'", conn.conndb);
                MySqlDataReader rdCatFrais = cateFrais.ExecuteReader();
                int categorieFrais = 0;
                if (rdCatFrais.Read()) categorieFrais = int.Parse(rdCatFrais[0].ToString()); rdCatFrais.Close();

                // Selection de l'id de Semestre
                MySqlCommand semestre = new MySqlCommand("SELECT * FROM `semestre` WHERE description_sem='" + id_semestre + "'", conn.conndb);
                MySqlDataReader rdSemestre = semestre.ExecuteReader();
                int idSemestre = 0;
                if (rdSemestre.Read()) idSemestre = int.Parse(rdSemestre[0].ToString()); rdSemestre.Close();
                // Selection de l'id Année Scolaire
                MySqlCommand annee = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                MySqlDataReader rdAnnee = annee.ExecuteReader();
                int idAnne = 0;
                if (rdAnnee.Read()) idAnne = int.Parse(rdAnnee[0].ToString()); rdAnnee.Close();

                // Selection de l'id Frais
                MySqlCommand frais = new MySqlCommand("SELECT id_frais FROM `frais` WHERE (frais.id_categ_frais='" + categorieFrais + "' && frais.id_annee_scol='" + idAnne + "') && (frais.code_option='" + option + "'&& frais.code_class='" + classes + "') ", conn.conndb);
                MySqlDataReader rdFrais = frais.ExecuteReader();
                int idFrais = 0;
                if (rdFrais.Read()) idFrais = int.Parse(rdFrais[0].ToString()); rdFrais.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO  payement_frais(date_paie, montant_paye, devise, taux, libelle, id_inscription) VALUES('" + date_paie + "','" + montant_paye + "', '" + devise + "','" + taux + "','" + libelle + "','" + id_inscription + "')", conn.conndb);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();

            }// Selection de l'id de Semestre
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return false;
        }




        // Paiement de frais scolaire 
        public bool affecter_frais(string Date_Aff, decimal montant_affect, string id_anneeS, string id_catF, string id_semestre, string mois,int id_payement_frais)
        {

            try
            {
                MySqlCommand moiss = new MySqlCommand("SELECT * FROM mois WHERE description_mois='" + mois + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdMois = moiss.ExecuteReader();
                int idMois = 0;
                if (rdMois.Read()) idMois = int.Parse(rdMois[0].ToString()); rdMois.Close();

                // Selection de l'id de Semestre
                MySqlCommand cateFrais = new MySqlCommand("SELECT * FROM `categorie_frais` WHERE description_frais='" + id_catF + "'", conn.conndb);
                MySqlDataReader rdCatFrais = cateFrais.ExecuteReader();
                int categorieFrais = 0;
                if (rdCatFrais.Read()) categorieFrais = int.Parse(rdCatFrais[0].ToString()); rdCatFrais.Close();

                // Selection de l'id de Semestre
                MySqlCommand semestre = new MySqlCommand("SELECT * FROM `semestre` WHERE description_sem='" + id_semestre + "'", conn.conndb);
                MySqlDataReader rdSemestre = semestre.ExecuteReader();
                int idSemestre = 0;
                if (rdSemestre.Read()) idSemestre = int.Parse(rdSemestre[0].ToString()); rdSemestre.Close();
                // Selection de l'id Année Scolaire
                MySqlCommand annee = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_anneeS + "'", conn.conndb);
                MySqlDataReader rdAnnee = annee.ExecuteReader();
                int idAnne = 0;
                if (rdAnnee.Read()) idAnne = int.Parse(rdAnnee[0].ToString()); rdAnnee.Close();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO  aff_frais(`Date_Aff`, `montant_affect`, `id_anneeS`, `id_catF`, `id_semestre`, `id_mois`, `id_payement_frais`) VALUES('" + Date_Aff+ "','" +montant_affect + "', '" +idAnne + "','" + categorieFrais + "','" + idSemestre + "','" + idMois + "','" + id_payement_frais + "')", conn.conndb);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();

            }// Selection de l'id de Semestre
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}
