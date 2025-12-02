using System.Diagnostics;

namespace SecretEntrance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dialValues = File.ReadAllLines("C:\\Dev\\AdventOfCode\\2025\\Day1\\puzzle_input.txt");
            //string[] dialValues = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];

            int position = 50;
            int zeroCount = 0;

            foreach (string dialValue in dialValues)
            {
                int previousPosition = position;
                char direction = dialValue[0];
                int distance = int.Parse(dialValue.Remove(0, 1));

                int fullRotations = distance / 100;
                zeroCount += fullRotations;
                distance %= 100;

                if (direction == 'R')
                {
                    position += distance;
                }
                else
                {
                    position -= distance;
                    if (position < 0)
                    {
                        position += 100;
                    }
                }

                position %= 100;

                if (position == 0 || previousPosition != 0 && (
                (previousPosition > position && direction == 'R') ||
                (previousPosition < position && direction == 'L')))
                {
                    zeroCount++;
                }
            }
            Debug.WriteLine(zeroCount);
        }
    }
}