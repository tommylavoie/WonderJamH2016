using UnityEngine;
using System.Collections;

public class scriptTextUp : MonoBehaviour {

    string myText;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void setText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }

    public void setTextRouge(string text)
    {
        GetComponent<TextMesh>().text = text;
        GetComponent<TextMesh>().color = Color.red;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
