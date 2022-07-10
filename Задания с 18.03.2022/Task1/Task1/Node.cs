namespace Routers;

using System.Collections.Generic;

/// <summary>
/// Класс вершины графа
/// </summary>
public class Node
{
    private int number;
    private Dictionary<Node, int> adjacentNodes;

    public Node(int number)
    {
        this.number = number;
        adjacentNodes = new Dictionary<Node, int>();
    }

    public Node(int number, Dictionary<Node, int> adjacentNodes)
    {
        this.number = number;
        this.adjacentNodes = adjacentNodes;
    }

    /// <summary>
    /// Получить номер вершины графа
    /// </summary>
    public int Number { get { return number; } }

    /// <summary>
    /// Получить словарь с соседними вершинами и расстояниями до них
    /// </summary>
    public Dictionary<Node, int> AdjacentNodes { get { return adjacentNodes; } }

    /// <summary>
    /// Добавить новую соседнюю вершину к текущей
    /// </summary>
    public void AddAdjacentNode(Node node, int distance)
    {
        adjacentNodes.Add(node, distance);
    }
}