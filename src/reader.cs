using System.IO;

namespace Sudoku
{
    public class Reader{
        // Instance variable
        List<int[]> puzzle;
        List<int[]> solution;

        // Constructor
        public Reader(){
            this.puzzle = new List<int[]>();
            this.solution = new List<int[]>();
        }

        // Public methods
        public void ReadCSV(string filePath){
            // Read from csv
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] gameSet; //puzzle and solution
                int i = 0; //limit num of puzzle read

                string header = sr.ReadLine(); // skip the header
                string data = sr.ReadLine();
                while ((data != null) && i < 100)
                {
                    // obtain the puzzle and solution
                    gameSet = data.Split(',');
                    int[] puzSet = new int[81];
                    int[] solSet = new int[81];
                    // parse puzzle and solution to array
                    for (int j = 0; j < 81; j++){
                        // convert char to int by ascii
                        puzSet[j] = gameSet[0][j] - '0';
                        solSet[j] = gameSet[1][j] - '0';
                    //Console.WriteLine("This is gameset " + gameSet[0][j]); // test
                    //Console.WriteLine("This is puzSet " + puzSet[j]);
                    }
                    this.puzzle.Add(puzSet);
                    this.solution.Add(solSet);
                    i++;
                }
            }
        }

        public List<int[]> Puzzle {
            get {return puzzle;}
            set {puzzle = value;}
        }

        public List<int[]> Solution {
            get {return solution;}
            set{solution = value;}
        }
    }
}
