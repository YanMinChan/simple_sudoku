namespace Sudoku
{
    // The cell of numbers in the sudoku
    public class Cell
    {
        // Instance variable
        private int _number;
        private int _solution;
        private int _subgrid;
        private bool _isUnchangeable = false; // The number is machine entered

        List<int> _possibleSolution = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // The constructor
        public Cell(int num, int sol, int sgrid)
        {
            _number = num;
            _solution = sol;
            _subgrid = sgrid;
            if (num != 0)
            {
                _isUnchangeable = true;
                _possibleSolution.Remove(num);
            }
        }

        // The getter and setter
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public int Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }

        public List<int> PosSolution
        {
            get { return _possibleSolution; }
            set { _possibleSolution = value; }
        }

        public bool IsUnchangeable
        {
            get { return _isUnchangeable; }
            set { _isUnchangeable = value; }
        }

        public int Subgrid
        {
            get { return _subgrid; }
        }
    }
}
