using System;
using System.Linq;

namespace linq_u1
{
    class Program
    {
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

            Console.ReadKey();
        }

        /*
         * liste alle Bücher, die mehr als 200 Seiten haben
         */
        static void Solution1()
        {
            var solution1 = from b in SampleData.Books
                            where b.PageCount > 200
                            select new { b.PageCount, b.Isbn, b.Title };

            ObjectDumper.Write(solution1);
            Console.WriteLine();
        }

        /*
         * liste alle Bücher (nur Isbn, PublicationDate, Title ausgeben),
         * die  vor August 2007 produziert wurden, sortierung nach
         * Title ist erwünscht
         */
        static void Solution2()
        {
            var solution2 = from b in SampleData.Books
                            where b.PublicationDate < new DateTime(2007, 8, 1)
                            orderby b.Title descending
                            select new { b.Isbn, b.PublicationDate, b.Title };
            ObjectDumper.Write(solution2);
            Console.WriteLine();
        }

        /*
         * liste alle Bücher, die vom Verlag mit Namen "FunBooks" stammen,
         * Ausgabe einiger Felder aus Book
         */
        static void Solution3()
        {
            var solution3 = from b in SampleData.Books
                            where b.Publisher.Name.Equals("FunBooks")
                            select new { b.Isbn, b.Publisher, b.Title };
            ObjectDumper.Write(solution3, 2);
            Console.WriteLine();
        }

        /*
         * Liste description und Name des Subjects "Software development"   
         * sowie den Title der Bücher, die zum subject gehören
         */    
        static void Solution4()
        {
            var solution4 = from b in SampleData.Books
                            where b.Subject.Name.Equals("Software development")
                            select new { b.Subject, b.Title };
            ObjectDumper.Write(solution4, 2);
            Console.WriteLine();
        }

        /*
         * Liste Name und Website aus publisher, dazu die Bücher
         * des Verlags (Title, Price) und auch noch den Namen des 
         * Buch-subjects
         */
        static void Solution5()
        {
            var solution5 = from b in SampleData.Books
                            select new { b.Publisher, b.Title, b.Price, b.Subject };
            ObjectDumper.Write(solution5, 2);
            Console.WriteLine();
        }

        /*
         * Liste die Bücher (Title und Pagecount) sowie die
         * Autoren, die das Buch geschrieben haben
         */
        static void Solution6()
        {
            var solution6 = from b in SampleData.Books
                            select new { b.Title, b.PageCount, b.Authors };
            ObjectDumper.Write(solution6, 2);
            Console.WriteLine();
        }

        /*
         * Liste die Bücher des Autors  Octavio Prince
         */
        static void Solution7()
        {
            var solution7 = from b in SampleData.Books
                            from a in b.Authors
                            where a.FirstName.Equals("Octavio") && a.LastName.Equals("Prince")
                            // where b.Authors.Any(bo => bo.FirstName.Equals("Octavio") && bo.LastName.Equals("Prince"))
                            select new { b.Isbn, b.Title, b.Authors };
            ObjectDumper.Write(solution7, 2);
            Console.WriteLine();
        }

        /*
         * Liste die B�cher, bei denen Octavio Prince
         * der Hauptautor (1. Autoreintrag) ist
         */
        static void Solution8()
        {
            var solution8 = from b in SampleData.Books
                            let a = b.Authors.First()
                            where a.FirstName.Equals("Octavio") && a.LastName.Equals("Prince")
                            select new { b.Isbn, b.Title, Author = a.FirstName + " " + a.LastName };
            ObjectDumper.Write(solution8);
            Console.WriteLine();
        }

        /*
         * Gebe die Publisher aus, dazu die Anzahl ihrer Bücher
         */
        static void Solution9()
        {
            //does not print the 3rd publisher because they did not publish any fokin books
            var solution9 = from b in SampleData.Books
                            group b by b.Publisher into publishers
                            select new
                            {
                                Pubs = publishers.Key.Name,
                                Count = publishers.Count(),
                                SiteSum = publishers.Sum(b => b.PageCount),
                                AvgPrice = Math.Round(publishers.Average(b => b.Price) * 100) / 100
                            };
            ObjectDumper.Write(solution9);
            Console.WriteLine();
        }

        /*
         * Ausgabe Publishername, booktitle, Anzahl der Autoren
         */
        static void Solution10()
        {
            var solution10 = from b in SampleData.Books
                             select new {
                                 b.Publisher.Name,
                                 b.Title,
                                 Anz = b.Authors.Count()
                             };
            ObjectDumper.Write(solution10);
            Console.WriteLine();
        }

        /*
         * Ausgabe aller Subjects, darunter geschachtelt  jeweils
         * die Books dieses Subjects
         */
        static void Solution11()
        {
            var solution11 = from b in SampleData.Books
                             group new { b.Title, b.Price, b.PageCount } by b.Subject into subjects
                             select new
                             {
                                 Subject = subjects.Key.Name,
                                 Count = subjects.Count(),
                                 AvgPrice = subjects.Average(b => b.Price),
                                 SiteSum = subjects.Sum(b => b.PageCount),
                                 Books = subjects
                             };
            ObjectDumper.Write(solution11, 2);
            Console.WriteLine();
        }
    }
}
