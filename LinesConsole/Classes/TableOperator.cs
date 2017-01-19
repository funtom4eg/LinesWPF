using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinesConsole.Classes
{
    class TableOperator
    {
        Random rand = new Random();

        public TableOperator()
        {

        }

        public Table CreateBlankTable(int size)
        {
            return new Table(size);
        }

        public Table FillTable(Table table)
        {
            //TODO: Fill Table with color lines
            ConsoleColor color = ConsoleColor.DarkBlue; //first color to fill

            //First EndPointCell
            int startX = rand.Next(table.Size - 1);
            int startY = rand.Next(table.Size - 1);

            table.cells[startX,startY] = new EndPointCell(color);
            //TODO: is it necessary?
            if (table.cells[startX, startY].Left != null)
                table.cells[startX, startY].Left.Right = table.cells[startX, startY];

            if (table.cells[startX, startY].Right != null)
                table.cells[startX, startY].Right.Left = table.cells[startX, startY];

            if (table.cells[startX, startY].Top != null)
                table.cells[startX, startY].Top.Bottom = table.cells[startX, startY];

            if (table.cells[startX, startY].Bottom != null)
                table.cells[startX, startY].Bottom.Top = table.cells[startX, startY];

            Thread.Sleep(5);
            bool same = true;
            int endX = 0, endY = 0;
            while (same)
            {
                endX = rand.Next(table.Size - 1);
                endY = rand.Next(table.Size - 1);
                if (!(endX == startX && endY == startY))
                    same = false;
            }

            table.cells[endX,endY] = new EndPointCell(color);
            //TODO: is it necessary?
            if (table.cells[endX, endY].Left != null)
                table.cells[endX, endY].Left.Right = table.cells[endX, endY];

            if (table.cells[endX, endY].Right != null)
                table.cells[endX, endY].Right.Left = table.cells[endX, endY];

            if (table.cells[endX, endY].Top != null)
                table.cells[endX, endY].Top.Bottom = table.cells[endX, endY];

            if (table.cells[endX, endY].Bottom != null)
                table.cells[endX, endY].Bottom.Top = table.cells[endX, endY];

            DrawTable(table);

            Connect(table.cells[startX, startY], table.cells[endX, endY]);

            return table;
        }

        //Connect two cells
        void Connect(Cell start, Cell end)
        {

        }
        //Draw table to console
        public void DrawTable(Table table)
        {
            for (int j = 0; j < table.Size; j++)
            {
                for (int i = 0; i < table.Size; i++)
                {
                    if(table.cells[i,j] is EmptyCell)
                        Console.Write("* ");
                    else if(table.cells[i,j] is EndPointCell)
                    {
                        Console.BackgroundColor = ((EndPointCell)table.cells[i, j]).color;
                        Console.Write("0 ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ((LineCell)table.cells[i, j]).color;
                        Console.Write("o ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                        
                }
                Console.WriteLine();
            }
        }

        //Search if there is lonely EmptyCell in table => redraw last line
        bool SearchLonely(Table table)
        {
            for (int i = 0; i < table.Size; i++)
                for (int j = 0; j < table.Size; j++)
                {
                    if (table.cells[i, j] is EmptyCell && !(table.cells[i, j].Left is EmptyCell)
                        && !(table.cells[i, j].Top is EmptyCell) && !(table.cells[i, j].Right is EmptyCell)
                        && !(table.cells[i, j].Bottom is EmptyCell))
                        return true;
                }
            return false;
        }
    }
}
