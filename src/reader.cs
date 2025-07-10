using System.IO;

namespace Sudoku{
    public class Reader{
        // Instance variable
        private List<int[]> _puzzle;
        private List<int[]> _solution;

        // Constructor
        public Reader(){
            _puzzle = new List<int[]>();
            _solution = new List<int[]>();
        }

        // Public methods

        ///<summary>
        /// Load the puzzle
        ///<summary>
        public void Load(string filePath, int count = 100){
            // Read from csv
            using (StreamReader sr = new StreamReader(filePath)){
                try{
                  string[] gameSet; //puzzle and solution

                  string header = sr.ReadLine(); // skip the header
                  string data = sr.ReadLine();

                  while ((data != null) && count > 0){

                      // obtain the puzzle and solution
                      gameSet = data.Split(',');
                      int[] puzSet = new int[81];
                      int[] solSet = new int[81];

                      // parse puzzle and solution to array
                      for (int j = 0; j < 81; j++){
                          // convert char to int by ascii
                          puzSet[j] = gameSet[0][j] - '0';
                          solSet[j] = gameSet[1][j] - '0';
                      }

                      _puzzle.Add(puzSet);
                      _solution.Add(solSet);

                      data = sr.ReadLine(); // Read next puzzle
                      count--;
                    }
                } catch (Exception e) {
                  Console.WriteLine(e.Message);
                }
            }
        }

        public List<int[]> Puzzle {
            get {return _puzzle;}
            set {_puzzle = value;}
        }

        public List<int[]> Solution {
            get {return _solution;}
            set {_solution = value;}
        }
    }
}
