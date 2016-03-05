using UnityEngine;
using System.Collections;

public class EclairScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public Grid grid;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RammaserEclair()
    {
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        Destroy(gameObject);
    }
}
