using UnityEngine;
using System.Collections;

public class CellGrid : MonoBehaviour
{
    GameObject[,] grid;

	// Use this for initialization
	void Start ()
    {
        Init();
	}

    void Init()
    {
        grid = new GameObject[Grid.NUMBER_OF_ROWS, Grid.NUMBER_OF_COLS];
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                grid[i, j] = null;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void SetElement(GameObject g, Position position)
    {  
        grid[position.x, position.y] = g;
    }

    public void RemoveElement(Position position)
    {
        grid[position.x, position.y] = null;
    }

    public GameObject GetElement(Position position)
    {
        return grid[position.x, position.y];
    }
}
