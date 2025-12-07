namespace TrashCompactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day6\\TrashCompactor\\input.txt");

            string[] delimiters = [" ", "  ", "   ", "    ", "     "];
            string[] row1 = input[0].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row2 = input[1].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row3 = input[2].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] row4 = input[3].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = input[4].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            string[] row1WithSpaces = new string[1000];
            string[] row2WithSpaces = new string[1000];
            string[] row3WithSpaces = new string[1000];
            string[] row4WithSpaces = new string[1000];

            long result = 0;
            int x = 0;

            for (int i = 0; i < 1000; i++)
            {
                int number1 = int.Parse(row1[i]);
                int number2 = int.Parse(row2[i]);
                int number3 = int.Parse(row3[i]);
                int number4 = int.Parse(row4[i]);

                int[] numbers = [number1, number2, number3, number4];

                int largest = number1;

                for (int j = 0; j < 4; j++)
                {
                    if (numbers[j] > largest)
                    {
                        largest = numbers[j];
                    }
                }

                if (i == 0 || i == 999)
                {
                    row1WithSpaces[i] = input[0].Substring(x, largest.ToString().Length);
                    row2WithSpaces[i] = input[1].Substring(x, largest.ToString().Length);
                    row3WithSpaces[i] = input[2].Substring(x, largest.ToString().Length);
                    row4WithSpaces[i] = input[3].Substring(x, largest.ToString().Length);
                }
                else
                {
                    row1WithSpaces[i] = input[0].Substring(x, largest.ToString().Length + 1);
                    row2WithSpaces[i] = input[1].Substring(x, largest.ToString().Length + 1);
                    row3WithSpaces[i] = input[2].Substring(x, largest.ToString().Length + 1);
                    row4WithSpaces[i] = input[3].Substring(x, largest.ToString().Length + 1);
                }

                x += largest.ToString().Length + 1;
            }

            for (int k = 0; k < 1000; k++)
            {
                if (operators[k] == "+")
                {
                    for (int y = 0; y < row1WithSpaces[k].Length; y++)
                    {
                        string value = string.Empty;
                        value += row1WithSpaces[k][y];
                        value += row2WithSpaces[k][y];
                        value += row3WithSpaces[k][y];
                        value += row4WithSpaces[k][y];
                        value = String.Join("", value.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                        if (value != "" && value != " " && value != "  " && value != "   " && value != "    ")
                        {
                            result += long.Parse(value);

                        }
                    }
                }

                if (operators[k] == "*")
                {
                    long pivot = 1;

                    for (int y = 0; y < row1WithSpaces[k].Length; y++)
                    {
                        string value = string.Empty;
                        value += row1WithSpaces[k][y];
                        value += row2WithSpaces[k][y];
                        value += row3WithSpaces[k][y];
                        value += row4WithSpaces[k][y];
                        value = String.Join("", value.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                        if (value != "" && value != " " && value != "  " && value != "   " && value != "    ")
                        {
                            pivot *= long.Parse(value);
                        }
                    }
                    result += pivot;
                }
            }
            Console.WriteLine(result);
        }
    }
}

