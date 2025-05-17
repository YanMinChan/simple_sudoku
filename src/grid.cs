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
        Cell[,] cells = new Cell[9, 9]; // 81 cells in the grid

        // The constructor
        public Grid(int[] puzzle, int[] solution)
        {
            // Initialising the subgrid
            int[] subgrid = [1, 1, 1, 2, 2, 2, 3, 3, 3
            , 1, 1, 1, 2, 2, 2, 3, 3, 3
            , 1, 1, 1, 2, 2, 2, 3, 3, 3
            , 4, 4, 4, 5, 5, 5, 6, 6, 6
            , 4, 4, 4, 5, 5, 5, 6, 6, 6
            , 4, 4, 4, 5, 5, 5, 6, 6, 6
            , 7, 7, 7, 8, 8, 8, 9, 9, 9
            , 7, 7, 7, 8, 8, 8, 9, 9, 9
            , 7, 7, 7, 8, 8, 8, 9, 9, 9];

            // Fill the cells with given puzzle and solution
            for (int i=0; i<9; i++)
            {
                for (int j=0; j<9; j++){
                    //Console.WriteLine(i*9 + j);
                    this.cells[i,j] = new Cell(puzzle[i*9 + j], solution[i*9 + j], subgrid[i*9 + j]);
                }
            }
        }

        // Getter and setters
        public Cell[,] Cells {
            get {return cells;}
            set {cells = value;}
        }

        // Public methods
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
                   gridStr = gridStr + this.cells[i, j].Number + "|";
               }
               gridStr += "\n";
               // add return new line
            }
            return gridStr;
        }

        // Check if number is valid to place in the cell
        public bool numValid(int num, int[] pos){
            // Check for dup in col
            for (int i=0; i<9; i++){
                if (this.cells[pos[0], i].Number == num){
                    return false;
                }
            }
            // Check for dup in row
            for (int i=0; i<9; i++){
                if (this.cells[i, pos[1]].Number == num){
                    return false;
                }
            }
            // Check for dup in subgrid
            int subgrid = this.cells[pos[0], pos[1]].Subgrid; // extract the subgrid of user chosen cell
            for (int i=0; i<9; i++){
                for (int j=0; j<9; j++){
                    if (this.cells[i, j].Subgrid == subgrid){
                        if (this.cells[i, j].Number == num){
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
