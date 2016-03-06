using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {

    public TextMesh text1;
    public TextMesh text2;
    public GameObject explosion;
    public AudioClip tune;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartExplosion());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StartExplosion()
    {
        GetComponent<AudioSource>().PlayOneShot(tune, 0.4f);
        yield return new WaitForSeconds(1);
        text1.text = "2";
        text2.text = "2";
        GetComponent<AudioSource>().PlayOneShot(tune, 0.4f);
        yield return new WaitForSeconds(1);
        text1.text = "1";
        text2.text = "1";
        GetComponent<AudioSource>().PlayOneShot(tune, 0.4f);
        yield return new WaitForSeconds(1);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
