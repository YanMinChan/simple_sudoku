namespace Sudoku
{
    // The 9x9 grid for Sudoku
    public class Grid
    {
        // Instance variables
        List<int> numbers; // numbers in the grid
        // List<int, string> numbers; // numbers in the grid that includes if it's system generated/written by user

        // The constructor
        public Grid()
        {
            Random rand = new Random();
            for (int i = 0; i < 9; i++)
            {
                numbers.Add(rand.Next(1, 10)); // Return an integer between 1 and 9
            }
        }

        public List<int> Number {get; set;} // get and set numbers in the grid

        // Print the grid
        public string printGrid()
        {

        }
    }
}