using UnityEngine;
using System.Collections;

public class CANADA : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait(3));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("StartScreen");
    }

}
