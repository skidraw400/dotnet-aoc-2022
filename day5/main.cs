internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadLines("./input.txt");
        Console.WriteLine("Part 1: " + PartOne(file));

        string PartOne(IEnumerable<string> file)
        {
            List<string> lines = file.ToList();

            // Determine where stacks are ending
            int endOfStacks = 0;
            foreach (var line in lines)
                if (line.IndexOf("[") != -1)
                    endOfStacks += 1;

            // Generate stacks 
            List<string>[] GenStacks()
            {
                List<List<string>> stackList = new List<List<string>>();
                foreach (var cha in lines[endOfStacks].Split())
                    if (cha != "")
                        stackList.Add(new List<string>());
                return stackList.ToArray();
            }

            var stacks = GenStacks();
            var max = stacks.Count();

            // Add items to lists
            for (int i = 0; i < endOfStacks; i++)
            {
                for (int u = 0; u < max; u++)
                {
                    char item = lines[endOfStacks - 1 - i][(u) * 4 + 1];
                    if (item != ' ')
                        stacks[u].Insert(0, item.ToString());
                }
            }

            // Move elements
            foreach (int i in Enumerable.Range(endOfStacks + 2, lines.Count() - endOfStacks - 2))
            {
                var command = lines[i].Split();
                foreach (int u in Enumerable.Range(1, int.Parse(command[1])))
                {
                    var OldStack = int.Parse(command[3]) - 1;
                    var NewStack = int.Parse(command[5]) - 1;
                    var element = stacks[OldStack][0];
                    stacks[OldStack].RemoveAt(0);
                    stacks[NewStack].Insert(0, element);
                }
            }

            // Create top (first) elements string
            string answer = "";
            foreach (var stack in stacks)
                if (stack.Count > 0)
                    answer += stack[0];

            return answer;
        }
    }
}
