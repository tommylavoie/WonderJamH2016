using UnityEngine;
using System.Collections;

public class Lumiere : MonoBehaviour {

    public Position startPosition;
    public Position positionCourante;
    public Grid maGrid;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialiserLumiere(int x, int y, Grid laGrid)
    {
        startPosition.x = x;
        startPosition.y = y;

        positionCourante = startPosition;

        maGrid = laGrid;
        

    }

    public void updateTaPosition()
    {
        //Verification si je suis rendu au goal
        if (maGrid.GetShortestConnection(positionCourante).Count > 2)
        {
            positionCourante = maGrid.GetShortestConnection(positionCourante)[2];

            //Ici je dois caller ma fonction qui updater la lumiere dans le monde du jeu
            updaterMaPositionDansLeMondeDuJeu(positionCourante);
        }
        else
        {
            //Mon plus cours chemin est < 2 alors on est rendu a destination
            //Je dois ajouter des point au joueur selon le goal que je suis rendu
        }       
    }

    void updaterMaPositionDansLeMondeDuJeu(Position laPositionCourante)
    {
        transform.position = new Vector2(-7 + (positionCourante.x * 0.4f) , 3 -(positionCourante.y * 0.4f));
    }
}
