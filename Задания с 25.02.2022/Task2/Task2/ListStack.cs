using System;

internal class ListStack : IStack
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

    internal ListStack() {}

    internal Node head { get; set; }

    internal bool IsEmpty()
        => count == 0;

    public void Push(double value)
    {
        Node newNode = new Node(value);
        newNode.next = head;
        head = newNode;
        count++;
    }

    public double Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст");
        count--;
        Node temporary = head;
        head = head.next;
        return temporary.value;
    }
}