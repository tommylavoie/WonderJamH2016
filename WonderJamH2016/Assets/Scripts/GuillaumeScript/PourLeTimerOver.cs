using UnityEngine;
using System.Collections;

public class PourLeTimerOver : MonoBehaviour {

    public AudioClip timeOver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sonTimeOver()
    {
        GetComponent<AudioSource>().PlayOneShot(timeOver, 0.8f);
    }

    public void jeVeuxFinirLaCrissDeGame()
    {
        //k bye

        GameManager.instance.finirLaPartie();
    }
}
