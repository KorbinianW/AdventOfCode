namespace Lobby
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] banks = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day3\\Lobby\\input.txt");
            string[] banks = ["987654321111111", "811111111111119", "234234234234278", "818181911112111"];

            long joltage = 0;
            int test = 0;

            foreach (var bank in banks)
            {
                int remainingBatteries = 12;
                //int i = bank.IndexOf(largestBattery.ToString());
                string activatedBatteries = string.Empty;
                int currentArea = 0;

                for (int i = 0; i < bank.Length; i++)
                {
                    int largestBattery = int.Parse(bank[i].ToString());

                    if (remainingBatteries >= 0)
                    {
                        currentArea = bank.Length - remainingBatteries + 1;
                    }

                    for (int j = i; j < currentArea; j++)
                    {
                        int indexOfLargest = j;

                        if (largestBattery < int.Parse(bank[j].ToString()))
                        {
                            largestBattery = int.Parse(bank[j].ToString());
                            indexOfLargest = j;
                        }
                            i = indexOfLargest;
                    }
                    activatedBatteries += largestBattery.ToString();

                    largestBattery = 0;
                    remainingBatteries--;

                }
                joltage += long.Parse(activatedBatteries);
            }
            Console.WriteLine(joltage);
        }
    }
}