using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace WebApplication1.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class IndexModel : PageModel
    {
        public Utilisateurs user { get; set; } = new Utilisateurs();
        public string DisplayErreur { get; set; } = "";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Response.Redirect("/CompteSoigant");
        }
        public ActionResult OnPostInscription()
        {
            string nom = Request.Form["nom"];
            string prenom = Request.Form["prenom"];
            string mdp = Request.Form["mdp"];
            string mdp_conf = Request.Form["mdp_conf"];
           
            if(mdp == mdp_conf && mdp.Length == mdp_conf.Length)
            {
                
                user.Nom = nom;
                user.Prenom = prenom;
                //user.Motdepasse = MHash.HashString(mdp);
                user.Inscription();
                return new RedirectResult("/login");
            }
            else
            {
                this.DisplayErreur = "Erreur lors de l'inscription";
                Thread.Sleep(2000);
                return new RedirectResult("/");
            }


        }
        //private static Random random = new Random();
        //public static string RandomString(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}
    }
}
