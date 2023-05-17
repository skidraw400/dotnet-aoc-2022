internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadLines("./input.txt").ToArray();

        // PARSING:
        int max = 0;
        int endOfStacks = 0;
        // Determine where stacks are ending
        foreach (var line in file)
            if (line.IndexOf("[") != -1)
                endOfStacks += 1;
        // Generate stack lists
        foreach (var cha in file[endOfStacks].Split())
            if (cha != "")
                max += 1;
        List<string>[] stacks = new List<String>[max];
        List<string>[] stacks2 = new List<String>[max];
        for (int i = 0; i < stacks.Count(); i++)
        {
            stacks[i] = new List<string>();
            stacks2[i] = new List<string>();
        }
        // Add items to lists
        for (int i = 0; i < endOfStacks; i++)
        {
            for (int u = 0; u < max; u++)
            {
                char item = file[endOfStacks - 1 - i][(u) * 4 + 1];
                if (char.IsLetterOrDigit(item))
                {
                    stacks[u].Insert(0, item.ToString());
                    stacks2[u].Insert(0, item.ToString());
                }
            }
        }

        // Tasks
        // Move elements
        foreach (int i in Enumerable.Range(endOfStacks + 2, file.Count() - endOfStacks - 2))
        {
            var command = file[i].Split();
            var OldStack = int.Parse(command[3]) - 1;
            var NewStack = int.Parse(command[5]) - 1;
            int cnt = int.Parse(command[1]);
            // Part 1
            foreach (int u in Enumerable.Range(1, cnt))
            {
                var element = stacks[OldStack][0];
                stacks[OldStack].RemoveAt(0);
                stacks[NewStack].Insert(0, element);
            }
            // Part 2
            var elements = stacks2[OldStack].GetRange(0, cnt);
            stacks2[OldStack].RemoveRange(0, cnt);
            stacks2[NewStack].InsertRange(0, elements);
        }

        // Print
        foreach(var stacklist in new List<string>[][] {stacks, stacks2}) {
            foreach(var stack in stacklist)
                if(stack.Count() > 0) 
                    Console.Write(stack[0]);
            Console.WriteLine();
        }
    }
}
