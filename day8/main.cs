internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadLines("./input.txt").ToList();

        // create map
        int height = 0;
        int width = 0;
        foreach (var line in file)
            height += 1;
        foreach (var column in file[0])
            width += 1;
        int[,] map = new int[width, height];

        // parse file
        foreach (int x in Enumerable.Range(0, width))
            foreach (int y in Enumerable.Range(0, height))
                map[x, y] = int.Parse(file[y][x].ToString());

        // Check visibility function
        bool CheckVisibility(int x, int y)
        {
            int size = map[x, y];
            int[] visible = new int[] { 1, 1, 1, 1 };
            // vertical check
            for (int i = 0; i < height; i++)
            {
                // top visibility
                if (i < y)
                    if (map[x, i] >= size)
                        visible[0] = 0;
                // bottom visibility
                if (i > y)
                    if (map[x, i] >= size)
                        visible[1] = 0;
            }
            // horizontal check
            for (int i = 0; i < width; i++)
            {
                if (i < x)
                    if (map[i, y] >= size)
                        visible[2] = 0;
                if (i > x)
                    if (map[i, y] >= size)
                        visible[3] = 0;
            }
            if (visible.Sum() > 0)
                return true;
            else
                return false;
        }
        int sum = 0;
        foreach (int x in Enumerable.Range(0, width))
            foreach (int y in Enumerable.Range(0, height))
                if (CheckVisibility(x, y) == true)
                    sum += 1;
        Console.WriteLine(sum);
    }
}
