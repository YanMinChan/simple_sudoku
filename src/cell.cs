namespace Sudoku
{
    // The cell of numbers in the sudoku
    public class Cell
    {
        // Instance variable
        int number;
        int subgrid;
        bool def = false; // The number is machine entered
        int solution;
        List<int> possibleSolution = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};

        // The constructor
        public Cell(int num, int sol, int sgrid)
        {
            this.number = num;
            this.solution = sol;
            this.subgrid = sgrid;
            if (num != 0){
                this.def = true;
                this.possibleSolution.Remove(num);
            }
        }

        // The getter and setter
        public int Number {
            get { return number; } 
            set { this.number = value; }
        }

        public int Solution {
            get { return solution; }
            set { this.solution = value; }
        }

        public List<int> PosSolution {
            get { return possibleSolution; }
            set { this.possibleSolution = value; }
        }

        public bool Default {
            get { return def; }
            set { this.def = value; }
        }

        public int Subgrid {
            get { return subgrid; }
        }
    }
}
