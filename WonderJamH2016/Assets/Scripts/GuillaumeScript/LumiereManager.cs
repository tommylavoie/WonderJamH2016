﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LumiereManager : MonoBehaviour
{

    int grosseurTableau;
    public Lumiere[] poolDesLumiere;
    public GameObject[] poolDesLumiereGameObject;
    int compteur = 0;
    public Grid laGrid;

    public Joueur joueur1;
    public Joueur joueur2;

    public GameObject laLumiere;

    int[,] lightGrid;

	// Use this for initialization
	void Start ()
    {
        lightGrid = new int[Grid.NUMBER_OF_ROWS, Grid.NUMBER_OF_COLS];
        initialiserMonTableau(laGrid.getSpawners());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initialiserMonTableau(Position[] leTableau)
    {
        grosseurTableau = leTableau.Length * 4;
        poolDesLumiereGameObject = new GameObject[grosseurTableau];

        compteur = 0;

        for (int i = 0; i < leTableau.Length; i++)
        {

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x - 1, leTableau[i].y, laGrid, joueur1, joueur2);

            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x, leTableau[i].y + 1, laGrid, joueur1, joueur2);

            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
<<<<<<< HEAD
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x + 1, leTableau[i].y, laGrid);
        
=======
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x + 1, leTableau[i].y, laGrid, joueur1, joueur2);

>>>>>>> 2ecb5e1fc0bafb6aeb7c6fc66b5a0123b568c3cc
            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x, leTableau[i].y - 1, laGrid, joueur1, joueur2);

            compteur++;


        }
    }

    public void unTic()
    {
<<<<<<< HEAD
        Debug.Log("un tic");
        for(int i = 0; i < poolDesLumiereGameObject.Length; i++)
=======
        for (int i = 0; i < poolDesLumiereGameObject.Length; i++)
>>>>>>> fce43e6b2fc332c519b5e5de6cad0f11a74f861d
        {
            Lumiere lumiere = poolDesLumiereGameObject[i].GetComponent<Lumiere>();
            lightGrid[lumiere.positionCourante.x, lumiere.positionCourante.y]--;
            poolDesLumiereGameObject[i].GetComponent<Lumiere>().updateTaPosition();
<<<<<<< HEAD
            poolDesLumiereGameObject[i].GetComponentInChildren<gestionLight>().updateMaLumiere = true;
=======
            lightGrid[lumiere.positionCourante.x, lumiere.positionCourante.y]++;
>>>>>>> fce43e6b2fc332c519b5e5de6cad0f11a74f861d
        }
        testCollisions();
    }

    public List<GameObject> getLumieresAtPosition(Position position)
    {
        List<GameObject> lumieres = new List<GameObject>();
        foreach(GameObject o in poolDesLumiereGameObject)
        {
            Lumiere l = o.GetComponent<Lumiere>();
            if (l.positionCourante.x == position.x && l.positionCourante.y == position.y)
                lumieres.Add(o);
        }
        return lumieres;
    }

    void testCollisions()
    {
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                if (lightGrid[i, j] > 1)
                {
                    List<GameObject> lumieres = getLumieresAtPosition(new Position(i, j));
                    foreach(GameObject o in lumieres)
                    {
                        Lumiere l = o.GetComponent<Lumiere>();
                        l.positionCourante = l.startPosition;

                    }
                }
            }
        }
    }

}