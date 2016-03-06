using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    public Image timerPanel;
    public float Speed = 1;

    Queue<string> infoQueue;
    string actual = "";
    bool showing = false;

    Text text;

	// Use this for initialization
	void Start ()
    {
        infoQueue = new Queue<string>();
        text = GetComponent<Text>();
        transform.position = new Vector2(0, Screen.height - timerPanel.GetComponent<RectTransform>().sizeDelta.y - 5);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(!showing && infoQueue.Count > 0)
            StartShow();
        if(showing)
            ExecuteShow();
	}
	
	public void AddNews(string t)
	{
		infoQueue.Enqueue(t);
	}

    void StartShow()
    {
        actual = infoQueue.Dequeue();
        showing = true;
        text.text = actual;
        transform.position = new Vector2(Screen.width + actual.Length , transform.position.y);
    }

    void ExecuteShow()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Speed * Time.deltaTime);
        if (transform.position.x <= 0.1f)
            EndShow();
    }

    void EndShow()
    {
        actual = "";
        text.text = actual;
        showing = false;
    }
}
