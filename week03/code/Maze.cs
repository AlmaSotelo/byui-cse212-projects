/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
 
/// Example using the given maze. Position (1,1) has wall at top and left, and is open right and down
/// _mazeMap[(1,1)] = {false, true, false, true}
///                      ^      ^     ^      ^
///                     left  right  top   down 
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap; //Dictionary<ValueTuple<int, int>... is same as Dictionary<(int _currX, int _currY), bool[]... because both are part of the key.
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][0]) // can move left from here?. From the structure of the maping above, the value of left is stored in index 0
            _currX-= 1;
        else
            throw new InvalidOperationException("Can't go that way!");   
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][1]) // move to the right? is in index 1
            _currX+= 1;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][2]) // move up? is in index 2
            _currY-= 1; // decrease in Y
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        if (_mazeMap[(_currX, _currY)][3]) // move down is in index 3
            _currY+= 1; // Y increases
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}