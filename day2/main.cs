internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadLines("./input.txt");

        Console.WriteLine("Part 1: " + PartOne(file));
        Console.WriteLine("Part 2: " + PartTwo(file));

        int PartOne(IEnumerable<string> file)
        {
            var myPoints = 0;
            foreach (var line in file)
            {
                var myMove = translate(line[2]);
                var theirMove = translate(line[0]);
                myPoints += myMove + whowins(myMove, theirMove);
            }
            return myPoints;
        }

        int PartTwo(IEnumerable<string> file)
        {
            var myPoints = 0;
            foreach (var line in file)
            {
                var theirMove = translate(line[0]);
                var target_points = "X__Y__Z".IndexOf(line[2]);
                foreach (int x in Enumerable.Range(1, 3))
                {
                    if (whowins(x, theirMove) == target_points) myPoints += x;
                }
                myPoints += target_points;
            }
            return myPoints;
        }

        int whowins(int your, int their)
        {
            if (your == their) return 3;
            else return (your, their) switch
            {
                (1, 3) => 6,
                (2, 1) => 6,
                (3, 2) => 6,
                _ => 0
            };
        }

        // 1 rock, 2 paper, 3 scissors
        int translate(char move)
        {
            int index = "_XYZ".IndexOf(move);
            if (index == -1) index = "_ABC".IndexOf(move);
            return index;
        }
    }
}