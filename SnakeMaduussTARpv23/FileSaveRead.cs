using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMaduussTARpv23
{
    internal class FileSaveRead
    {
        public FileSaveRead() 
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"..\..\..\Text.txt", true);
                Console.WriteLine("Sisestage oma nimi:");
                sw.WriteLine(Console.ReadLine());
                sw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid file record");
            }
            //чтение
            /*
            try
            {
                StreamReader sr = new StreamReader(@"..\..\..\Text.txt");
                string lines = sr.ReadToEnd();
                Console.WriteLine(lines);
                List<string> result = new List<string>();
                foreach (var rida in File.ReadAllLines(@"..\..\..\Text.txt"))
                {
                    result.Add(rida);
                }

                sr.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalit file read");
            }
            Console.ReadLine();
            */
        }
    }
}
