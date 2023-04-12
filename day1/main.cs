internal class Program
{
    private static void Main(string[] args)
    {
        // Group Elves
        var file = File.ReadLines("./input.txt");
        List<int> sum = new List<int>();
        int calories = 0;
        foreach (var line in file)
        {
            if (line != "")
            {
                calories = calories + int.Parse(line);
            }
            else
            {
                sum.Add(calories);
                calories = 0;
            }
        }
        sum.Add(calories);

        sum.Sort();
        sum.Reverse();

        // Part 1
        Console.WriteLine("Part one: " + sum[0]);

        // Part 2
        int p2sum = 0;
        foreach (var x in sum.GetRange(0, 3)) {
            p2sum = p2sum + x;
        }
        Console.WriteLine("Part two: " + p2sum);

    }
}