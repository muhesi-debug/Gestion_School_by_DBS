using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gestion_ecoles.models
{
     class Cl_agents
    {
        string matAgent;
        connection conn = new connection();
        public bool ajouter(string id_agent, string noms_agent, string genre, string grade, string fonction, string phone,string ecoles)
        {
            try
            {
                // Compteur 
                MySqlCommand cd = new MySqlCommand("SELECT COUNT(id_agent) as compte FROM agent", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cd.ExecuteReader();
                int num = 0;
                if (rd.Read()) num = int.Parse(rd[0].ToString()) + 1; rd.Close();
                // Forme de matricume
                matAgent = id_agent + " " + num + "/ 2023";
                MySqlCommand cmd = new MySqlCommand("INSERT INTO agent(`id_agent`, `noms_agent`, `genre`, `grade`, `fonction`, `phone`,num_secop) VALUES('" + matAgent + "','" + noms_agent + "','" + genre + "','" + grade + "','" + fonction + "','" + phone + "','" + ecoles + "')", conn.conndb);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.conndb.Close();
                    return true;
                }
                conn.conndb.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            
            }
            
            return false;
        }

        // Affectation agent dans une option
        public bool affecter_agent_in_option(string code_option, string anneeScoalire)
        {

            try
            {

                MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + anneeScoalire + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rd = cd.ExecuteReader();
                int idAnne = 0;
                if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO affecter_agent_options(`id_agent`, `code_option`, `anneeScoalire`) VALUES('" + matAgent + "','" + code_option + "','" + idAnne + "')", conn.conndb);
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

        public bool modifier(string id_agent, string noms_agent, string genre, string grade, string fonction, string phone)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE agent SET id_agent='" + id_agent + "',noms_agent='" + noms_agent + "',genre='" + genre + "',grade='" + grade + "',fonction='" + fonction + "',phone='" + phone + "' WHERE id_agent='" + id_agent + "'", conn.conndb);
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

        public bool supprimer(string id_agent)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("DELETE FROM agent WHERE id_agent='" + id_agent + "'", conn.conndb);
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

        // Affectation de l'agent en une année scolaire
        public bool affect_agent(string id_agent,string codeOption,int anneeScoalire)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("INSERT INTO  affecter_agent_options(`id_affecter_ag_opt`, `id_agent`, `code_option`,anneeScoalire) VALUES('" + id_agent + "','" + codeOption + "','" + anneeScoalire + "')", conn.conndb);
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
        // Paiement agents 
        public bool paiement_prime_agent(float montant_prime, string libelle, string id_categ_frais, string id_agent, string id_mois, string id_annee_scol,string datefin )
        {
            try
            {
                // Récupération de l'id categorie de frais
                MySqlCommand cateFrais = new MySqlCommand("SELECT * FROM `categorie_frais` WHERE description_frais='" + id_categ_frais + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdFrais = cateFrais.ExecuteReader();
                int idCategorieFrais = 0;
                if (rdFrais.Read()) idCategorieFrais = int.Parse(rdFrais[0].ToString()); rdFrais.Close();

                // Récupération de l'id de mois
                MySqlCommand mois = new MySqlCommand("SELECT * FROM `mois` WHERE description_mois='" + id_mois + "'", conn.conndb);
                MySqlDataReader rdmois = mois.ExecuteReader();
                int idMois = 0;
                if (rdmois.Read()) idMois = int.Parse(rdmois[0].ToString()); rdmois.Close();

                // Recupération de l'id année scolaire
                MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                MySqlDataReader rd = cd.ExecuteReader();
                int idAnne = 0;
                if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO payement_prime_agent(`montant_prime`, `libelle`, `id_categ_frais`, `id_agent`, `id_mois`, `id_annee_scol`,datePaiment) VALUES('" + montant_prime + "', '" + libelle + "','" + idCategorieFrais + "','" + id_agent + "','" + idMois + "','" + idAnne + "','" + datefin + "')", conn.conndb);
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


        // Depenses 
        public bool depenses(int iddepense, string date_depense,string motif)
        {
            try
            {
                conn.conndb.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO depenses(`id_depense`, `date_depense`, `motif`) VALUES('" +iddepense+ "','" + date_depense + "','" +motif + "')", conn.conndb);
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


        public bool aff_depneses(int iddepense,string date_depense, decimal montant_depense, string id_categ_frais, string id_annee_scol, string mois,string Semestre)
        {
            try
            {
                // Récupération de l'id categorie de frais
                MySqlCommand cateFrais = new MySqlCommand("SELECT * FROM `categorie_frais` WHERE description_frais='" + id_categ_frais + "'", conn.conndb);
                conn.conndb.Open();
                MySqlDataReader rdFrais = cateFrais.ExecuteReader();
                int idCategorieFrais = 0;
                if (rdFrais.Read()) idCategorieFrais = int.Parse(rdFrais[0].ToString()); rdFrais.Close();


                // Récupération de l'id Mois
                MySqlCommand cateMois = new MySqlCommand("SELECT * FROM `mois` WHERE description_mois='" + mois + "'", conn.conndb);
                MySqlDataReader rdMois = cateMois.ExecuteReader();
                int idCategorieMois = 0;
                if (rdMois.Read()) idCategorieMois = int.Parse(rdMois[0].ToString()); rdMois.Close();

                // Recupération de l'id année scolaire
                MySqlCommand cd = new MySqlCommand("SELECT * FROM school_year WHERE description_annee='" + id_annee_scol + "'", conn.conndb);
                MySqlDataReader rd = cd.ExecuteReader();
                int idAnne = 0;
                if (rd.Read()) idAnne = int.Parse(rd[0].ToString()); rd.Close();

                // Recupération du semestre
                MySqlCommand cdm = new MySqlCommand("SELECT * FROM semestre WHERE description_sem='" + Semestre + "'", conn.conndb);
                MySqlDataReader rdm = cd.ExecuteReader();
                int idSemestre = 0;
                if (rdm.Read()) idSemestre = int.Parse(rdm[0].ToString()); rdm.Close();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO aff_depenses(`Date_AffD`, `montant_affectD`, `id_anneeS`, `id_catF`, `id_semestre`, `id_mois`, `id_depense`) VALUES('" + date_depense + "','" + montant_depense + "','" + idAnne + "','" + idCategorieFrais + "','" + idSemestre + "','" + idCategorieMois + "','" + iddepense + "')", conn.conndb);
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
