using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GoalInfo
{
    Position position;
    int player;

    public GoalInfo(Position p, int player)
    {
        this.position = p;
        this.player = player;
    }

    public int GetPlayerNumber()
    {
        return player;
    }

    public Position getCellConnectedToGoal()
    {
        if (position.x == -1)
        {
            return new Position(0, position.y);
        }
        else if (position.x == Grid.NUMBER_OF_ROWS)
        {
            return new Position(Grid.NUMBER_OF_ROWS - 1, position.y);
        }
        else if (position.y == -1)
        {
            return new Position(position.x, 0);
        }
        else if (position.y == Grid.NUMBER_OF_COLS)
        {
            return new Position(position.x, Grid.NUMBER_OF_COLS - 1);
        }
        else
            return null;
    }
}
