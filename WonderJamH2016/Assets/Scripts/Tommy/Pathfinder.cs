using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour
{
    public Grid grid;
    public Texture defaultTexture;
    public Texture firstPlayerTexture;
    public Texture secondPlayerTexture;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void ResetPaths()
    {

    }

    void ChangePathPlayer(int player, List<Position> path)
    {

    }

    void UpdatePath(Position start)
    {
        if(grid.GetElement(start.x,start.y) == Grid.CELL)
        {
            List<Position> shortestPath = grid.GetShortestConnection(start);
            if(shortestPath != null)
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
