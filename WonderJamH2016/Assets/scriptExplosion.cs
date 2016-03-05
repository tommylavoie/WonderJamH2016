using UnityEngine;
using System.Collections;

public class scriptExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cell" || other.gameObject.tag == "Cancer")
            DestroyObject(gameObject);

    }

    public void DestroyObject(Collider2D other)
    {
        gameObject.GetComponent<CancerScript>().DestroyLeBloc();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
