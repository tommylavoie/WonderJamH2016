using UnityEngine;
using System;
using System.Collections;

public class RessourceGenerator : MonoBehaviour
{
    public int Probability;
    public float Interval_Seconds;

    Grid grid;
    DateTime startTimer;
    bool exceeded = false;

    // Use this for initialization
    void Start ()
    {
        startTimer = DateTime.Now;
        grid = GetComponent<Grid>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateTimer();
        if(exceeded)
        {
            generate();
            exceeded = false;
        }
	}

    void updateTimer()
    {
        float cur_time = (float)(System.DateTime.Now - startTimer).TotalMilliseconds / 1000;
        if (cur_time > Interval_Seconds)
        {
            exceeded = true;
            startTimer = DateTime.Now;
        }
    }

    int RNG(int min, int max)
    {
        int rand = UnityEngine.Random.Range(min, max);
        return rand;
    }

    Position getEmptyCell()
    {
        int tries = 0;
        while (tries < 10)
        {
            int row = RNG(0, Grid.NUMBER_OF_ROWS);
            int col = RNG(0, Grid.NUMBER_OF_COLS);
            Position generated = new Position(row, col);
            if (grid.GetElement(row, col) == Grid.EMPTY)
                return generated;
            tries++;
        }
        return null;
    }

    void generate()
    {
        int lottery = RNG(0, 100);
        if(lottery < Probability)
        {
            Debug.Log("New Item!");
            Position emptyCell = getEmptyCell();
            if(emptyCell != null)
                grid.SetElement(Grid.RESSOURCE, emptyCell);
        }
    }
}
