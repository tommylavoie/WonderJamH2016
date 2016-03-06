using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Joueur : MonoBehaviour {

    public GameObject cell;
    public GameObject bomb;
    public GameObject cancer;

    public int resource;
    public int score;
    public GameObject resourceUI;
    public GameObject scoreUI;

    public int coutCell;
    public int coutCancer;
    public int coutBomb;
    public int valeurEclair;

    public Grid grid;
    public CellGrid cellGrid;
    public Pathfinder pathfinder;

    public int indexLigne;
    public int indexCol;

    RaycastHit2D hit;

    public GameObject textUp;
    public scriptTextUp textUpChild;

    public AudioClip collectRessourceSound;
    public AudioClip placerBlockSound;
    public AudioClip frapperCellSound;
    public AudioClip frapperCancerSound;

    public float volumesound;

	// Use this for initialization
	void Start () {
        setScore(score);
        textUpChild = textUp.GetComponentInChildren<scriptTextUp>();
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
        resource = resource + nbrDeResourceGagner;
        updaterResourceUI();
        GameObject myTextUP =  Instantiate(textUp, transform.position, Quaternion.identity) as GameObject;
        myTextUP.GetComponentInChildren<scriptTextUp>().setText("" + nbrDeResourceGagner);
        GetComponent<AudioSource>().PlayOneShot(collectRessourceSound, volumesound);

    }

    public void depenserResource(int nbrDeResourceDepenser)
    {
        resource = resource - nbrDeResourceDepenser;
        updaterResourceUI();
        GameObject myTextUP = Instantiate(textUp, transform.position, Quaternion.identity) as GameObject;
        myTextUP.GetComponentInChildren<scriptTextUp>().setText("-" + nbrDeResourceDepenser);
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

    public void addScore(int leScore, GoalInfo goal)
    {
        score = score + leScore;
        updaterScoreUI();

    }

    public void placerCell()
    {

        if(dejaQuelqueChoseALaCase() == "none")
        {

            if (PeutIlAcheter(coutCell))
            {
                Debug.Log(coutCell);
                GameObject myCancer = Instantiate(cell, transform.position, Quaternion.identity) as GameObject;
                myCancer.GetComponent<CancerScript>().indexCol = indexCol;
                myCancer.GetComponent<CancerScript>().indexLigne = indexLigne;
                myCancer.GetComponent<CancerScript>().grid = grid;
                grid.SetElement(Grid.CELL, new Position(indexLigne, indexCol));
                cellGrid.SetElement(myCancer, new Position(indexLigne, indexCol));
                pathfinder.UpdateShortestPaths();
                depenserResource(coutCell);
                GetComponent<AudioSource>().PlayOneShot(placerBlockSound, volumesound);
                //List<Position> test = grid.GetShortestConnection(new Position(indexLigne, indexCol));
            }
            
        }
        
    }

    public void placerCancer()
    {
        if (dejaQuelqueChoseALaCase() == "none")
        {
            if (PeutIlAcheter(coutCancer))
            {
                GameObject myCancer = Instantiate(cancer, transform.position, Quaternion.identity) as GameObject;
                myCancer.GetComponent<CancerScript>().indexCol = indexCol;
                myCancer.GetComponent<CancerScript>().indexLigne = indexLigne;
                myCancer.GetComponent<CancerScript>().grid = grid;
                grid.SetElement(Grid.DEAD_CELL, new Position(indexLigne, indexCol));
                cellGrid.SetElement(myCancer, new Position(indexLigne, indexCol));
                depenserResource(coutCancer);
            }

        }

    }

    public void placerBomb()
    {
        if (PeutIlAcheter(coutBomb))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            depenserResource(coutBomb);
        }
    }

    public void faireHammer()
    {
        GameObject o = cellGrid.GetElement(new Position(indexLigne, indexCol));

        if((o != null) && (o.tag == "Cell" || o.tag == "Cancer"))
        {
            if(o.tag == "Cell")
            {
                GetComponent<AudioSource>().PlayOneShot(frapperCellSound, volumesound);
            }
            else if(o.tag == "Cancer")
            {
                GetComponent<AudioSource>().PlayOneShot(frapperCancerSound, volumesound);
            }

            if(o.GetComponent<CancerScript>().VieActuelle == 1)
            {
                o.GetComponent<CancerScript>().Hurt();
                addResource(o.GetComponent<CancerScript>().ressourceValue);
            }
            else
            {
                o.GetComponent<CancerScript>().Hurt();
            }
            


        }
    }

    public void updaterScoreUI()
    {
        scoreUI.GetComponent<Text>().text = score.ToString();
    }

    public void updaterResourceUI()
    {
        resourceUI.GetComponent<Text>().text = resource.ToString();
    }

    //Fonction qui permet de savoir si un objet est deja dans la case
    public string dejaQuelqueChoseALaCase()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.zero);

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
