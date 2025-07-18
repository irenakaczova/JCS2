using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ukol_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\irena\source\repos\db.mdf;Integrated Security=True;Connect Timeout=30";

            List<string> list = new List<string>();
            list.Add("SELECT DISTINCT Jmeno, Prijmeni FROM students ORDER BY Prijmeni ASC OFFSET 2 ROWS FETCH NEXT 6 ROWS ONLY");
            list.Add("INSERT INTO students VALUES ('R00003', 'Eve', 'Polastri', 'polae01', '2', 'IT'), ('R00073', 'Villanelle', 'Polastri', 'polav01', '2', 'IT')");
            list.Add("SELECT Jmeno, Prijmeni FROM students");
            list.Add("DELETE FROM students WHERE OborKomb = 'IT'");
            list.Add("SELECT OborKomb, Prijmeni FROM students");
            list.Add("SELECT OsCislo, UserName FROM students WHERE OsCislo = 'R20163'");
            list.Add("UPDATE students SET UserName = 'Hrocma04' WHERE OsCislo = 'R20163'");
            list.Add("SELECT OsCislo, UserName FROM students WHERE OsCislo = 'R20163'");
            list.Add("SELECT OsCislo, Grade FROM students JOIN exams ON students.OsCislo = exams.StudentOsCislo");

            for (int i=0; i < list.Count; i++)
            {
                var query = new SqlCommand(list[i]);
                ExecuteQuery(fileConnectionString, query);

                switch (i)
	            {
                    case 0:
                        Console.WriteLine("---> Printed six unique ordered students.\n"); break;
                    case 2:
                        Console.WriteLine("---> Wellcome Eve & Villanelle.\n"); break;
                    case 4:
                        Console.WriteLine("---> Miss You IT crowd. Goodbye Eve & Villanelle.\n"); break;
                    case 5:
                        Console.WriteLine("---> Printed the chosen one.\n"); break;
                    case 7:
                        Console.WriteLine("---> Printed changes.\n"); break;
                    case 8:
                        Console.WriteLine("---> Printed grades.\n"); break;
	            }
            }
            Console.WriteLine("---> Coffee");
            Console.ReadKey();
        }

        private static void ExecuteQuery(string connectionString, SqlCommand sqlCommand)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    sqlCommand.Connection = conn;
                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr[0]}, {dr[1]}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        
    }
}