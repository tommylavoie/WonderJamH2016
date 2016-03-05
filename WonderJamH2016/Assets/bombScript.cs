using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {

    public TextMesh text1;
    public TextMesh text2;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartExplosion());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(1);
        text1.text = "2";
        text2.text = "2";
        yield return new WaitForSeconds(1);
        text1.text = "1";
        text2.text = "1";
        yield return new WaitForSeconds(1);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
