using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class ShortestPathThread
{
    DijkstraListener listener;
    Grid grid;
    GoalInfo[] goals;
    Position start;

    Thread t;
    bool isDone = false;

    List<Position> result;

    public ShortestPathThread(DijkstraListener listener, Grid grid, GoalInfo[] goals, Position start)
    {
        this.listener = listener;
        this.grid = grid;
        this.goals = goals;
        this.start = start;
        t = new Thread(new ThreadStart(Run));
    }

    public void Start()
    {
        t.Start();
    }

    List<Position> CreatePath(Position[,] paths, Position goal)
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

    void Run()
    {

        DijkstraCalculator dc = new DijkstraCalculator();
        int[,] results = dc.GetShortestPath(grid, start);
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
        SetResult(path);
        isDone = true;
    }

    public bool IsDone()
    {
        return isDone;
    }

    void SetResult(List<Position> path)
    {
        result = path;
    }

    public List<Position> GetResult()
    {
        return result;
    }

    public void NotifyListener()
    {
        listener.OnShortestPathFound(GetResult());
    }
}
