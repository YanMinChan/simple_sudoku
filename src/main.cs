using System.IO;

namespace Sudoku
{
    public class Reader{
        // Instance variable
        List<string> puzzle;
        List<string> solution;

        public void ReadCSV(){
            // Read from csv
            using (StreamReader sr = new StreamReader("./dataset/sudoku.csv"))
            {
                string[] gameSet;
                int i = 0;
                string data;
                while ((data = sr.ReadLine() != null) && i < 100)
                {
                    gameSet = data.Split(',');
                    this.puzzle.Add(gameSet[0]);
                    this.solution.Add(gameSet[1]);
                    i++;
                }
            }
        }

        public static void Main(){
            Grid grid = new Grid(puzzle[0],solution[0]);
            Console.WriteLine(grid.printGrid());
        }
    }
}
