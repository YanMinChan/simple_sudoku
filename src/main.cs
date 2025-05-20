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
        // Console.WriteLine(grid.strGrid());
        int[] sgridcol = [1, 3, 5, 7, 9];
        grid.printGridWithColor(sgridcol);

        // Prompt user to enter value and position
        // TODO: Limit input to only int from 1 to 9
        // TODO: Change confirmation prompt
        // TODO: Limit input only to user defined cell (default cell can't be changed)
        while (!grid.puzComplete()){
            Console.WriteLine("Enter value: row, col, number");
            string usrPos = Console.ReadLine();
            try {
                int[] pos = Array.ConvertAll(usrPos.Split(','), int.Parse).Select(i => i - 1).ToArray(); // position -1 to match index
                int val = pos[2] + 1; // user entered number
                //Console.WriteLine("Enter value:");
                //string usrVal = Console.ReadLine();
                //int val = int.Parse(usrVal);

                // Check if it's changing default cell
                // Check if the number is integer 1 to 9
                // Check if there is duplicate in row column sgrid
                if(grid.Cells[pos[0], pos[1]].Default){
                    Console.WriteLine("You cannot change default cell.");
                } else if(val < 0 || val > 9){
                    Console.WriteLine("The number is not valid (0 to 9 integer only).");
                } else if (grid.numValid(val, pos)){
                    // Set new value
                    grid.Cells[pos[0], pos[1]].Number = val;
                    // Print new grid
                    //Console.WriteLine(grid.strGrid());
                    grid.printGridWithColor(sgridcol);
                } else {
                    Console.WriteLine("The number is not valid, there are duplicates!");
                    //string usrVal = Console.ReadLine();
                    //int val = int.Parse(usrVal);
                }
            } catch (IndexOutOfRangeException e){
                Console.WriteLine("Only row and column 1 to 9 in integer.");
            } catch (Exception e){
                // For input large number in position / input other than integer
                Console.WriteLine("Please input only integer.");
            }
        }
        Console.WriteLine("Gz!");
    }
}
}
