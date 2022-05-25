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
    /// <returns>Возвращает false, если была создана новая вершина и true, если после добавления указатель остался в пределах Бора
    /// Также возвращает номер вершины, на которой остановился Бор</returns>
    public (bool inTree, int elementNumber) AddSymbol(char symbol)
    {
        bool inTree = true;
        int elementNumber = 0;

        if (!currentNode.Childs.ContainsKey(symbol))
        {
            numberForNewNode++;
            var newNode = new Node(numberForNewNode);
            currentNode.Childs[symbol] = newNode;

            inTree = false;
            elementNumber = numberForNewNode;

            currentNode = root;
        }
        else
        {
            currentNode = currentNode.Childs[symbol];
            elementNumber = currentNode.Number;
        }

        return (inTree, elementNumber);
    }
}