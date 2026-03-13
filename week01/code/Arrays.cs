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
        // be implemented by another person.

        // Plan:
        // - Need an array to hold 'length' multiples
        // - Loop through and fill each spot with number * 1, number * 2, etc.
        // - Since array index starts at 0, I'll multiply by (i + 1) to get the right multiple
        // - Return the filled array

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
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

        // Plan:
        // - To rotate right by 'amount', the last 'amount' elements need to move to the front
        // - I can split the list at position (data.Count - amount)
        // - Grab everything after that split (the part moving to front)
        // - Grab everything before the split (the part moving to back)
        // - Clear the list and add them back in the new order

        int splitPoint = data.Count - amount;
        List<int> rightPortion = data.GetRange(splitPoint, amount);
        List<int> leftPortion = data.GetRange(0, splitPoint);
        data.Clear();
        data.AddRange(rightPortion);
        data.AddRange(leftPortion);
    }
}
