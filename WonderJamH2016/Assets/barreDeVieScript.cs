using UnityEngine;
using System.Collections;

public class barreDeVieScript : MonoBehaviour {

    public int maxVie;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = new Vector3((2 * transform.parent.GetComponent<CancerScript>().VieActuelle) / 5, transform.localScale.y, transform.localScale.z);
	}
}
