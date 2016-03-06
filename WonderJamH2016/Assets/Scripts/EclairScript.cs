using UnityEngine;
using System.Collections;

public class EclairScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public float tempsQuiVie;
    public Grid grid;

    // Use this for initialization
    void Start () {
        StartCoroutine(DetruireEclair(tempsQuiVie));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RammaserEclair()
    {
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        Destroy(gameObject);
    }

    IEnumerator DetruireEclair(float waitime)
    {
        yield return new WaitForSeconds(waitime);
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        Destroy(gameObject);
    }
}
