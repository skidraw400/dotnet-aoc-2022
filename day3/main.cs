internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadLines("./input.txt");
        Console.WriteLine("Part 1: " + PartOne(file));
        Console.WriteLine("Part 2: " + PartTwo(file));

        int PartOne(IEnumerable<string> file)
        {
            int points = 0;
            foreach (var line in file)
            {
                var first_half = line.Substring(0, line.Length / 2);
                var last_half = line.Substring(line.Length / 2, line.Length / 2);
                char shared = '_';
                foreach (char x in first_half)
                {
                    if (last_half.IndexOf(x) != -1) shared = x;
                }
                points += priority(shared);
            }
            return points;
        }

        int PartTwo(IEnumerable<string> file)
        {
            int counter = 0;
            string temp1 = "";
            string temp2 = "";
            int points = 0;
            foreach (var line in file)
            {
                char shared = '_';
                switch (counter)
                {
                    case 0:
                        temp1 = line;
                        break;
                    case 1:
                        temp2 = line;
                        break;
                    default:
                        counter = -1;
                        foreach (var x in line)
                        {
                            if (temp1.Contains(x) && temp2.Contains(x)) shared = x;
                        }
                        points += priority(shared);
                        break;
                }
                counter += 1;
            }
            return points;
        }

        int priority(char x)
        {
            return "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(x);
        }
    }
}