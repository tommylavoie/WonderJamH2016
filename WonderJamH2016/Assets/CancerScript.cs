using UnityEngine;
using System.Collections;

public class CancerScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public Grid grid;

    public int VieMax;
    public int VieActuelle;
    private bool BarDeVieEstVisible;

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
                MabareDeVie = Instantiate(bareDeVie, transform.position, Quaternion.identity) as GameObject;
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
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
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
