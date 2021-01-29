using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class CompteSoigantModel : PageModel
    {
        //Utilisatauer connectés , id a fournir en url
        public Utilisateurs alex = new Utilisateurs();

        //Soignant a charges
        List<Utilisateurs> MaladeACharges = new List<Utilisateurs>();
        public void OnGet()
        {
            //peut etre load le numero id dans l url et ici charger le compte utilisateur
            //Donc ici il faudrait que je recupere l id avec l url ou autrement
            int test = 1;
            alex = Utilisateurs.Load(test);

            //Recuperation de ces malades
            //MaladeACharges = Utilisateurs

        }
    }
}
