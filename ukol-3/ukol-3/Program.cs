using System;
using System.IO;
using System.Collections.Generic;

namespace ukol_3
{
    internal class Program
    {
        public static void PrintDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                if (d.IsReady == true)
                {
                    Console.WriteLine(
                        "  Free space:{0, 26} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size:{0, 26} bytes ",
                        d.TotalSize);
                }
            }
        }
        public static void PrintDirectoryContent()
        {
            Console.WriteLine("\nEnter the path of your directory: ");
            var directoryInfo = new DirectoryInfo(@Console.ReadLine());

            if (directoryInfo.Exists)
            {
                foreach (FileInfo fi in directoryInfo.EnumerateFiles())
                {
                    Console.WriteLine("  Name:{0, 38}\n  Created:{1, 35}\n  Length:{2, 30} bytes\n\n", fi.Name, fi.CreationTime, fi.Length);
                }

                foreach (DirectoryInfo dir in directoryInfo.EnumerateDirectories())
                {
                    Console.WriteLine("  Name:{0, 38}\n  Created:{1, 35}\n\n", dir.Name, dir.CreationTime);
                }
            }
            else Console.WriteLine("\n---Directory not found---");
        }
        static void CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                Console.WriteLine("\n---Directory not found---");
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n---{0}---", ex.Message);
                }
            }

            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
        }
        static void Main(string[] args)
        {
            PrintDrives();
            PrintDirectoryContent();
            List<Csv> table = Csv.CsvExtension();
            table.ForEach(Console.WriteLine);

            Console.WriteLine("\nEnter source directory path: ");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Enter destination directory path: ");
            string destinationPath = Console.ReadLine();

            CopyDirectory(sourcePath, destinationPath);
            Console.WriteLine("\n---> coffee");
            Console.ReadKey();
        }
    }
}