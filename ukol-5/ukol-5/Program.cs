using System;
using System.Collections.Generic;
using System.Linq;
using Database;

namespace ukol_5
{
    internal class Program
    {
        public static bool Contains(List<Student> students, Student s1)
        {
            foreach (Student s2 in students)
            {
                if ((Equals(s1.Jmeno, s2.Jmeno) && Equals(s1.Prijmeni, s2.Prijmeni)))
                    return true;
            }
            return false;
        }

        public static void PrintSixStudents()
        {
            Student[] students1 = new Student[ReadonlyDB.Students.Length];
            ReadonlyDB.Students.CopyTo(students1, 0);
            Merge.sort<Student>(students1);
            List<Student> students2 = new List<Student>();

            foreach(Student s1 in students1) if (!Contains(students2, s1)) students2.Add(s1);

            for(int i = 2; i < 8; i++) Console.WriteLine("{0} {1}", students2[i].Jmeno, students2[i].Prijmeni);
            
            Console.WriteLine("---> Printed six unique ordered students.\n");
        }

        public static void PrintSixStudentsLINQ()
        {
            var names = ReadonlyDB.Students.Select(s => new { s.Jmeno, s.Prijmeni });
            names = names.OrderBy(s => s.Prijmeni).Distinct().Skip(2).Take(6);
            foreach(var name in names) Console.WriteLine("{0} {1}", name.Jmeno, name.Prijmeni);

            Console.WriteLine("---> Printed six unique ordered students using LINQ.\n");
        }

        public static void PrintFirstStudent()
        {
            Student student = ReadonlyDB.Students.FirstOrDefault(s => s.Rocnik >= 5);
            if (student is null)
                Console.WriteLine("There is not a 5th-year student.");
            else
                Console.WriteLine(student);

        }

        static void Main(string[] args)
        {
            PrintSixStudents();
            PrintSixStudentsLINQ();
            PrintFirstStudent();
            Console.WriteLine("Number of INF-PVS students: {0}", ReadonlyDB.Students.Count(s => Equals(s.OborKomb, "INF-PVS")));
            Console.WriteLine("Is Lukas in DB? {0}.", ReadonlyDB.Students.Any(s => s.Jmeno == "Lukáš") ? "Yep" : "Nope");
            Console.WriteLine("---> coffee");
            Console.ReadKey();
        }
    }
}
