using System;
using System.IO;
using Sudoku;

namespace Sudoku
{
    // The 9x9 grid for Sudoku
    // Consists of 81 cells
    // Will read csv and return puzzle
    public class Grid
    {
        // Instance variables
        private Cell[,] _cells = new Cell[9, 9]; // 81 cells in the grid
        private int[] _puz, _sol;

        // The constructor
        public Grid() { }

        // Getter and setters
        public Cell[,] Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

        // Public methods
        // Select a random puzzle
        public Grid SelectPuzzle(string filePath, int puzId = -1)
        {
            Reader reader = new Reader();
            reader.Load(filePath);

            List<int[]> puzList = reader.Puzzle;
            List<int[]> solList = reader.Solution;

            if (puzId != -1)
            {
                _puz = puzList[puzId];
                _sol = solList[puzId];
            }
            else
            {
                Random rand = new Random();
                puzId = rand.Next(puzList.Count);
                _puz = puzList[puzId];
                _sol = solList[puzId];
            }
            return this;
        }

        // Build the puzzle into cell class
        public Grid BuildPuzzle()
        {
            int size = _cells.GetLength(0);
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    int sgrid = (r / 3) * 3 + (c / 3);
                    _cells[r, c] = new Cell(_puz[r * 9 + c], _sol[r * 9 + c], sgrid);
                }
            }
            return this;
        }

        // Put the grid into string
        public string strGrid()
        {
            string gridStr = "";
            // loop through each row
            // pattern:
            // |1|2|3|4|5|6|7|8|9|
            for (int i = 0; i < 9; i++)
            {
                gridStr += "|";
                for (int j = 0; j < 9; j++)
                {
                    gridStr = gridStr + _cells[i, j].Number + "|";
                }
                gridStr += "\n";
                // add return new line
            }
            return gridStr;
        }

        // Print certain subgrids with color
        public void printGridWithColor(int[] subgrids)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 9; j++)
                {
                    Cell c = _cells[i, j];
                    if (subgrids.Contains(c.Subgrid))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(c.Number);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(c.Number);
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        // Check if number is valid to place in the cell
        public bool numValid(int num, int[] pos)
        {
            // Check for dup in col
            for (int i = 0; i < 9; i++)
            {
                if (_cells[pos[0], i].Number == num)
                {
                    return false;
                }
            }
            // Check for dup in row
            for (int i = 0; i < 9; i++)
            {
                if (_cells[i, pos[1]].Number == num)
                {
                    return false;
                }
            }
            // Check for dup in subgrid
            int subgrid = _cells[pos[0], pos[1]].Subgrid; // extract the subgrid of user chosen cell
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_cells[i, j].Subgrid == subgrid)
                    {
                        if (_cells[i, j].Number == num)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        // Check if the puzzle is complete
        public bool puzComplete()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_cells[i, j].Number != _cells[i, j].Solution)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // TODO: Check if a specific number is all filled in
        // (i.e. all 5s are filled in)
        public bool numFilled(int num)
        {
            return false;
        }
    }
}
