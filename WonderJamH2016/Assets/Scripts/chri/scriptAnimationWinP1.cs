using UnityEngine;
using System.Collections;

public class scriptAnimationWinP1 : MonoBehaviour {

    public AudioClip eye;
    public AudioClip gloup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChangerScene()
    {
        Destroy(GameManager.instance.gameObject);
        Application.LoadLevel("canada1");
    }

    public void moveEye()
    {
        GetComponent<AudioSource>().PlayOneShot(eye, 0.8f);
    }

    public void gloupSound()
    {
        GetComponent<AudioSource>().PlayOneShot(gloup, 0.8f);
    }

}
