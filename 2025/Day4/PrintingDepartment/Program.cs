namespace PrintingDepartment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] input = ["..@@.@@@@.", "@@@.@.@.@@", "@@@@@.@.@@", "@.@@@@..@.", "@@.@@@@.@@", ".@@@@@@@.@", ".@.@.@.@@@", "@.@@@.@@@@", ".@@@@@@@@.", "@.@.@@@.@."];
            string[] input = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day4\\PrintingDepartment\\input.txt");

            int accessibleRolls = 0;

            int bruteForceVar = 0;
            while (bruteForceVar < 100) // just brute force it xD
            {
                for (int row = 0; row < input.Length; row++)
                {
                    for (int roll = 0; roll < input[row].Length; roll++)
                    {
                        if (input[row][roll] == '@')
                        {
                            int adjacentRolls = 0;

                            if (roll != input[row].Length - 1 && input[row][roll + 1] == '@') // rechts
                            {
                                adjacentRolls++;
                            }

                            if (roll != 0 && input[row][roll - 1] == '@') // links
                            {
                                adjacentRolls++;
                            }

                            if (row != 0 && input[row - 1][roll] == '@') // direkt drüber
                            {
                                adjacentRolls++;
                            }

                            if (row != input.Length - 1 && input[row + 1][roll] == '@') // direkt drunter
                            {
                                adjacentRolls++;
                            }

                            if (row != 0 && roll != 0 && input[row - 1][roll - 1] == '@') // links drüber
                            {
                                adjacentRolls++;
                            }

                            if (row != 0 && roll != input.Length - 1 && input[row - 1][roll + 1] == '@') // rechts drüber
                            {
                                adjacentRolls++;
                            }

                            if (row != input.Length - 1 && roll != 0 && input[row + 1][roll - 1] == '@') // links drunter
                            {
                                adjacentRolls++;
                            }

                            if (row != input.Length - 1 && roll != input[row].Length - 1 && input[row + 1][roll + 1] == '@') // rechts drunter
                            {
                                adjacentRolls++;
                            }

                            if (adjacentRolls < 4)
                            {
                                /// remove paper rolls 
                                char[] chars = input[row].ToCharArray();
                                chars[roll] = '.';
                                input[row] = new string(chars);

                                accessibleRolls++;
                            }
                        }
                    }
                }
                bruteForceVar++;
            }
            Console.WriteLine(accessibleRolls);
        }
    }
}
