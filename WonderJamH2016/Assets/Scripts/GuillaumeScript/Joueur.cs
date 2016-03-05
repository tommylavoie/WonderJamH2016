using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Joueur : MonoBehaviour {


    public int resource;
    public int score;
    public GameObject resourceUI;
    public GameObject scoreUI;

    RaycastHit2D hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setResource(int nbrDeResource)
    {
        resource = nbrDeResource;
        updaterResourceUI();
    }

    public int getResource()
    {
        return resource;
    }

    public void addResource(int nbrDeResourceGagner)
    {
        resource = resource = nbrDeResourceGagner;
        updaterResourceUI();
    }

    public void depenserResource(int nbrDeResourceDepenser)
    {
        resource = resource - nbrDeResourceDepenser;
        updaterResourceUI();
    }

    public bool PeutIlAcheter(int nbrDeResouceNecessaire)
    {
        if (nbrDeResouceNecessaire <= resource)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int leScore)
    {
        score = leScore;
        updaterScoreUI();
    }

    public void addScore(int leScore)
    {
        score = score + leScore;
        updaterScoreUI();

    }

    public void updaterScoreUI()
    {
        //scoreUI.GetComponent<Text>().text = score.ToString();
    }

    public void updaterResourceUI()
    {
        //resourceUI.GetComponent<Text>().text = resource.ToString();
    }

    //Fonction qui permet de savoir si un objet est deja dans la case
    public string dejaQuelqueChoseALaCase()
    {
        Vector2 pourRayCast = new Vector2 (0.5f,0);

        hit = Physics2D.Raycast(transform.position, pourRayCast);

        if(hit.collider != null)
        {
            return hit.transform.gameObject.tag;
        }
        else
        {
            return ("none");
        }
    }

}
