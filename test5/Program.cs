using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion;

namespace test5
{
    class Program
    {
        static void Main(string[] args)
        {
            string Fournisseur = "y";
            DataClasses1DataContext db = new DataClasses1DataContext();
            var dbFourns = from f in db.Fournisseurs
                           where f.Nom.Contains(Fournisseur)
                           select f;
            List<Fournisseur> list_fourns = new List<Fournisseur>();
            foreach (var f in dbFourns) list_fourns.Add(f);
            list_fourns.ForEach(f => Console.WriteLine(f.Id));

            Console.ReadLine();
        }
    }
}
