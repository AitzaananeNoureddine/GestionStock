using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var dbFourns = from p in db.Fournisseurs
                           select p;
            foreach (var fourn in dbFourns) Console.WriteLine($"nom : {fourn.Nom} adresse : {fourn.Adresse} contact : {fourn.Contact}");
            Console.ReadLine();

            /*var dbProducts = from p in db.Produits
                             select p;
            foreach (var fourn in dbProducts) Console.WriteLine("nom : " + fourn.Nom);*/

        }
    }
}
