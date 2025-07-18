using System;
using System.IO;
using System.Collections.Generic;

namespace ukol_3
{
    internal class Csv
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return String.Format("  {0}\n  {1}\n  {2}\n  {3}\n  {4}\n  {5}\n\n", FirstName, LastName, Address, City, State, PostalCode);
        }

        public static List<Csv> CsvExtension()
        {
            List<Csv> table = new List<Csv>();
            Console.WriteLine("\nEnter the path of your csv file: ");
            FileInfo csv = new FileInfo(@Console.ReadLine());
            if (csv.Exists)
            {
                StreamReader sr = null;
                try
                {
                    sr = csv.OpenText();
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] subs = s.Split(',');
                        table.Add(new Csv
                        {
                            FirstName = subs[0],
                            LastName = subs[1],
                            Address = subs[2],
                            City = subs[3],
                            State = subs[4],
                            PostalCode = subs[5]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n---{0}---", ex.Message);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }
            else Console.WriteLine("\n---File not found---");

            return table;
        }
    }
}