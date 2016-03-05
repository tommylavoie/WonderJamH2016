using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour
{
    Grid grid;
    CellGrid cellGrid;
    public Sprite defaultSprite;
    public Sprite firstPlayerSprite;
    public Sprite secondPlayerSprite;

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

    void ChangeSprite(GameObject gameObject, Sprite sprite)
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }

    void ResetPaths()
    {
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                if(cellGrid.GetElement(new Position(i, j)) != null)
                {
                    ChangeSprite(cellGrid.GetElement(new Position(i, j)), defaultSprite);
                }
            }
        }
    }

    void ChangePathPlayer(int player, List<Position> path)
    {
        foreach(Position node in path)
        {
            if (cellGrid.GetElement(new Position(node.x, node.y)) != null)
            {
                Sprite sprite = firstPlayerSprite;
                if (player == 1)
                    sprite = secondPlayerSprite;
                ChangeSprite(cellGrid.GetElement(new Position(node.x, node.y)), sprite);
            }
        }
    }

    void UpdatePath(Position start)
    {
        if(grid.GetElement(start.x,start.y) == Grid.CELL)
        {
            List<Position> shortestPath = grid.GetShortestConnection(start);
            if(shortestPath != null && shortestPath.Count > 0)
            {
                GoalInfo goal = grid.GetAssociatedGoal(shortestPath[shortestPath.Count - 1]);
                ChangePathPlayer(goal.GetPlayerNumber(), shortestPath);
            }
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
            UpdateSpawner(s);
        }
    }
}
