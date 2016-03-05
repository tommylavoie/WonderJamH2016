using UnityEngine;
using System.Collections;

public class CancerScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public Grid grid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyLeBloc()
    {
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        Destroy(gameObject);
    }
}
