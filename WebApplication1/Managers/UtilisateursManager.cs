using Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
namespace Classes.Managers
{
    internal static class UtilisateurManager
    {
     
        //Methode pour avoir info de la bdd recuperer
        internal static Utilisateurs Load(int id)
        {
            Utilisateurs item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Soignant WHERE Id=@idUser", cnx))
                {
                    cmd.Parameters.Add(new MySqlParameter("@idUser", id));
                    cnx.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            item = new Utilisateurs();
                            fill(item, dr);
                        }
                    }
                }
            }

            return item;
        }

        internal static List<Utilisateurs> LoadMalade(int idSoignant)
        {
            List<Utilisateurs> item = null;
            using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
            {
                //Faire une commande avec cle etrangere pour recuperer les malades d un soiganant avec cle etrangere
                //using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Soignant WHERE Id=@idUser", cnx))
                //{
                //    cmd.Parameters.Add(new MySqlParameter("@idUser", id));
                //    cnx.Open();
                //    using (MySqlDataReader dr = cmd.ExecuteReader())
                //    {
                //        if (dr.Read())
                //        {
                //            item = new Utilisateurs();
                //            fill(item, dr);
                //        }
                //    }
                //}
            }
            return item;
        }

        //internal static Utilisateurs Search(string nom, string prenom, string motdepasse)
        //{
        //    Utilisateurs item = null;
        //    using (SqlConnection cnx = new SqlConnection(Config.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateurs WHERE ut_nom=@nom AND ut_prenom=@prenom AND ut_motdepasse=@motdepasse ", cnx))
        //        {
        //            cmd.Parameters.Add(new SqlParameter("@nom", nom));
        //            cmd.Parameters.Add(new SqlParameter("@prenom", prenom));
        //            cmd.Parameters.Add(new SqlParameter("@motdepasse", motdepasse));
        //            cnx.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    item = new Utilisateurs();
        //                    fill(item, dr);
        //                }
        //            }
        //        }
        //    }

        //    return item;
        //}

        //internal static Utilisateurs Search(string email, string password)
        //{
        //    Utilisateurs item = null;
        //    using (SqlConnection cnx = new SqlConnection(Config.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateurs WHERE ut_email=@email AND ut_password=@password", cnx))
        //        {
        //            cmd.Parameters.Add(new SqlParameter("@email", email));
        //            cmd.Parameters.Add(new SqlParameter("@password", password));

        //            cnx.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    item = new Utilisateurs();
        //                    fill(item, dr);
        //                }
        //            }
        //        }
        //    }

        //    return item;
        //}

        //internal static Utilisateurs SearchByHash(int id, string hash)
        //{
        //    Utilisateurs item = null;
        //    using (SqlConnection cnx = new SqlConnection(Config.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateurs WHERE ut_id=@id", cnx))
        //        {
        //            cmd.Parameters.Add(new SqlParameter("@id", id));

        //            cnx.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    item = new Utilisateurs();
        //                    fill(item, dr);
        //                    if (item.Motdepasse != hash)
        //                        item = null;
        //                }
        //            }
        //        }
        //    }

        //    return item;
        //}

        //internal static List<Utilisateurs> List()
        //{
        //    List<Utilisateurs> list = new List<Utilisateurs>();
        //    using (SqlConnection cnx = new SqlConnection(Config.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateurs ORDER BY ut_id", cnx))
        //        {

        //            cnx.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    Utilisateurs item = new Utilisateurs();
        //                    fill(item, dr);
        //                    list.Add(item);
        //                }
        //            }
        //        }
        //    }

        //    return list;
        //}

        //Prendre ce fill pour recuprer des données
        private static void fill(Utilisateurs item, MySqlDataReader dr)
        {
            item.Id = (int)dr["Id"];
            item.Nom = (string)dr["Nom"];
            item.Prenom = (string)dr["Prenom"];
            item.CourtePresentation = (string)dr["Descriptif"];
        }

        //public List<Utilisateurs> GetAllAlbums()
        //{
        //    List<Album> list = new List<Album>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from Album where id < 10", conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Album()
        //                {
        //                    Id = Convert.ToInt32(reader["Id"]),
        //                    Name = reader["Name"].ToString(),
        //                    ArtistName = reader["ArtistName"].ToString(),
        //                    Price = Convert.ToInt32(reader["Price"]),
        //                    Genre = reader["genre"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}

        internal static void Save(Utilisateurs client)
        {
            if (client.Id == 0)
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Utilisateurs (ut_nom, ut_prenom, ut_motdepasse) VALUES ( @nom, @prenom, @motdepasse)", cnx))
                    {
                        FillSql(cmd, client);

                        cnx.Open();
                        cmd.ExecuteNonQuery();

                        client.Id = Convert.ToInt32(new MySqlCommand("SELECT @@IDENTITY", cnx).ExecuteScalar());
                    }
                }
            }
            else
            {
                using (MySqlConnection cnx = new MySqlConnection(Config.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Utilisateurs SET ut_nom=@nom, ut_prenom@prenom, ut_motdepasse=@motdepasse WHERE ut_id=@id", cnx))
                    {
                        FillSql(cmd, client);

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void FillSql(MySqlCommand cmd, Utilisateurs item)
        {
            cmd.Parameters.Add(new MySqlParameter("@id", item.Id));
            cmd.Parameters.Add(new MySqlParameter("@nom", item.Nom));
            cmd.Parameters.Add(new MySqlParameter("@prenom", item.Prenom));
            cmd.Parameters.Add(new MySqlParameter("@motdepasse", item.Motdepasse));
            cmd.Parameters.Add(new MySqlParameter("@Presentation", item.CourtePresentation));
        }

        //internal static void Delete(Utilisateurs client)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Config.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("DELETE FROM Utilisateurs WHERE ut_id=@id", cnx))
        //        {
        //            cmd.Parameters.Add(new SqlParameter("@id", client.Id));

        //            cnx.Open();
        //            cmd.ExecuteNonQuery();

        //            client.Id = 0;
        //        }
        //    }
        //}
        //internal static int Count()
        //{

        //    using (SqlConnection cnx = new SqlConnection(AppConfiguration.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Utilisateurs", cnx))
        //        {

        //            cnx.Open();
        //            return Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //}

        //internal static int Count(UtilisateurLevel level)
        //{

        //    using (SqlConnection cnx = new SqlConnection(AppConfiguration.ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Utilisateurs WHERE ut_level = @level", cnx))
        //        {
        //            cmd.Parameters.Add(new SqlParameter("@level", (int)level));
        //            cnx.Open();
        //            return Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //}
    }
}
