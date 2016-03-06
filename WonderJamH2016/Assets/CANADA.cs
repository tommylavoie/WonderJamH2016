using UnityEngine;
using System.Collections;

public class CANADA : MonoBehaviour {

    public AudioClip canada;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playCanada()
    {
        transform.position = new Vector3(transform.position.x, -10f, -10f);
        GetComponent<AudioSource>().PlayOneShot(canada, 1f);
        StartCoroutine(Wait(5));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("StartScreen");
    }

}
