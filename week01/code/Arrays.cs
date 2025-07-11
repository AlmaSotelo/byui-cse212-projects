using System.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person:

        // My Plan:
        // 1.Provide "number" as input to the function
        // 2.Provide "length" as input to the function
        // 3.Create an array of size the "length" value
        // Note: Our array will start with "number" as the first element. Here is why we know that any number is multiple of itself;
        //           x is multiple of n if x divided by n the module is 0 (x%n=0)
        //           x=7, n=7 then 7%7=0
        // 4.What other numbers (x's) divided by "number" result a module of 0 that could be added to our array? 
        //    4.1  Add to our array values resulting from multiplying "number" by 1, then  by 2, then by 3,and so on until we reach "length" times.
        //    Explanation: 7 x 1 = 7
        //                 7 x 2 = 14  <-- 14 is multiple of 7
        //                 7 x 3 = 21  <-- 21 is multiple of 7
        //                 7 x 4 = 28           and so on..
        //                 7 x 5 = 35   

        // My code:
        var result = new double[length];
        //var increment = number;
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
                
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // My plan:
        // 1.Create a new empty list where to hold the segments
        // 2.Hold the size of the original list in a variable
        // 3.Get the segment between index=0 to index=originalSize-amount-1 and add it to the end
        // 4.Remove segment from index=0 to index=current size minus original size.
    
        // My code:
        List<int> segment;
        int originalSize = data.Count;
        segment = data.GetRange(0, originalSize-amount);
        data.AddRange(segment);
        data.RemoveRange(0, data.Count - originalSize);
        

    }
}
