using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    int[,] grid;
    GoalInfo[] goals;
    Position[] spawners;
    List<ShortestPathThread> threadsRunning;

	// Use this for initialization
	void Start ()
    {
        Init();
        threadsRunning = new List<ShortestPathThread>();
    }

    void Init()
    {
        grid = new int[NUMBER_OF_ROWS, NUMBER_OF_COLS];
        for (int i=0;i<NUMBER_OF_ROWS;i++)
        {
            for(int j=0;j<NUMBER_OF_COLS;j++)
            {
                grid[i,j] = 0;
            }
        }
        goals = new GoalInfo[6];
        goals[0] = new GoalInfo(new Position(-1, 1), 1);
        goals[1] = new GoalInfo(new Position(7, -1), 0);
        goals[2] = new GoalInfo(new Position(NUMBER_OF_ROWS, 13), 0);
        goals[3] = new GoalInfo(new Position(NUMBER_OF_ROWS, 22), 1);
        goals[4] = new GoalInfo(new Position(-1, 34), 0);
        goals[5] = new GoalInfo(new Position(8, NUMBER_OF_COLS), 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        List<ShortestPathThread> finishedThreads = new List<ShortestPathThread>();
	    foreach(ShortestPathThread t in threadsRunning)
        {
            if(t.GetResult() != null)
            {
                t.NotifyListener();
                finishedThreads.Add(t);
            }
        }
        foreach(ShortestPathThread f in finishedThreads)
        {
            threadsRunning.Remove(f);
        }
	}

    public int[,] getGrid()
    {
        return grid;
    }

    public int GetElement(int row, int col)
    {
        return grid[row, col];
    }

    public bool IsPositionValid(int row, int col)
    {
        if (row >= 0 && row < NUMBER_OF_ROWS && col >= 0 && col < NUMBER_OF_COLS)
            return true;
        else
            return false;
    }

    public GoalInfo[] getGoals()
    {
        return goals;
    }

    public Position[] getSpawners()
    {
        return spawners;
    }

    public void setSpawners(Position[] s)
    {
        spawners = s;
    }

    public void SetElement(int element, Position position)
    {
        if (position.x >= 0 && position.x < NUMBER_OF_ROWS && position.y >= 0 && 
            position.y < NUMBER_OF_COLS)
            grid[position.x, position.y] = element;
    }

    public GoalInfo GetAssociatedGoal(Position association)
    {
        foreach(GoalInfo goal in goals)
        {
            Position goalConnected = goal.getCellConnectedToGoal();
            if (association.x == goalConnected.x && association.y == goalConnected.y)
                return goal;
        }
        return null;
    }

    public void StartShortestConnectionFinding(DijkstraListener listener, Position start)
    {
        ShortestPathThread t = new ShortestPathThread(listener, this, goals, start);
        threadsRunning.Add(t);
        t.Start();
    }

    /*List<Position> CreatePath(Position[,] paths, Position goal)
    {
        Stack<Position> path = new Stack<Position>();
        Position actual = goal;
        bool finished = false;
        while (!finished)
        {
            path.Push(actual);
            Position newPosition = paths[actual.x, actual.y];
            if (newPosition.x == actual.x && newPosition.y == actual.y)
                finished = true;
            else
                actual = newPosition;
        }
        List<Position> list = new List<Position>();
        while (path.Count != 0)
        {
            list.Add(path.Pop());
        }
        return list;
    }


    public List<Position> GetShortestConnection(Position start)
    {
        DijkstraCalculator dc = new DijkstraCalculator();
        int[,] results = dc.GetShortestPath(this, start);
        Position minGoal = null;
        int minGoalValue = Int32.MaxValue;
        foreach (GoalInfo goal in goals)
        {
            Position cell = goal.getCellConnectedToGoal();
            if (results[cell.x, cell.y] != Int32.MaxValue && results[cell.x, cell.y] < minGoalValue)
            {
                minGoal = cell;
                minGoalValue = results[cell.x, cell.y];
            }
        }

        List<Position> path = null;
        if (minGoal != null)
            path = CreatePath(dc.paths, minGoal);
        else
            path = new List<Position>();
        return path;
    }*/

    public void print()
    {
        for (int i = 0; i < NUMBER_OF_ROWS; i++)
        {
            String printing = "";
            for (int j = 0; j < NUMBER_OF_COLS; j++)
            {
                printing += grid[i, j] + ",";
            }
            Debug.Log(printing);
        }
    }

    public static int NUMBER_OF_ROWS = 16;
    public static int NUMBER_OF_COLS = 36;
    public static int NUMBER_OF_GOALS = 2;

    public static int EMPTY = 0;
    public static int CELL = 1;
    public static int GOAL_1 = 2;
    public static int GOAL_2 = 3;
    public static int SPAWN = 4;
    public static int MINE = 5;
    public static int DEAD_CELL = 6;
    public static int RESSOURCE = 7;
}
