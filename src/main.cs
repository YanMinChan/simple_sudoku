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

        // Create the grid
        Grid grid = new Grid(puz[0],sol[0]);

        // Print grid
        Console.WriteLine(grid.printGrid());

        // Prompt user to enter value and position
        // TODO: Limit input to only int from 1 to 9
        // TODO: Change confirmation prompt
        // TODO: Limit input only to user defined cell (default cell can't be changed)
        Console.WriteLine("Enter position: xpos, ypos");
        string usrPos = Console.ReadLine();
        int[] pos = Array.ConvertAll(usrPos.Split(','), int.Parse);
        //Console.WriteLine("" + pos[0] + pos[1]);

        Console.WriteLine("Enter value:");
        string usrVal = Console.ReadLine();
        int val = int.Parse(usrVal);
        //Console.WriteLine(val);

        // Set the new usr input value
        Cell[,] cells = grid.Cells;
        grid.Cells[pos[0], pos[1]].Number = val;

        // Print new grid
        Console.WriteLine(grid.printGrid());
    }
}
}
