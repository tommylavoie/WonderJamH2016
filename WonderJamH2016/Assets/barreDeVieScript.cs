using UnityEngine;
using System.Collections;

public class barreDeVieScript : MonoBehaviour {

    public int maxVie;
    public int valeurDeMarde;

	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = new Vector3(((2f * valeurDeMarde) * (float)transform.parent.GetComponent<CancerScript>().VieActuelle) / (float)maxVie, valeurDeMarde, transform.localScale.z);
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
