using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class pourLeTuto : MonoBehaviour {

    public string nomScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GotIT()
    {
        SceneManager.LoadScene(nomScene);
    }


}
