namespace TrashCompactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day6\\TrashCompactor\\input.txt");
            //string[] input = ["123 328 51 64", 45 64  387 23]

            string[] delimiters = [" ", "  ", "   ", "    ", "     "];
            string[] row1 = input[0].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row2 = input[1].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row3 = input[2].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row4 = input[3].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = input[4].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            long result = 0;

            for (int i = 0; i < 1000; i++)
            {
                if ( operators[i] == "+")
                {
                    result = result + (long.Parse(row1[i]) + long.Parse(row2[i]) + long.Parse(row3[i]) + long.Parse(row4[i]));
                }

                if ( operators[i] == "*")
                {
                    result = result + (long.Parse(row1[i]) * long.Parse(row2[i]) * long.Parse(row3[i]) * long.Parse(row4[i]));
                }
            }
            Console.WriteLine(result);
        }
    }
}
