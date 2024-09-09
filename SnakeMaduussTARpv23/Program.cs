using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMaduussTARpv23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            HorizontalLine line = new HorizontalLine();
            line.Drow();

            List<int> numList = new List<int>();
            numList.Add(0);
            numList.Add(1);
            numList.Add(2);

            int x = numList[ 0 ];
            int y = numList[ 1 ];
            int z = numList[ 2 ];

            foreach(int i in numList)
            {
                Console.WriteLine( i );
            }
            numList.Remove( 0 );
            
            List<Point> plist = new List<Point>();

            plist.Add( p1 );
            plist.Add( p2 );

            Console.ReadLine();
        }
    }
}
