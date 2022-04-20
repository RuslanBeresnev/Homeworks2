namespace Routers;

using System.Collections.Generic;

/// <summary>
/// Класс графа
/// </summary>
public class Graph
{
    private Node[] nodes;
    private int count = 0;
    private const int MAX_SIZE = 1000;

    public Graph()
    {
        nodes = new Node[MAX_SIZE];
    }

    public Graph(Node[] nodes)
    {
        this.nodes = nodes;
        count = nodes.Length;
    }

    /// <summary>
    /// Получить все вершины графа
    /// </summary>
    public Node[] Nodes { get { return nodes; } }

    /// <summary>
    /// Получить количество вершин в графе
    /// </summary>
    public int Count { get { return count; } }

    /// <summary>
    /// Добавить вершину в граф
    /// </summary>
    public void AddNode(Node newNode)
    {
        nodes[count++] = newNode;
    }

    /// <summary>
    /// Получить вершину графа по её номеру
    /// </summary>
    public Node? GetNodeByNumber(int number)
    {
        for (int i = 0; i < count; i++)
        {
            if (nodes[i].Number == number)
            {
                return nodes[i];
            }
        }
        return null;
    }

    private static void VisitAdjacentNodesRecursive(Node startNode, List<Node> visitedNodes)
    {
        visitedNodes.Add(startNode);
        foreach (var adjacentNode in startNode.AdjacentNodes.Keys)
        {
            if (!visitedNodes.Contains(adjacentNode))
            {
                VisitAdjacentNodesRecursive(adjacentNode, visitedNodes);
            }
        }
    }

    /// <summary>
    /// Определить связность графа
    /// </summary>
    public static bool IsGraphCoherence(Graph graph)
    {
        var visitedNodes = new List<Node>();
        VisitAdjacentNodesRecursive(graph.Nodes[0], visitedNodes);
        return visitedNodes.Count == graph.Count;
    }

    /// <summary>
    /// Построить максимальное оставное дерево из данного графа
    /// </summary>
    public static Graph? GetMaximalSpanningTree(Graph graph)
    {
        if (!IsGraphCoherence(graph))
        {
            return null;
        }

        var maximalSpanningTree = new Graph();
        var nodesFromGraphAddedToMaximalSpanningTree = new List<Node>();

        nodesFromGraphAddedToMaximalSpanningTree.Add(graph.Nodes[0]);
        maximalSpanningTree.AddNode(new Node(graph.Nodes[0].Number));

        while (maximalSpanningTree.Count != graph.Count)
        {
            int maxDistance = 0;
            Node furtherNode = null!;
            Node furtherNodeAncestor = null!;

            foreach (var node in nodesFromGraphAddedToMaximalSpanningTree)
            {
                foreach (var adjacentNodeData in node.AdjacentNodes)
                {
                    if (!nodesFromGraphAddedToMaximalSpanningTree.Contains(adjacentNodeData.Key) &&
                        adjacentNodeData.Value >= maxDistance)
                    {
                        maxDistance = adjacentNodeData.Value;
                        furtherNode = adjacentNodeData.Key;
                        furtherNodeAncestor = node;
                    }
                }
            }

            var furtherNodeWithoutEdges = new Node(furtherNode.Number);
            var ancestorNodeInMaximalSpanningTree = maximalSpanningTree.GetNodeByNumber(furtherNodeAncestor.Number)!;
            ancestorNodeInMaximalSpanningTree.AddAdjacentNode(furtherNodeWithoutEdges, maxDistance);

            nodesFromGraphAddedToMaximalSpanningTree.Add(furtherNode);
            maximalSpanningTree.AddNode(furtherNodeWithoutEdges);
        }

        return maximalSpanningTree;
    }
}