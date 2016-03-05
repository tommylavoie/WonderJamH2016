using UnityEngine;
using System.Collections;

public class LumiereManager : MonoBehaviour {

   int grosseurTableau;
   public Lumiere[] poolDesLumiere;
   public GameObject[] poolDesLumiereGameObject;
   int compteur = 0;
   public Grid laGrid;

    public Joueur joueur1;
    public Joueur joueur2;

   public GameObject laLumiere;

	// Use this for initialization
	void Start ()
    {
        initialiserMonTableau(laGrid.getSpawners());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialiserMonTableau(Position[] leTableau)
    {
        grosseurTableau = leTableau.Length * 4;
        poolDesLumiereGameObject = new GameObject[grosseurTableau];

        compteur = 0;

        for (int i = 0; i < leTableau.Length; i++)
        {

            poolDesLumiereGameObject[compteur] =  (GameObject) Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x - 1, leTableau[i].y, laGrid, joueur1, joueur2);

            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x, leTableau[i].y + 1, laGrid, joueur1, joueur2);

            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x + 1, leTableau[i].y, laGrid, joueur1, joueur2);

            compteur++;

            poolDesLumiereGameObject[compteur] = (GameObject)Instantiate(laLumiere, Vector2.zero, Quaternion.identity);
            poolDesLumiereGameObject[compteur].GetComponent<Lumiere>().initialiserLumiere(leTableau[i].x, leTableau[i].y - 1, laGrid, joueur1, joueur2);

            compteur++;


        }
    }

    public void unTic()
    {
        for(int i = 0; i < poolDesLumiereGameObject.Length; i++)
        {
            poolDesLumiereGameObject[i].GetComponent<Lumiere>().updateTaPosition();
        }
    }



}
