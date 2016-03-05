using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GridGenerator : MonoBehaviour
{
    Grid grid;
    public int Spawners = 0;
    public int Mines = 0;
    public int Minimum_Distance_From_Walls = 0;
    public int Minimum_Distance_From_Others = 0;

	// Use this for initialization
	void Start ()
    {
        grid = GetComponent<Grid>();
        Generate();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    int RNG(int min, int max)
    {
        int rand = Random.Range(min, max);
        return rand;
    }

    bool isDistanceAcceptable(Position first, Position second)
    {
        if (Mathf.Abs(first.x - second.x) <= Minimum_Distance_From_Others 
            && Mathf.Abs(first.y - second.y) <= Minimum_Distance_From_Others)
            return false;
        else
            return true;
    }

    void DoSymmetry()
    {
        int halfCol = Grid.NUMBER_OF_COLS / 2;
        int leftSide = halfCol - 1;
        for (int i = halfCol; i < Grid.NUMBER_OF_COLS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_ROWS; j++)
            {
                grid.SetElement(grid.GetElement(j, leftSide), new Position(j, i));
            }
            leftSide--;
        }
    }

    void setSpawners()
    {
        Position[] spawners = new Position[Spawners + Mines];
        int k = 0;
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                spawners[k] = new Position(i, j);
            }
        }
        grid.setSpawners(spawners);
    }

    void Generate()
    {
        //Parametres de base
        int halfSpawners = Spawners / 2;
        int halfMines = Mines / 2;
        int total = halfSpawners + halfMines;
        int minimumRow = Minimum_Distance_From_Walls;
        int maximumRow = Grid.NUMBER_OF_ROWS - Minimum_Distance_From_Walls;
        int minimumCol = Minimum_Distance_From_Walls;
        int maximumCol = Grid.NUMBER_OF_COLS / 2 - (int)Mathf.Ceil((float)Minimum_Distance_From_Others/(float)2);

        //Generation et validation des emplacements
        int totalTemp = total;
        List<Position> toAdd = new List<Position>();
        while(totalTemp > 0)
        {
            int row = RNG(minimumRow, maximumRow);
            int col = RNG(minimumCol, maximumCol);
            Position generated = new Position(row, col);
            bool acceptable = true;
            foreach (Position addedSpawner in toAdd)
            {
                if (!isDistanceAcceptable(addedSpawner, generated))
                    acceptable = false;
            }
            if(acceptable)
            {
                toAdd.Add(generated);
                totalTemp--;
            }
        }

        //Ajout a la grille
        for(int i=0;i< total;i++)
        {
            Position pos = toAdd[i];
            int type = 4;
            if (i >= halfSpawners)
                type = 5;
            grid.SetElement(type, pos);
        }

        //Reproduis la partie de la grille vers le cote droit
        DoSymmetry();

        //Liste de spawners
        setSpawners();

        grid.print();
    }
}
