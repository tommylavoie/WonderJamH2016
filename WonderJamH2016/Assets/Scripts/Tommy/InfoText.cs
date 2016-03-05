using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfoText : MonoBehaviour
{
    public float Speed = 1;

    Queue<string> infoQueue;
    string actual = "";
    bool showing = false;

	// Use this for initialization
	void Start ()
    {
        infoQueue = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!showing && infoQueue.Count > 0)
            StartShow();
        if(showing)
            ExecuteShow();
	}

    void StartShow()
    {
        actual = infoQueue.Dequeue();
        showing = true;
    }

    void ExecuteShow()
    {

    }

    void EndShow()
    {

    }
}
