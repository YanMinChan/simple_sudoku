using System.IO;

namespace Sudoku
{
    public class Main{
        // Read from csv
        using (StreamReader sr = new StreamReader("TestFile.txt"))
        {
            List<string> puzzles;
            int i = 0;
            while ((line = sr.ReadLine() != null) && i < 100)
            {

            }
        }
        public static void Main(){
            Grid grid = new Grid(,);
            Console.WriteLine(grid.printGrid());
        }
    }
}
