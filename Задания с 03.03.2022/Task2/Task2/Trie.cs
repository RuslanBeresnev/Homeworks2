namespace LZW;

/// <summary>
/// Реализует структуру "Бор" с посимвольным добавлением и указателем на текущий добавленный символ
/// </summary>
public class Trie
{
    /// <summary>
    /// Вершина структуры
    /// </summary>
    private class Node
    {
        public Node(int number)
        {
            Number = number;
            Childs = new Dictionary<char, Node>();
        }

        /// <summary>
        /// Словарь с дочерними вершинами
        /// </summary>
        public Dictionary<char, Node> Childs { get; set; }

        /// <summary>
        /// Номер вершины
        /// </summary>
        public int Number { get; }
    }

    private Node root;

    private Node currentNode;
    private int numberForNewNode;

    public Trie(int numberOfInitialNode)
    {
        root = new Node(numberOfInitialNode);

        currentNode = root;
        numberForNewNode = numberOfInitialNode;
    }

    /// <summary>
    /// Добавить символ в Бор
    /// </summary>
    /// <returns>Возвращает true, если была создана новая вершина и false, если после добавления указатель остался в пределах Бора</returns>
    public bool AddSymbol(char symbol)
    {
        bool newNodeCreated = false;

        if (!currentNode.Childs.ContainsKey(symbol))
        {
            numberForNewNode++;
            var newNode = new Node(numberForNewNode);
            currentNode.Childs[symbol] = newNode;
            newNodeCreated = true;
        }

        currentNode = currentNode.Childs[symbol];
        return newNodeCreated;
    }

    /// <summary>
    /// Получить номер вершины, на которой в данной момент находится указатель
    /// </summary>
    public int GetCurrentNodeNumber()
    {
        return currentNode.Number;
    }

    /// <summary>
    /// Вернуть указатель на текущую вершину в корень Бора
    /// </summary>
    public void ReturnPointerToRoot()
    {
        currentNode = root;
    }
}