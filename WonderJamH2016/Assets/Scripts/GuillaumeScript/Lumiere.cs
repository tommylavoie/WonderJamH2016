﻿using UnityEngine;
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
	void Update () {
	
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

    /*public void updateTaPosition()
    {
        Debug.Log("Je suis dans mon update");
        //Verification si je suis rendu au goal
        if (maGrid.GetShortestConnection(positionCourante).Count > 1)
        {
            positionCourante = maGrid.GetShortestConnection(positionCourante)[1];
        }
        else if(maGrid.GetShortestConnection(positionCourante).Count == 1)
        {
            GoalInfo goal = maGrid.GetAssociatedGoal(positionCourante);
            int player = goal.GetPlayerNumber();
            if (player == 0)
                joueur1.addScore(1);
            else
                joueur2.addScore(1);
            positionCourante = startPosition;
        }
        //Ici je dois caller ma fonction qui updater la lumiere dans le monde du jeu
        updaterMaPositionDansLeMondeDuJeu(positionCourante);
    }*/

    bool yATilQuelqueChoseAutourDeMoiMonsieur()
    {
        if (positionCourante.x != 0 && maGrid.getGrid()[positionCourante.x - 1, positionCourante.y] == 1)
            return true;
        if (positionCourante.x != Grid.NUMBER_OF_ROWS - 1 && maGrid.getGrid()[positionCourante.x + 1, positionCourante.y] == 1)
            return true;
        if (positionCourante.y != 0 && maGrid.getGrid()[positionCourante.x, positionCourante.y - 1] == 1)
            return true;
        if (positionCourante.y != Grid.NUMBER_OF_COLS - 1 && maGrid.getGrid()[positionCourante.x, positionCourante.y + 1] == 1)
            return true;
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
                    joueur1.addScore(1);
                else
                    joueur2.addScore(1);
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
