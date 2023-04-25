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
                var elves = line.Split(",").ToList();
                var section0 = elves[0].Split("-").Select(s => int.Parse(s)).ToList();
                var section1 = elves[1].Split("-").Select(s => int.Parse(s)).ToList();
                if (
                    (section0[0] <= section1[0] && section0[1] >= section1[1]) ||
                    (section0[0] >= section1[0] && section0[1] <= section1[1])
                ) {
                    points += 1;
                }
            }
            return points;
        }

        int PartTwo(IEnumerable<string> file)
        {
            int points = 0;
            foreach (var line in file)
            {
                var elves = line.Split(",").ToList();
                var section0 = elves[0].Split("-").Select(s => int.Parse(s)).ToList();
                var section1 = elves[1].Split("-").Select(s => int.Parse(s)).ToList();
                var first = Enumerable.Range(section0[0], (section0[1] - section0[0] + 1));
                var second = Enumerable.Range(section1[0], (section1[1] - section1[0] + 1));
                var locks = 0;
                foreach(var i in first) {
                    if (second.Contains(i) == true) {
                        locks = 1;
                    }
                }
                points += locks;
            }
            return points;
        }
    }
}
