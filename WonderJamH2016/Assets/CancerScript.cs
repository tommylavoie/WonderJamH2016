﻿using UnityEngine;
using System.Collections;

public class CancerScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public Grid grid;

    public int VieMax;
    public int VieActuelle;
    public int ressourceValue;
    private bool BarDeVieEstVisible = false;

    public GameObject bareDeVie;

    private Coroutine currentCoroutine = null;
    private GameObject MabareDeVie;

    // Use this for initialization
    void Start () {
        VieActuelle = VieMax;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(VieActuelle == VieMax - 1)
        {
            if(BarDeVieEstVisible == false)
            {
                MabareDeVie = Instantiate(bareDeVie, new Vector2(transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x/2, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y), Quaternion.identity) as GameObject;
                MabareDeVie.transform.parent = gameObject.transform;
                MabareDeVie.GetComponent<barreDeVieScript>().maxVie = VieMax;
                BarDeVieEstVisible = true;
            }
        }

        if(VieActuelle < 1)
        {
            DestroyLeBloc();
        }
	}

    public void DestroyLeBloc()
    {
        grid.GetComponent<CellGrid>().RemoveElement(new Position(indexLigne, indexCol));
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        grid.GetComponent<Pathfinder>().UpdateShortestPaths();
        Destroy(gameObject);
    }

    public void Hurt()
    {
        VieActuelle--;

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(WaitForHurt());
    }

    IEnumerator WaitForHurt()
    {
        yield return new WaitForSeconds(5);
        Destroy(MabareDeVie);
        VieActuelle = VieMax;
        BarDeVieEstVisible = false;
    }


}
