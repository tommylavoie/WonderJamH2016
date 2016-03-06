using UnityEngine;
using System.Collections;

public class scriptAnimationDebut : MonoBehaviour {

    public AudioClip discover;
    public AudioClip eye;
    public AudioClip fadeToGame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FinAnimation()
    {
        Application.LoadLevel("Tuto");
    }

    public void discoverFatMan()
    {
        GetComponent<AudioSource>().PlayOneShot(discover, 0.4f);
    }

    public void moveEye()
    {
        GetComponent<AudioSource>().PlayOneShot(eye, 0.8f);
    }

    public void fadeToGameSound()
    {
        GetComponent<AudioSource>().PlayOneShot(fadeToGame, 1f);
    }


}
