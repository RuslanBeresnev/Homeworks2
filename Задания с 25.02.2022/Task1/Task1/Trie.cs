/// <summary>
/// Структура "Бор"
/// </summary>
public class Trie
{
    private class Node
    {
        public Dictionary<char, Node> childs;

        public Node()
        {
            childs = new Dictionary<char, Node>();
        }

        /// <summary>
        /// Конечная ли вершина
        /// </summary>
        public bool IsTerminal { get; set; }
    }

    private Node root = new();

    /// <summary>
    /// Количество элементов в структуре
    /// </summary>
    public int Count { get; set; } = 0;

    /// <summary>
    /// Добавить новое слово в структуру (если добавление произошло, возвращает true)
    /// </summary>
    public bool Add(string element)
    {
        Node current = root;
        bool containsBefore = true;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                current.childs[letter] = new Node();
                containsBefore = false;
            }
            current = current.childs[letter];
        }

        if (!current.IsTerminal)
        {
            containsBefore = false;
        }

        current.IsTerminal = true;
        if (!containsBefore)
        {
            Count++;
        }

        return !containsBefore;
    }

    /// <summary>
    /// Проверка на наличие слова в структуре
    /// </summary>
    public bool Contains(string element)
    {
        Node current = root;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                return false;
            }
            current = current.childs[letter];
        }

        return current.IsTerminal;
    }

    /// <summary>
    /// Удаление слова из структуры (если удаление произошло, возвращает true)
    /// </summary>
    public bool Remove(string element)
    {
        Node current = root;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                return false;
            }
            current = current.childs[letter];
        }

        if (current.IsTerminal)
        {
            current.IsTerminal = false;
            Count -= 1;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Рекурсивно получить количество терминальных точек на всех путях, начинающихся в стартовой вершине
    /// </summary>
    private int HowManyTerminalNodesRecursive(Node startNode)
    {
        if (startNode.IsTerminal)
        {
            return 1;
        }

        int terminalNodesCount = 0;
        foreach (var letter in startNode.childs.Keys)
        {
            terminalNodesCount += HowManyTerminalNodesRecursive(startNode.childs[letter]);
        }

        return terminalNodesCount;

    }

    /// <summary>
    /// Проверить, сколько слов в структуре начинаются с данного префикса
    /// </summary>
    /// <param name="prefix">Заданный префикс</param>
    public int HowManyStartsWithPrefix(string prefix)
    {
        Node current = root;

        foreach (char letter in prefix)
        {
            if (!current.childs.ContainsKey(letter))
            {
                return 0;
            }
            current = current.childs[letter];
        }

        return HowManyTerminalNodesRecursive(current);
    }
}