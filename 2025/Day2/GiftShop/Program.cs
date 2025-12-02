namespace GiftShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
            string input = File.ReadAllText("C:\\Dev\\AdventOfCode\\2025\\Day2\\GiftShop\\input.txt");

            string[] idRanges = input.Split(',');
            long sum = 0;

            foreach (string idRange in idRanges)
            {
                long firstId = long.Parse(idRange.Remove(idRange.IndexOf('-')));
                long lastId = long.Parse(idRange.Substring(idRange.IndexOf("-") + 1));

                for (long id = firstId; id <= lastId; id++)
                {
                    for (int size = 1; size <= id.ToString().Length / 2; size++)
                    {
                        string pattern = id.ToString().Substring(0, size);
                        string comparePattern = "";

                        for (int i = 0; i < id.ToString().Length / size; i++)
                        {
                            comparePattern += pattern;
                        }

                        if (comparePattern == id.ToString())
                        {
                            sum += id;
                            break;
                        }
                    }
                }
            }
        }
    }
}