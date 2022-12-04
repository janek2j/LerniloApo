using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerniloApo
{
    internal class FileManager
    {
        public static void ReadFiles()
        {
            var document1 = File.ReadAllText(@"..\..\..\temp\dokum1.txt");
            var document2 = File.ReadAllLines(@"..\..\..\temp\dokum2.txt");

            Console.WriteLine("dokument1");
            Console.WriteLine(document1);
            Console.WriteLine("dokument2");
            Console.WriteLine("----------------");
            var doc2string = string.Join(Environment.NewLine, document2);
            Console.WriteLine(doc2string);
        }

        public static void WriteFiles()
        {
            File.WriteAllText(@"..\..\..\temp\write1.txt", "1\n2\n3");
        }
    }
}
