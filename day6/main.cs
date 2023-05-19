internal partial class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadAllText("./input.txt");
        int Check(string file, int cnt)
        {
            for (int i = 0; i < file.Count() - cnt-1; i++)
            {
                var temp = file.Substring(i, cnt);
                int sum = 0;
                foreach (char letter in temp)
                    if (temp.Replace(letter.ToString(), "").Count() == cnt-1)
                        sum += 1;
                if (sum == cnt)
                    return i+cnt;
            }
            return 0;
        }
        Console.WriteLine(Check(file, 4));
        Console.WriteLine(Check(file, 14));
    }
}
