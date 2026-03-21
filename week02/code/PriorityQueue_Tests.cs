using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add a few items with different priorities then dequeue.
    // Expected Result: Should get back "Sue" since she has the highest priority (3).
    // Defect(s) Found: Three bugs — the loop skipped the last item (Count - 1 instead of Count),
    //   the >= check broke FIFO order for ties, and the item was never actually removed from the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", result);
    }

    [TestMethod]
    // Scenario: Add items where two share the same highest priority.
    // Expected Result: Should get "Tim" first since he was added before "Sue" (FIFO tiebreak).
    // Defect(s) Found: The >= in the loop picked the last same-priority item instead of the first,
    //   so it returned "Sue" instead of "Tim". Changing to > fixed the FIFO behavior.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Should throw an InvalidOperationException saying "The queue is empty."
    // Defect(s) Found: None, this part worked correctly out of the box.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Dequeue multiple times to make sure items actually get removed each time.
    // Expected Result: Should come out in order Sue(3), Tim(2), Bob(1).
    // Defect(s) Found: Items were never removed from the list (no RemoveAt call),
    //   so the same highest-priority item kept coming back every time.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Put the highest priority item at the very end of the queue.
    // Expected Result: Should still return "Last" (priority 10) even though it was added last.
    // Defect(s) Found: The loop used Count - 1 as the upper bound so it never even looked
    //   at the last element. The highest priority item at the end was completely ignored.
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Middle", 2);
        priorityQueue.Enqueue("Last", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Last", result);
    }
}
