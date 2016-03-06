using UnityEngine;
using System.Collections;

public class troisDeuxUnScript : MonoBehaviour {

    public AudioClip trois;
    public AudioClip deux;
    public AudioClip un;
    public AudioClip go;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void jaiFini()
    {
        GameManager.instance.commencerTimer();
        Destroy(gameObject);
    }

    public void sonTrois()
    {
        GetComponent<AudioSource>().PlayOneShot(trois, 0.8f);

    }

    public void sonDeux()
    {
        GetComponent<AudioSource>().PlayOneShot(deux, 0.8f);

    }

    public void sonUn()
    {
        GetComponent<AudioSource>().PlayOneShot(un, 0.8f);

    }

    public void sonGo()
    {
        GetComponent<AudioSource>().PlayOneShot(go, 0.8f);

    }


}
