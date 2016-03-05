using UnityEngine;
using System.Collections;

public class scriptTextUp : MonoBehaviour {

    string myText;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }
}
