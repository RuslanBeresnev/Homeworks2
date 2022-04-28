namespace ControlWorkRewriteTests;

using NUnit.Framework;
using ControlWorkRewrite;
using System;

public class OrderedQueueTests
{
    [Test]
    public void EnqueueAndDequeueMethodsTest()
    {
        var queue = new OrderedQueue<int>();

        queue.Enqueue(1, 5);
        queue.Enqueue(2, 4);
        queue.Enqueue(3, 4);
        queue.Enqueue(4, 3);
        queue.Enqueue(5, 3);

        Assert.AreEqual(queue.Dequeue(), 1);
        Assert.AreEqual(queue.Dequeue(), 2);
        Assert.AreEqual(queue.Dequeue(), 3);
        Assert.AreEqual(queue.Dequeue(), 4);
        Assert.AreEqual(queue.Dequeue(), 5);
    }

    [Test]
    public void EmptyPropertyInNotEmptyQueueTest()
    {
        var queue = new OrderedQueue<int>();
        queue.Enqueue(1, 1);
        Assert.False(queue.Empty);
    }

    [Test]
    public void EmptyPropertyInEmptyQueueTest()
    {
        var queue = new OrderedQueue<int>();
        queue.Enqueue(1, 1);
        queue.Dequeue();
        Assert.True(queue.Empty);
    }

    [Test]
    public void DequeueFromEmptyQueueTest()
    {
        var queue = new OrderedQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
}