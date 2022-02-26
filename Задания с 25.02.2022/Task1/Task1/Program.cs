using System;

internal class Program
{
    private static bool GlobalTest()
    {
        Trie trie = new Trie();
        trie.Add("Привет");
        trie.Add("Проект");
        trie.Add("Река");
        trie.Add("Реестр");

        bool test1 = trie.Contains("Привет") && trie.Contains("Проект") && trie.Contains("Река") && trie.Contains("Реестр");

        bool test2 = trie.HowManyStartsWithPrefix("Пр") == 2;

        trie.Remove("Привет");
        trie.Remove("Реестр");

        bool test3 = !trie.Contains("Привет") && trie.Contains("Проект") && trie.Contains("Река") && !trie.Contains("Реестр");

        bool test4 = trie.Size == 2;

        return test1 && test2 && test3 && test4;
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