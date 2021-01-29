using Classes.Managers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Utilisateurs
    {
        private int id;
        private string prenom;
        private string nom;
        private string motdepasse;

        private static UTF8Encoding _encoder = new UTF8Encoding();

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Motdepasse { get => motdepasse; set => motdepasse = value; }

        public string CourtePresentation { get; set; }
        public void Inscription()
        {
            UtilisateurManager.Save(this);
        }

        //Charges le soignant , le malade pour avoir toutes les informations
        public static Utilisateurs Load(int id)
        {
            return UtilisateurManager.Load(id);
        }

        //Charges les malades a charges d un soignant
        public static List<Utilisateurs> LoadMalade(int idSoignant)
        {
            return UtilisateurManager.LoadMalade(idSoignant);
        }

        //public static List<Utilisateurs> List()
        //{
        //    return UtilisateurManager.List();
        //}

        //public static Utilisateurs Search(string nom, string prenom, string motdepasse)
        //{
        //    return UtilisateurManager.Search(nom, prenom,motdepasse);
        //}

        //public static Utilisateur Search(string email, string password)
        //{
        //    return UtilisateurManager.Search(email, password);
        //}

        //public static Utilisateurs SearchByHash(int id, string hash)
        //{
        //    return UtilisateurManager.SearchByHash(id, hash);
        //}

        //public static List<Utilisateurs> List(int nbUtilisateurs)
        //{
        //    return UtilisateurManager.List(nbUtilisateurs);
        //}

        //public static int Count()
        //{
        //    return UtilisateurManager.Count();
        //}

        //public static int Count(UtilisateurLevel level)
        //{
        //    return UtilisateurManager.Count(level);
        //}

        //public void Delete()
        //{
        //    UtilisateurManager.Delete(this);
        //}

        //public string HashPassword
        //{
        //    get
        //    {
        //        return MHash.HashString(motdepasse);
        //    }
        //}

        // public static Utilisateurs Current(HttpContext context)
        //   {
        //int? id = context.Session.GetHashCode("UtilisateurId");

        //var utilisateurEmail = context.Request.Cookies["UtilisateurEmail"];
        //var utilisateurPassword = context.Request.Cookies["UtilisateurPassword"];

        //if (id != null)
        //    return Load(id.Value);
        //else if (utilisateurEmail != null && utilisateurPassword != null)
        //    return Utilisateurs.Search(utilisateurEmail, utilisateurPassword);
        //else
        //    return null;
        //    }

        public static void LogOff(HttpContext context)
        {
            context.Session.Set("UtilisateurId", null);
        }
    }
}
