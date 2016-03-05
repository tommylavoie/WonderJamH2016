using UnityEngine;
using System.Collections;

public class Lumiere : MonoBehaviour {

    public Position startPosition;
    public Position positionCourante;
    public Joueur joueur1;
    public Joueur joueur2;
    public Grid maGrid;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialiserLumiere(int x, int y, Grid laGrid, Joueur joueur1, Joueur joueur2)
    {
        startPosition = new Position(x, y);

        positionCourante = startPosition;

        maGrid = laGrid;
        this.joueur1 = joueur1;
        this.joueur2 = joueur2;

    }

    public void updateTaPosition()
    {
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
    }

    void updaterMaPositionDansLeMondeDuJeu(Position laPositionCourante)
    {
        transform.position = new Vector2(-7 + (laPositionCourante.y * 0.4f) , 3 -(laPositionCourante.x * 0.4f));
    }
}
