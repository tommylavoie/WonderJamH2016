using UnityEngine;
using System.Collections;

public class ButtonInterface : MonoBehaviour {

    public GameObject joueur;

    public GameObject X_ON;
    public GameObject X_OFF;
    public GameObject Y_ON;
    public GameObject Y_OFF;
    public GameObject B_ON;
    public GameObject B_OFF;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(joueur.GetComponent<Joueur>().resource < joueur.GetComponent<Joueur>().coutCell)
        {
            X_ON.SetActive(false);
            X_OFF.SetActive(true);
        }
        else
        {
            X_ON.SetActive(true);
            X_OFF.SetActive(false);
        }


        if (joueur.GetComponent<Joueur>().resource < joueur.GetComponent<Joueur>().coutCancer)
        {
            Y_ON.SetActive(false);
            Y_OFF.SetActive(true);
        }
        else
        {
            Y_ON.SetActive(true);
            Y_OFF.SetActive(false);
        }

        if (joueur.GetComponent<Joueur>().resource < joueur.GetComponent<Joueur>().coutBomb)
        {
            B_ON.SetActive(false);
            B_OFF.SetActive(true);
        }
        else
        {
            B_ON.SetActive(true);
            B_OFF.SetActive(false);
        }
    }
}
