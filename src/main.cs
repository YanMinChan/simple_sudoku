using System.IO;

namespace Sudoku
{
public class main{
    public static void Main(){
        // Testing sr
        Reader r = new Reader();
        r.ReadCSV("./dataset/sudoku.csv");

        // Saving puzzle to List
        List<int[]> puz = r.Puzzle;
        List<int[]> sol = r.Solution;

        Grid grid = new Grid(puz[0],sol[0]);
        Console.WriteLine(grid.printGrid());
    }
}
}
