using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pathfinder : MonoBehaviour, DijkstraListener
{
    Grid grid;
    CellGrid cellGrid;
    public RuntimeAnimatorController defaultSprite;
    public RuntimeAnimatorController firstPlayerSprite;
    public RuntimeAnimatorController secondPlayerSprite;

	// Use this for initialization
	void Start ()
    {
        grid = GetComponent<Grid>();
        cellGrid = GetComponent<CellGrid>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    /*void ChangeSprite(GameObject gameObject, RuntimeAnimatorController sprite)
    {
        Debug.Log("CHANGE");
        Animator renderer = gameObject.GetComponent<Animator>();
        renderer.runtimeAnimatorController = sprite;
    }*/

    void ChangeSprite(GameObject gameObject, int state)
    {
        Connexion[] children = gameObject.GetComponentsInChildren<Connexion>();
        foreach (Connexion c in children)
        {
            c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        children[state].gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void ResetPaths()
    {
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                if(cellGrid.GetElement(new Position(i, j)) != null && cellGrid.GetElement(new Position(i, j)).tag == "Cell")
                {
                    ChangeSprite(cellGrid.GetElement(new Position(i, j)), 0);
                }
            }
        }
    }

    void ChangePathPlayer(int player, List<Position> path)
    {
        foreach(Position node in path)
        {
            if (cellGrid.GetElement(new Position(node.x, node.y)) != null && cellGrid.GetElement(node).tag == "Cell")
            {
                if(player == 1)
                    ChangeSprite(cellGrid.GetElement(new Position(node.x, node.y)), 1);
                else
                    ChangeSprite(cellGrid.GetElement(new Position(node.x, node.y)), 2);
            }
        }
    }

    bool yATilQuelqueChoseAutourDeMoiMonsieur(Position positionCourante)
    {
        if (grid.getGrid()[positionCourante.x, positionCourante.y] == 1)
        {
            if (positionCourante.x != 0 && grid.getGrid()[positionCourante.x - 1, positionCourante.y] == 1)
                return true;
            if (positionCourante.x != Grid.NUMBER_OF_ROWS - 1 && grid.getGrid()[positionCourante.x + 1, positionCourante.y] == 1)
                return true;
            if (positionCourante.y != 0 && grid.getGrid()[positionCourante.x, positionCourante.y - 1] == 1)
                return true;
            if (positionCourante.y != Grid.NUMBER_OF_COLS - 1 && grid.getGrid()[positionCourante.x, positionCourante.y + 1] == 1)
                return true;
        }
        return false;
    }

    void UpdatePath(Position start)
    {
        if(yATilQuelqueChoseAutourDeMoiMonsieur(start))
        {
            StartShortestPathFinding(start);
        }
    }

    void UpdateSpawner(Position spawner)
    {
        UpdatePath(new Position(spawner.x - 1, spawner.y));
        UpdatePath(new Position(spawner.x + 1, spawner.y));
        UpdatePath(new Position(spawner.x, spawner.y - 1));
        UpdatePath(new Position(spawner.x, spawner.y + 1));
    }

    public void UpdateShortestPaths()
    {
        ResetPaths();
        Position[] spawners = grid.getSpawners();
        foreach(Position s in spawners)
        {
            Debug.Log("??");
            UpdateSpawner(s);
        }
    }

    void StartShortestPathFinding(Position start)
    {
        grid.StartShortestConnectionFinding(this, start);
    }

    public void OnShortestPathFound(List<Position> path)
    {
        if (path != null && path.Count > 0)
        {
            GoalInfo goal = grid.GetAssociatedGoal(path[path.Count - 1]);
            ChangePathPlayer(goal.GetPlayerNumber(), path);
        }
    }
}
