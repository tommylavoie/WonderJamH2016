﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    int[,] grid;
    GoalInfo[] goals;

	// Use this for initialization
	void Start ()
    {
        Init();
        testFill();
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
        goals = new GoalInfo[2];
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public int[,] getGrid()
    {
        return grid;
    }

    public GoalInfo[] getGoals()
    {
        return goals;
    }

    List<Position> CreatePath(Position[,] paths, Position goal)
    {
        Stack<Position> path = new Stack<Position>();
        Position actual = goal;
        bool finished = false;
        while(!finished)
        {
            path.Push(actual);
            Position newPosition = paths[actual.x, actual.y];
            if (newPosition.x == actual.x && newPosition.y == actual.y)
                finished = true;
            else
                actual = newPosition;
        }
        List<Position> list = new List<Position>();
        while(path.Count != 0)
        {
            list.Add(path.Pop());
        }
        return list;
    }

    List<Position> GetShortestConnection(Position start)
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
        if(minGoal != null)
            path = CreatePath(dc.paths, minGoal);
        return path;
    }

    void testFill()
    {
        //grid[0, 1] = 1;
        grid[1, 1] = 1;
        grid[1, 2] = 1;
        grid[1, 3] = 1;
        grid[2, 3] = 1;
        grid[2, 1] = 1;
        grid[3, 3] = 1;
        grid[3, 2] = 1;
        grid[3, 1] = 1;
        grid[4, 1] = 1;
        goals[0] = new GoalInfo(new Position(-1, 1));
        goals[1] = new GoalInfo(new Position(NUMBER_OF_ROWS, 1));
        GetShortestConnection(new Position(1, 1));
    }

    public static int NUMBER_OF_ROWS = 15;
    public static int NUMBER_OF_COLS = 15;
    public static int NUMBER_OF_GOALS = 2;

    public static int EMPTY = 0;
    public static int CELL = 1;
    public static int ENTRY = 2;
    public static int MINE = 3;
    public static int DEAD_CELL = 4;
}