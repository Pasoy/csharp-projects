using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace xml_u1
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
        }

        static void SolutionPrint(int solutionNumber)
        {
            Console.WriteLine();
            Console.WriteLine("----- Solution" + solutionNumber + " -----");
        }

        /*
         * Benutzen Sie eine der xml Dateien aus Beispiele/actors z.B. moore.xml
         * Welche Filme (Titel) hat der Schauspieler nach 1995 gedreht
         */
        static void Solution1()
        {
            XElement xe = XElement.Load(@"..\..\..\moore.xml");

            var solution1 = from m in xe.XPathSelectElements("//Movie[Year/text() > 1995]/Title") 
                            select m.Value;

            SolutionPrint(1);
            ObjectDumper.Write(solution1);
        }

        /*
         * Benutzen Sie eine der xml Dateien aus Beispiele/actors z.B. moore.xml
         * Wieviele Filme hat der Schauspieler gedreht (Ausgabe SchauspielerName und Anzahl)
         */
        static void Solution2()
        {
            XElement xe = XElement.Load(@"..\..\..\moore.xml");

            var solution2 = from a in xe.Descendants("Actor")
                            select new
                            {
                                Name = a.Element("Name").Element("FirstName").Value + " " +
                                       a.Element("Name").Element("LastName").Value,
                                Count = a.Descendants("Movie").Count()
                            };

            SolutionPrint(2);
            ObjectDumper.Write(solution2);
        }

        /*
         * Benutzen Sie die xml Datei kundenbestellungen.xml
         * Geben Sie die Kunden geordnet nach Land aus
         */
        static void Solution3()
        {
            XElement xe = XElement.Load(@"..\..\..\kundenbestellungen.xml");

            var solution3 = from el in xe.Elements("Kunden")
                            orderby el.Attribute("Land").ToString()
                            select new
                            {
                                Country = el.Attribute("Land").Value,
                                Company = el.Attribute("Firma").Value
                            };

            SolutionPrint(3);
            ObjectDumper.Write(solution3);
        }

        /*
         * Benutzen Sie die xml Datei kundenbestellungen.xml
         * Geben Sie pro Kunde Namen und summe der Frachtkosten der Bestellungen aus
         */
        static void Solution4()
        {
            XElement xe = XElement.Load(@"..\..\..\kundenbestellungen.xml");

            var solution4 = from el in xe.Elements("Kunden")
                            select new {
                                Firmenname = el.Attribute("Firma").Value,
                                Kosten = el.Descendants("Frachtkosten").Sum(x => Convert.ToDecimal(x.Value))
                            };

            SolutionPrint(4);
            ObjectDumper.Write(solution4);
        }

        /*
         * Benutzen Sie die xml Datei kundenbestellungen.xml
         * Geben Sie pro Mitarbeiter (Personal_Nr) aus, f�r wieviele Bestelungen der Mitarbeiter zuständig ist
         */

        static void Solution5()
        {
            XElement xe = XElement.Load(@"..\..\..\kundenbestellungen.xml");

            var solution5 = from el in xe.Elements("Kunden")
                            group new { bz = el.Elements("Bestellungen").Count() }
                            by el.Element("Personal_Nr").Value
                            into part
                            select new {
                                Personal_Nr = part.Key,
                                Bestellanzahl = part.Sum(x => x.bz)
                            };

            SolutionPrint(5);
            ObjectDumper.Write(solution5);
        }

        /*
         * Benutzen Sie eine der xml Dateien aus Beispiele/actors z.B. moore.xml
         * Der Film mit Titel  "Live and Let Die" soll als Jahr 1972 erhalten
         * Schreiben Sie die veränderte Datei auch zurück
         * (verwendbare Methoden von XElement: SetValue und Save)
         */

        static void Solution6()
        {
            XElement xe = XElement.Load(@"..\..\..\moore.xml");

            (from m in xe.XPathSelectElements("//Movie[Title = 'Live and Let Die']")
             select m.Element("Year")).First().SetValue("1972");
            
            xe.Save(@"..\..\..\mooreout.xml");
        }
    }
}
