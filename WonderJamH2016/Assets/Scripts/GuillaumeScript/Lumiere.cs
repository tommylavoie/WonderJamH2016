using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lumiere : MonoBehaviour {

    public Position startPosition;
    public Position positionCourante;
    public Joueur joueur1;
    public Joueur joueur2;
    public Grid maGrid;

    List<Position> votreCheminASuivreSilVousPlait;

	// Use this for initialization
	void Start ()
    {
        votreCheminASuivreSilVousPlait = new List<Position>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	}

    public void initialiserLumiere(int x, int y, Grid laGrid, Joueur joueur1, Joueur joueur2)
    {
        startPosition = new Position(x, y);

        positionCourante = startPosition;
        updaterMaPositionDansLeMondeDuJeu(positionCourante);

        maGrid = laGrid;
        this.joueur1 = joueur1;
        this.joueur2 = joueur2;

    }

    bool yATilQuelqueChoseAutourDeMoiMonsieur()
    {
        if (maGrid.getGrid()[positionCourante.x, positionCourante.y] == 1)
        {
            if (positionCourante.x != 0 && maGrid.getGrid()[positionCourante.x - 1, positionCourante.y] == 1)
                return true;
            if (positionCourante.x != Grid.NUMBER_OF_ROWS - 1 && maGrid.getGrid()[positionCourante.x + 1, positionCourante.y] == 1)
                return true;
            if (positionCourante.y != 0 && maGrid.getGrid()[positionCourante.x, positionCourante.y - 1] == 1)
                return true;
            if (positionCourante.y != Grid.NUMBER_OF_COLS - 1 && maGrid.getGrid()[positionCourante.x, positionCourante.y + 1] == 1)
                return true;
        }
        return false;
    }

    public void updateTaPosition()
    {
        if(votreCheminASuivreSilVousPlait.Count != 0)
        {
            if(maGrid.GetAssociatedGoal(votreCheminASuivreSilVousPlait[0]) == null)
            {
                if(votreCheminASuivreSilVousPlait.Count >= 2)
                {
                    if(maGrid.GetElement(votreCheminASuivreSilVousPlait[1].x,votreCheminASuivreSilVousPlait[1].y) == Grid.CELL)
                    {
                        positionCourante = new Position(votreCheminASuivreSilVousPlait[1].x, votreCheminASuivreSilVousPlait[1].y);
                        updaterMaPositionDansLeMondeDuJeu(positionCourante);
                        votreCheminASuivreSilVousPlait.RemoveAt(0);
                    }
                    else if(yATilQuelqueChoseAutourDeMoiMonsieur())
                    {
                        votreCheminASuivreSilVousPlait = maGrid.GetShortestConnection(positionCourante);
                    }
                }
            }
            else
            {
                GoalInfo goal = maGrid.GetAssociatedGoal(positionCourante);
                int player = goal.GetPlayerNumber();
                if (player == 0)
                    joueur1.addScore(1, goal);
                else
                    joueur2.addScore(1, goal);
                positionCourante = startPosition;
                updaterMaPositionDansLeMondeDuJeu(positionCourante);
                votreCheminASuivreSilVousPlait = maGrid.GetShortestConnection(positionCourante);
            }
        }
        else
        {
            if (yATilQuelqueChoseAutourDeMoiMonsieur())
            {
                votreCheminASuivreSilVousPlait = maGrid.GetShortestConnection(positionCourante);
            }
        }
    }

    public void updaterMaPositionDansLeMondeDuJeu(Position laPositionCourante)
    {
        transform.position = new Vector2(-7 + (laPositionCourante.y * 0.4f) , 3 -(laPositionCourante.x * 0.4f));
    }
}
