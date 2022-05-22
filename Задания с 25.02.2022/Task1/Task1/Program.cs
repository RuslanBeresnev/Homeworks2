/// <summary>
/// Тесты к программе
/// </summary>
internal class Program
{
    private static bool GlobalTest()
    {
        var trie = new Trie();
        trie.Add("Привет");
        trie.Add("Проект");
        trie.Add("Река");
        trie.Add("Реестр");

        bool test1 = trie.Contains("Привет") && trie.Contains("Проект") && trie.Contains("Река") && trie.Contains("Реестр");

        bool test2 = trie.HowManyStartsWithPrefix("П") == 2;

        trie.Remove("Привет");
        trie.Remove("Реестр");

        bool test3 = !trie.Contains("Привет") && trie.Contains("Проект") && trie.Contains("Река") && !trie.Contains("Реестр");

        bool test4 = trie.Count == 2;

        bool firstSuccessfulAdded = trie.Add("Проект");
        bool secondSuccessfulAdded = trie.Add("Река");

        bool test5 = !firstSuccessfulAdded && !secondSuccessfulAdded;
        bool test6 = trie.Count == 2;

        bool firstSuccessfulRemoved = trie.Remove("Привет");
        bool secondSuccessfulRemoved = trie.Remove("Реестр");

        bool test7 = !firstSuccessfulRemoved && !secondSuccessfulRemoved;
        bool test8 = trie.Count == 2;

        return test1 && test2 && test3 && test4 && test5 && test6 && test7 && test8;
    }

    public static void Main(string[] args)
    {
        if (GlobalTest())
        {
            Console.WriteLine("Всё работает");
        }
        else
        {
            Console.WriteLine("Кажется, что-то не так");
        }
    }
}