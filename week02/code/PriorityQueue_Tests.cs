using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: A1, B2, C3 . Simple priorities
    // Expected Result: Removed in this order C3, B2, A1  
    // Defect(s) Found:Expected C, but B. Fixes made in the Dequeue method. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Trace.Assert(result == "C", "Must be C");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "B", "must be B");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "A", "must be A");

    }

    [TestMethod]
    // Scenario: B2, A2, C1. Testing when two same high priority at the begining.
    // Expected Result: Removed in this order B2, A2, C1
    // Defect(s) Found:Expected B, but A. Fixes made in the Dequeue method. 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("C", 1);

        var result = priorityQueue.Dequeue();
        Trace.Assert(result == "B");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "A");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "C");
       
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: A1, B2, C2. Testing when two same high priority at the end.
    // Expected Result: Removed in this order B2, C2, A1
    // Defect(s) Found: Expected B, but A. Fixes made in the Dequeue method.  
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Trace.Assert(result == "B");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "C");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "A");        
    }

    [TestMethod]
    // Scenario: A3, B1, C2. Testing when all priority are mixed.
    // Expected Result: Removed in this order B3, C2, A1
    // Defect(s) Found:Expected A, but B. Fixes made in the Dequeue method. 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Trace.Assert(result == "A");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "C");

        result = priorityQueue.Dequeue();
        Trace.Assert(result == "B");        
    }
}