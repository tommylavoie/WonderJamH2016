using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DijkstraCalculator
{
    public int[,] results = new int[Grid.NUMBER_OF_ROWS, Grid.NUMBER_OF_COLS];
    public Position[,] paths = new Position[Grid.NUMBER_OF_ROWS, Grid.NUMBER_OF_COLS];

    public int[,] GetShortestPath(Grid grid, Position start)
    {       
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for(int j=0;j< Grid.NUMBER_OF_COLS;j++)
            {
                results[i, j] = Int32.MaxValue;
            }
        }

        results[start.x, start.y] = 0;
        paths[start.x, start.y] = start;
        if (start.x != 0 && grid.getGrid()[start.x - 1, start.y] == 1)
            GetShortestPathRecursive(grid, new Position(start.x - 1, start.y), start);
        if (start.x != Grid.NUMBER_OF_ROWS - 1 && grid.getGrid()[start.x + 1, start.y] == 1)
            GetShortestPathRecursive(grid, new Position(start.x + 1, start.y), start);
        if (start.y != 0 && grid.getGrid()[start.x, start.y - 1] == 1)
            GetShortestPathRecursive(grid, new Position(start.x, start.y - 1), start);
        if (start.y != Grid.NUMBER_OF_COLS - 1 && grid.getGrid()[start.x, start.y + 1] == 1)
            GetShortestPathRecursive(grid, new Position(start.x, start.y + 1), start);

        return results;
    }

    void GetShortestPathRecursive(Grid grid, Position node, Position caller)
    {
        if (results[node.x, node.y] > results[caller.x, caller.y])
        {
            results[node.x, node.y] = results[caller.x, caller.y] + 1;
            paths[node.x, node.y] = caller;

            if (node.x != 0 && grid.getGrid()[node.x - 1, node.y] == 1)
                GetShortestPathRecursive(grid, new Position(node.x - 1, node.y), node);
            if (node.x != Grid.NUMBER_OF_ROWS - 1 && grid.getGrid()[node.x + 1, node.y] == 1)
                GetShortestPathRecursive(grid, new Position(node.x + 1, node.y), node);
            if (node.y != 0 && grid.getGrid()[node.x, node.y - 1] == 1)
                GetShortestPathRecursive(grid, new Position(node.x, node.y - 1), node);
            if (node.y != Grid.NUMBER_OF_COLS - 1 && grid.getGrid()[node.x, node.y + 1] == 1)
                GetShortestPathRecursive(grid, new Position(node.x, node.y + 1), node);
        }
    }
}
