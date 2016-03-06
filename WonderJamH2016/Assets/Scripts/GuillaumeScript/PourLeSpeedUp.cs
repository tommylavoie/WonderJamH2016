using UnityEngine;
using System.Collections;

public class PourLeSpeedUp : MonoBehaviour {

    public AudioClip hurryUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sonHurryUp()
    {
        GetComponent<AudioSource>().PlayOneShot(hurryUp, 0.8f);

    }
}
