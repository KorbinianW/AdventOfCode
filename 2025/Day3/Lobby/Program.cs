namespace Lobby
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banks = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day3\\Lobby\\input.txt");
            //string[] banks = ["987654321111111", "811111111111119", "234234234234278", "818181911112111"];

            int sum = 0;

            foreach (var bank in banks)
            {
                int largestBattery = int.Parse(bank[0].ToString());

                for (int j = 0; j < bank.Length - 1; j++)
                {
                    var battery = int.Parse(bank[j].ToString());

                    if (battery > largestBattery)
                    {
                        largestBattery = battery;
                    }
                }
                string jolts = largestBattery.ToString();
                int secondLargestBattery = 0;

                {
                    for (int i = bank.IndexOf(largestBattery.ToString()) + 1; i < bank.Length; i++)
                    {
                        var battery = int.Parse(bank[i].ToString());

                        if (battery > secondLargestBattery)
                        {
                            secondLargestBattery = battery;
                        }
                    }
                }
                jolts += secondLargestBattery.ToString();

                Console.WriteLine(jolts);

                sum += int.Parse(jolts);
            }
            Console.WriteLine(sum);
        }
    }
}