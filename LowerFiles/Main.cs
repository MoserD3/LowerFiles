using System;
using System.IO;

namespace LowerFiles
{
    internal class Program
    {
        static private DateTime Date;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Date = DateTime.Now;
                Console.WriteLine("Current Date: " + Date.ToString());

                foreach (var dir in Directory.GetDirectories(args[0], "*", SearchOption.AllDirectories))
                {
                    LowerFiles(dir);
                }
                LowerFiles(args[0]);
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("0 Arguments");
            }

            Console.ReadKey();
        }

        static void LowerFiles(string dir)
        {
            foreach (var file in Directory.GetFiles(dir))
            {
                File.SetCreationTime(file, Date);
                File.SetLastAccessTime(file, Date);
                File.SetLastWriteTime(file, Date);
                Console.WriteLine("Rename File: " + file);
                File.Move(file, file.ToLowerInvariant());
            }
        }
    }
}
