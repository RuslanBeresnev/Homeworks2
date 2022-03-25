using System;

namespace PostfixCalculator;

public class ListStack : IStack
{
    public class Node
    {
        public double value;

        public Node(double value)
        {
            this.value = value;
        }

        public Node next { get; set; }
    }

    private int count;

    public ListStack() {}

    internal Node head { get; set; }

    public bool IsEmpty()
        => count == 0;

    public void Push(double value)
    {
        Node newNode = new Node(value);
        newNode.next = head;
        head = newNode;
        count++;
    }

    public (double?, bool) Pop()
    {
        if (IsEmpty())
            return (null, false);
        count--;
        Node temporary = head;
        head = head.next;
        return (temporary.value, true);
    }
}