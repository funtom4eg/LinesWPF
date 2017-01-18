using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LinesWPF
{
    class Table
    {
        public int Size { get; set; }
        public int Lines { get; set; }

        Cell[,] cells;

        public Table(int size = 5)
        {
            this.Size = size;
            
        }

    }

    abstract class Cell
    {

        int X { get; set; }
        int Y { get; set; }

    }

    class EmptyCell : Cell
    {

    }

    class EndPointCell : Cell
    {

    }

    class LineCell : Cell
    {

    }

}
