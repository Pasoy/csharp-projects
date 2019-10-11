using System;
using System.Linq;

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

            Console.ReadLine();
        }

        static void SolutionPrint(int solutionNumber)
        {
            Console.WriteLine("----- Solution" + solutionNumber + " -----");
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
        }
    }
}
