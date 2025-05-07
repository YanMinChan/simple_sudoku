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
        Cell[,] cells = new Cell[9, 9]; // cells in the grid (idk if I can declare like this)
        // List<int, string> numbers; // numbers in the grid that includes if it's system generated/written by user

        // The constructor
        public Grid(int[] puzzle, int[] solution)
        {
            for (int i=0; i<9; i++)
            {
                for (int j=0; j<9; j++){
                    //Console.WriteLine(i*9 + j);
                    cells[i,j] = new Cell(puzzle[i*9 + j], solution[i*9 + j]);
                }
            }
        }

        public Cell[,] Cells {get; set;} // get and set numbers in the grid

        // Print the grid
        public string printGrid()
        {
            string gridStr = "";
            // loop through each row
            // pattern:
            // |1|2|3|4|5|6|7|8|9|
           for (int i=0; i<9; i++){
               gridStr += "|";
               for (int j=0; j<9; j++){
                   gridStr = gridStr + cells[i, j].Number + "|";
               }
               gridStr += "\n";
               // add return new line
            }
            return gridStr;
        }
    }
}
