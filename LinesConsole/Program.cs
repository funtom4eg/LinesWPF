using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(6);
            Console.WriteLine(table.cells[1, 1].Left.GetType().Name);
            Console.WriteLine(table.cells[1,1].Right.Equals(table.cells[3,1].Left));

            Console.ReadKey();
        }
    }
}
