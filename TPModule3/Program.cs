using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule3.BO;

namespace TPModule3
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            try
            {
                InitialiserDatas();
                Console.WriteLine("Liste des prénoms des auteurs dont le nom commence par G :");
                var autorsStartWithG = ListeAuteurs.Where(a => a.Nom[0] == 'G');
                foreach (var acteur in autorsStartWithG)
                {
                    Console.WriteLine($"Nom = {acteur.Nom}");
                }

                Console.WriteLine("--------------------------------------------------------------");

                var autorMoreWritingBooks = ListeLivres.GroupBy(l => l.Auteur).OrderBy(c=>c.Count()).Last();
                Console.WriteLine($"L'auteur qui a écrit le plus de livres = {autorMoreWritingBooks.Key.Nom}");


                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Le nombre moyen de pages par livre pour ");

                Console.WriteLine("Pas réussi");


                Console.WriteLine("--------------------------------------------------------------");

                var livreMorePages = ListeLivres.OrderBy(l => l.NbPages).Last();
                Console.WriteLine($"Le titre du livre qui à le plus de pages {livreMorePages.Titre}");



                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Les auteurs ont gagnés en moyenne ");

                Console.WriteLine("Pas réussi");


                Console.WriteLine("--------------------------------------------------------------");

                var livresByAutor = ListeLivres.GroupBy(l => l.Auteur);
                foreach (var livres in livresByAutor)
                {
                    Console.WriteLine($"L'auteur est {livres.Key.Nom} et ses livres sont :");
                    foreach (var livre in livres)
                    {
                        Console.WriteLine( livre.Titre);
                    }
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Les titres des livres triés par ordre alphabétiques");
                var livresTrieAlphabetique = ListeLivres.OrderBy(l => l.Titre);

                foreach (var livre in livresTrieAlphabetique)
                {
                    Console.WriteLine(livre.Titre);
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Liste des livres dont le nombre de pages est supérieur à la moyenne");

                Console.WriteLine("Pas réussi");

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("l'auteur ayant écrit le moins de livres");

                var AuteurMoinsLivre = ListeLivres.GroupBy(l => l.Auteur).OrderBy(c => c.Count()).First();
                 Console.WriteLine(AuteurMoinsLivre.Key.Nom);
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

        }
    }
}
