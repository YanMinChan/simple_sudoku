namespace Sudoku
{
    // The cell of numbers in the sudoku
    public class Cell
    {
        // Instance variable
        int number;
        bool machine = false; // The number is machine entered
        int solution;
        int[] possibleSolution = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        // The constructor
        public Cell(int num, int sol)
        {
            this.number = num;
            this.solution = sol;
            if (num != 0){
                this.machine = true; 
            }
        }

        // The getter and setter
        public int Number {
            get { return number; } 
            set { number = value; }
        }

        public int Solution {
            get { return solution; }
            set { solution = value; }
        }
    }
}
