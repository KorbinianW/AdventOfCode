using System.Diagnostics;

namespace SecretEntrance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] dialValues = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day1\\puzzle_input.txt");
            string[] dialValues = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];

            int currentDialValue = 50;
            int count = 0;

            foreach (string dialValue in dialValues)
            {
                char direction = dialValue[0];
                int value = int.Parse(dialValue.Remove(0, 1));

                if (direction == 'R')
                {
                    if ((currentDialValue + value) >= 100)
                    {
                        count += (currentDialValue + value) / 100;
                    }

                    currentDialValue = (currentDialValue + value) % 100;
                }

                if (direction == 'L')
                {
                    if ((currentDialValue - value) <= 0)
                    {
                        if (currentDialValue != 0)
                        {
                            count += 1;
                        }

                        if (currentDialValue == 0 && ((currentDialValue - value) % 100) == 0)
                        {
                            count += -(currentDialValue - value) / 100;
                            currentDialValue = (-(currentDialValue - value) % 100);
                        }
                        else
                        {
                            count += -(currentDialValue - value) / 100;
                            currentDialValue = 100 + ((currentDialValue - value) % 100);
                        }
                    }
                    else
                    {
                        currentDialValue = ((currentDialValue - value) % 100);
                    }

                }

                //if (currentDialValue == 0)
                //{
                //    count += 1;
                //}
            }
            Debug.WriteLine(count);
        }
    }
}
