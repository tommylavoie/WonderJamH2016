using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    
    //Pour les joueurs ***************************************//
    public int resourceDeDepart;
    public GameObject joueur1;
    public GameObject joueur2;
    //*******************************************************//

    //Pour le timer *****************************************//
    public GameObject leTimer;
    public int tempsArretDebut;
    public float leTemps;
    public bool laPartieEstCommencer = false;
    string minutes;
    string seconds;
    //*******************************************************//

    //Pour le Tic ******************************************//
    public GameObject leManagerDeLumiere;
    public float delaisEntreChaqueTic;
    public float backUpDelaisEntreChaqueTic;
    //*******************************************************//

    //Pour la fin *******************************************//
    public float tempsDuFinish;
    //*******************************************************//

    public Pathfinder pathfinder;
    public bool ilYAEuUneExplosionCeTourCiSauveQuiPeut = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {

        //Mettre le nombre de ressource que les joueurs commence
        joueur1.GetComponent<Joueur>().setResource(resourceDeDepart);
        joueur2.GetComponent<Joueur>().setResource(resourceDeDepart);

        backUpDelaisEntreChaqueTic = delaisEntreChaqueTic;

        commencerTimer();
	}

    void Update()
    {
        if (ilYAEuUneExplosionCeTourCiSauveQuiPeut)
        {
            pathfinder.UpdateShortestPaths();
            ilYAEuUneExplosionCeTourCiSauveQuiPeut = false;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if(laPartieEstCommencer == true)
        {
            leTemps = leTemps - Time.deltaTime;

            if (leTemps > 0)
            {
                minutes = Mathf.Floor(leTemps / 60).ToString("0");
                seconds = Mathf.Floor(leTemps % 60).ToString("00");

                leTimer.GetComponent<Text>().text = minutes + " : " + seconds;

                //Debug.Log("Le temps : " + minutes + ":" + seconds);

                delaisEntreChaqueTic = delaisEntreChaqueTic - Time.deltaTime;

                if (delaisEntreChaqueTic <= 0)
                {
                    leManagerDeLumiere.GetComponent<LumiereManager>().unTic();
                    delaisEntreChaqueTic = backUpDelaisEntreChaqueTic;
                }
            }
            else
            {
                //On doit arrete le jeu (enlever les controls des joueurs
                leTimer.GetComponent<Text>().text = "0 : 00";
                
                //Je fais spawner le "finished"

                //On attend 2 ou 3 seconde

                if (tempsDuFinish <= 0)
                {
                    if (joueur1.GetComponent<Joueur>().score > joueur2.GetComponent<Joueur>().score)
                    {
                        //On call la scene win de player 1
                        UnityEngine.Application.LoadLevel("WinPlayer1");
                    }
                    else
                    {
                        //On call la scene win de player 2
                        UnityEngine.Application.LoadLevel("WinPlayer2");
                    }
                }
                else
                {
                   tempsDuFinish = tempsDuFinish - Time.deltaTime;
                }

            }


        }

	}

    public void faireLeStart()
    {

    }

    public void commencerTimer()
    {
        laPartieEstCommencer = true;
    }

}
