using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Joueur : MonoBehaviour {

    public GameObject cell;
    public GameObject bomb;
    public GameObject cancer;

    public int resource;
    public int score;
    public GameObject resourceUI;
    public GameObject scoreUI;

    RaycastHit2D hit;

	// Use this for initialization
	void Start () {
        setScore(score);
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

    public void placerCell()
    {
        Debug.Log("1");
        if(dejaQuelqueChoseALaCase() == "none" && dejaQuelqueChoseALaCase() != "Cell")
        {
            Debug.Log("2");
            if (PeutIlAcheter(1))
            {
                Debug.Log("3");
                Instantiate(cell, transform.position, Quaternion.identity);
                depenserResource(1);
            }
            
        }
        
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
        Vector2 pourRayCast = new Vector2 (0.0000001f,0);

        hit = Physics2D.Raycast(transform.position, Vector2.zero);

        Debug.Log(hit.collider);

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
