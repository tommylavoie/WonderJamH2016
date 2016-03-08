using UnityEngine;
using System.Collections;

public class btnSkip : MonoBehaviour {

    public string allo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Application.LoadLevel(allo);
        }

	}
}
