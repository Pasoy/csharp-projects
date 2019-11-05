using System;
using System.Linq;
using System.Xml.Linq;

namespace linq_u2
{
    class Program
    {
        static Book[] books = SampleData.Books;
        static Review[] reviews = SampleData.Reviews;

        static void Main(string[] args)
        {
            Solution1();
            Solution2();
            Solution3();
            Solution4();
            Solution5();
            Solution6();
            Solution7();
            Solution8();
            Solution9();
            Solution10();
            Solution11();

            Console.ReadLine();
        }

        static void SolutionPrint(int solutionNumber)
        {
            Console.WriteLine("----- Solution" + solutionNumber + " -----");
            Console.WriteLine();
        }

        /*
         * Liste alle Bücher, die mehr als einen Autor haben
         */
        static void Solution1()
        {
            var solution1 = from b in books
                            where b.Authors.Count() > 1
                            select b;

            SolutionPrint(1);
            ObjectDumper.Write(solution1, 1);
        }

        /*
         * Liste alle Bücher (ISBN, Tite), 
         * die zum Subject "Software development" gehören
         */
        static void Solution2()
        {
            var solution2 = from b in books
                            where b.Subject.Name.Equals("Software development")
                            select new { b.Isbn, b.Title };

            SolutionPrint(2);
            ObjectDumper.Write(solution2);
        }

        /*
         * Liste alle Reviews, die User Fred erstellt hat
         */
        static void Solution3()
        {
            var solution3 = from r in reviews
                            where r.User.Name.Equals("Fred")
                            select r;

            SolutionPrint(3);
            ObjectDumper.Write(solution3, 1);
        }

        /*
         * Liste alle Bücher, geordnet nach den Ratings in ihren Reviews
         */
        static void Solution4()
        {
            var solution4 = from r in reviews
                            group r.Rating by r.Book into gruppeprobuch
                            orderby gruppeprobuch.Average() descending
                            select new 
                            {
                                Buch = gruppeprobuch.Key.Title,
                                Rating = gruppeprobuch.Average()
                            };

            SolutionPrint(4);
            ObjectDumper.Write(solution4);
        }

        /*
         * Welche/s Bücher/Buch hat das schlechteste Rating bekommen
         */
        static void Solution5()
        {
            var maxRating = reviews.Max(r => r.Rating);

            var solution5 = from r in reviews
                            where r.Rating == maxRating
                            select new { r.Book.Title, r.Rating };

            SolutionPrint(5);
            ObjectDumper.Write(solution5);
        }

        /*
         * Gib für alle User aus, wieviele Reviews sie geschrieben haben
         */
        static void Solution6()
        {
            var solution6 = from r in reviews
                            group r by r.User into groups
                            select new
                            {
                                groups.Key.Name,
                                Count = groups.Count()
                            };

            SolutionPrint(6);
            ObjectDumper.Write(solution6);
        }

        /*---------------------------------
         *              XML
         *---------------------------------*/

        /*
         * Liste die User mit ihren Reviews
         */
        static void Solution7()
        {
            var solution7 = new XElement("Benutzer", from u in SampleData.Users
                                                     select new XElement("User", new XAttribute("Name", u.Name), from r in SampleData.Reviews
                                                                                                                 where r.User == u
                                                                                                                 select new XElement("Review", r.Comments)));

            SolutionPrint(7);
            Console.WriteLine(solution7);
        }

        /*
         * Liste die Autoren mit Ihren B�chern und dazu
         * die Anzahl der Reviews
         */
        static void Solution8()
        {
            var solution8 = new XElement("Autoren", from a in SampleData.Authors
                                                    select new XElement("Autor", new XAttribute("Name", a.LastName + " " + a.FirstName), from b in SampleData.Books
                                                                                                                                         where b.Authors.Any(x => x == a)
                                                                                                                                         select new XElement("Buch", new XAttribute("Titel", b.Title),
                                                                                                                                         new XAttribute("Anzrev", b.Reviews.Count()))));
            
            SolutionPrint(8);
            Console.WriteLine(solution8);
                   
        }

        /*
         * Geben Sie die Verlage aus, mit Angabe aller Reviews,
         * die Bücher des Verlags betreffen
         */
        static void Solution9()
        {
            var solution9 = new XElement("Verlage", from p in SampleData.Publishers
                                                    select new XElement("Verlag", new XAttribute("Name", p.Name), from b in SampleData.Books
                                                                                                                  from r in b.Reviews
                                                                                                                  where b.Publisher == p
                                                                                                                  select new XElement("Review", new XAttribute("Titel", b.Title), new XAttribute("Review", r.Comments), new XAttribute("Rating", r.Rating))));

            SolutionPrint(9);
            Console.WriteLine(solution9);
        }

        /*
         * Geben Sie Verlage aus, Name und durchschnittlices Rating
         */
        static void Solution10()
        {
            var solution10v1 = new XElement("Verlage", from r in SampleData.Reviews
                                                       group new { r.Rating } by r.Book.Publisher into grp
                                                       select new XElement("Verlag", new XAttribute("Name", grp.Key.Name),
                                                                                     new XAttribute("DRating", grp.Average(x => x.Rating))));

            var solution10 = new XElement("wurzel", from p in SampleData.Publishers
                                                    select new XElement("Verlag", new XAttribute("Name", p.Name),
                                                                                  new XAttribute("dRating", (from b in SampleData.Books 
                                                                                                             where b.Publisher == p
                                                                                                             from r in b.Reviews
                                                                                                             select r.Rating).Count() == 0 ? 0.0 : (from b in SampleData.Books
                                                                                                                                                    where b.Publisher == p
                                                                                                                                                    from r in b.Reviews
                                                                                                                                                    select r.Rating).Average())));

            SolutionPrint(10);
            Console.WriteLine(solution10v1);
        }

        /*
         * welche Ausgabe erwarten Sie mit folgendem Code
         */
        static void Solution11()
        {
            /*
             * static void DisplayProcesses()
               {
                    List<String> processes = new List<String>();
                    foreach (Process process in Process.GetProcesses())
                    processes.Add(process.ProcessName);
                    ObjectDumper.Write(processes);
                }
                static void Main()
                {
                    DisplayProcesses();
                    Console.ReadKey();
                }
                */
        }
    }
}
