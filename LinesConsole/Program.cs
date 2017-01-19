using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesConsole
{
    using LinesConsole.Classes;

    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Pro1.UserCollections for different generated tables

            //Table table = new Table(6);
            //Console.WriteLine(table.cells[1, 1].Left.GetType().Name);
            //Console.WriteLine(table.cells[1,1].Right.Equals(table.cells[3,1].Left));

            TableOperator oper = new TableOperator();
            Table table = oper.CreateBlankTable(6);
            oper.FillTable(table);

            Console.WriteLine();

            oper.DrawTable(table); 
            Console.ReadKey();
        }
    }
}
