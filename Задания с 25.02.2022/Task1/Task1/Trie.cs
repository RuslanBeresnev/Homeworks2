using System;
using System.Collections.Generic;

public class Trie
{
    private class Node
    {
        public Dictionary<char, Node> childs;
        public bool isTerminal = false;

        internal Node()
        {
            childs = new Dictionary<char, Node>();
        }
    }

    private Node root = new Node();
    public int Size = 0;

    public Trie() { }

    public bool Add(string element)
    {
        Node current = root;
        bool containsBefore = true;

        Size += 1;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                current.childs[letter] = new Node();
                containsBefore = false;
            }
            current = current.childs[letter];
        }

        current.isTerminal = true;

        return !containsBefore;
    }

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

        return current.isTerminal;
    }

    public bool Remove(string element)
    {
        Node current = root;

        Node lastNodeWithChilds = root;
        char firstLetterInLastBranch = '0';

        Size -= 1;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                return false;
            }
            if (current.childs.Count > 1)
            {
                lastNodeWithChilds = current;
                firstLetterInLastBranch = letter;
            }
            current = current.childs[letter];
        }

        lastNodeWithChilds.childs.Remove(firstLetterInLastBranch);

        return true;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        Node current = root;

        foreach (char letter in prefix)
        {
            current = current.childs[letter];
        }

        return current.childs.Count;
    }
}