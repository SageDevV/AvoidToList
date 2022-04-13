class Program
{
    private static List<string> dictionary = new List<string>(150000);
    private static IEnumerable<string> story = null;
    private static string _dictionaryWay;
    private static string _storyWay;
    private static IEnumerable<string> ReadFile(string file)
    {
        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                yield return line;
            }
        }
    }
    private static void SpellCheck()
    {
        var result =
            from word in story
            let lowerCase = word.ToLower()
            select new { Word = word, Ok = dictionary.Contains(lowerCase) };
        foreach (var item in result)
        {
            Console.ForegroundColor = item.Ok ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(item.Word);
            Console.WriteLine(" ");
        }
        Console.ResetColor();

    }
    static void Main(string[] args)
    {
        foreach (var word in ReadFile(_dictionaryWay))
        {
            dictionary.Add(word);
        }
        story = ReadFile(_storyWay);
        SpellCheck();
    }
}
