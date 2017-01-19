using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinesConsole
{
    enum Directions { tb, lr, tr, tl, br, bl}; //tb - top-bottom, lr - left-right, tr - top-right etc.
    class Table
    {
        public int Size { get; set; }
        public int Colors { get; set; }
        public int EmptyCellsCount { get; set; }

        public Cell[,] cells;

        public Table(int size)
        {
            
            //setting x,y size
            if (size > 5)
                this.Size = size;
            else this.Size = 5;

            //Empty cells count
            EmptyCellsCount = Size * Size;

            cells = new Cell[Size, Size];

            //Initializing (0,0) cell
            cells[0, 0] = new EmptyCell();

            //Filling table with empty cells
            for (int j = 0; j < Size; j++)
                for (int i = 0; i < Size; i++)
                {
                    //Initialization flow:
                    //------------>
                    //------------>
                    //------------>
                    //------------>
                    //------------>

                    //1. Every cell with y>0 is initialized with bottom field of upper cell
                    //2. In first row every cell with x>0 is initialized with right field of left cell
                    //3. Otherways cells[0,0] is initialized with new EmptyCell();
                    if (j != 0)
                        cells[i, j] = cells[i, j - 1].Bottom;
                    else if (i > 0)
                        cells[i, j] = cells[i - 1, j].Right;
                    else cells[i, j] = new EmptyCell();

                    //Assigning left cells - null in the left column
                    cells[i, j].Left = (i - 1) < 0 ? null : cells[i - 1, j];

                    //Assigning top cells - null in the first row
                    cells[i, j].Top = (j - 1) < 0 ? null : cells[i, j - 1];

                    //Assigning right cells - null in the right column. if j>0 it corresponds with bottom field of upper-right. in 1st row - new();
                    cells[i, j].Right = (i + 1) >= Size ? null : (j > 0) ? cells[i + 1, j - 1].Bottom : new EmptyCell();

                    //Assigning bottom cells - null in the last row and new() for other cells
                    cells[i, j].Bottom = (j + 1) >= Size ? null : new EmptyCell();
                }


        }

    }

    abstract class Cell
    {
        //Neigbour cells, null = out of table
        public Cell Top { get; set; }
        public Cell Bottom { get; set; }
        public Cell Left { get; set; }
        public Cell Right { get; set; }

    }

    class EmptyCell : Cell
    {
        public EmptyCell()
        {
        }

    }

    class EndPointCell : Cell
    {
        public ConsoleColor color;

        public EndPointCell(ConsoleColor color)
        {
            this.color = color;
        }

    }

    class LineCell : Cell
    {
        public ConsoleColor color;
        //Directions direction;

        public LineCell(ConsoleColor color)
        {
            this.color = color;
        }


    }

}
