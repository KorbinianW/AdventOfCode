namespace Cafeteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] input = ["50-60", "2-4", "3-5", "10-14", "16-20", "10-29", "12-18", "33-46", "22-22", "", "1", "5", "8", "11", "17", "32"];
            string[] input = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day5\\Cafeteria\\input.txt");

            string[] freshIngredients = new string[input.IndexOf("")];

            long edibleIngredients = 0;

            for (int x = 0; x < input.IndexOf(""); x++)
            {
                freshIngredients[x] = input[x];
            }

            freshIngredients = freshIngredients.OrderBy(item => long.Parse(item.Split('-')[0]))
                                               .ToArray();

            long currentFirst = -1;
            long currentLast = -1;

            foreach (string freshIngredientRange in freshIngredients)
            {
                long firstIngredient = long.Parse(freshIngredientRange.Substring(0, freshIngredientRange.IndexOf("-")));
                long lastIngredient = long.Parse(freshIngredientRange.Substring(freshIngredientRange.IndexOf("-") + 1, freshIngredientRange.Length - freshIngredientRange.IndexOf("-") - 1));

                if (currentFirst == -1)
                {
                    currentFirst = firstIngredient;
                    currentLast = lastIngredient;
                    continue;
                }

                // Overlapping or touching: merge
                if (firstIngredient <= currentLast + 1)
                {
                    if (lastIngredient > currentLast)
                        currentLast = lastIngredient;
                }
                else
                {
                    // Gap → close previous merged interval
                    edibleIngredients += (currentLast - currentFirst + 1);

                    // Start new merged interval
                    currentFirst = firstIngredient;
                    currentLast = lastIngredient;
                }

                //if (lastIngredient > currentIngredient)
                //{
                //    if (currentIngredient == 0)
                //    {
                //        edibleIngredients += (lastIngredient - firstIngredient) + 1;
                //    }

                //    else if (firstIngredient > currentIngredient)
                //    {
                //        edibleIngredients += (lastIngredient - firstIngredient) + 1;
                //    }

                //    else if (firstIngredient < currentIngredient)
                //    {
                //        edibleIngredients += (lastIngredient - (currentIngredient + 1)) + 1;
                //    }

                //    currentIngredient = lastIngredient;
                //}
            }
            if (currentFirst != -1)
            {
                edibleIngredients += (currentLast - currentFirst + 1);
            }

            Console.WriteLine(edibleIngredients);
        }
    }
}
