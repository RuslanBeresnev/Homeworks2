using System;
using System.Collections.Generic;

/// <summary>
/// Структура "Бор"
/// </summary>
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

    /// <summary>
    /// Добавить новое слово в структуру (если добавление произошло, возвращает true)
    /// </summary>
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

        if (!current.isTerminal)
        {
            containsBefore = false;
        }

        current.isTerminal = true;

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

        return current.isTerminal;
    }

    /// <summary>
    /// Удаление слова из структуры (если удаление произошло, возвращает true)
    /// </summary>
    public bool Remove(string element)
    {
        Node current = root;

        Size -= 1;

        foreach (char letter in element)
        {
            if (!current.childs.ContainsKey(letter))
            {
                return false;
            }
            current = current.childs[letter];
        }

        current.isTerminal = false;

        return true;
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
            current = current.childs[letter];
        }

        return current.childs.Count;
    }
}