public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data) // if value is already in Data
            return;        // do not insert
        if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data) // is the current node the one I'm looking for?
            return true;

        if (value < Data)
            if (Left != null)
                return Left.Contains(value);
            else
                return false;

        if (Right != null)
            return Right.Contains(value);
        else
            return false;
      
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // If there are no children, then heigh is 1
        if (Left == null && Right == null)
            return 1;

        // Get the height of the Left side
        int leftHeight = 0;
        if (Left != null)
            leftHeight = Left.GetHeight();

        // Get the height of the Right side
        int rightHeight = 0;
        if (Right != null)
            rightHeight = Right.GetHeight();

        // Calculate Hight of "this" tree
        // Height of current tree = 1 (current node) + the bigger side
        if (leftHeight > rightHeight)
            return 1 + leftHeight;
        else
            return 1 + rightHeight;    
    }
}