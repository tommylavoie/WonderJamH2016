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
	
	// Update is called once per frame
	void Update () {
	
        if(laPartieEstCommencer == true)
        {
            leTemps = leTemps - Time.deltaTime;

            minutes = Mathf.Floor(leTemps / 60).ToString("0");
            seconds = Mathf.Floor(leTemps % 60).ToString("00");

            leTimer.GetComponent<Text>().text = minutes + " : " + seconds;

            //Debug.Log("Le temps : " + minutes + ":" + seconds);

            delaisEntreChaqueTic = delaisEntreChaqueTic - Time.deltaTime;

            if(delaisEntreChaqueTic <= 0)
            {
                leManagerDeLumiere.GetComponent<LumiereManager>().unTic();
                delaisEntreChaqueTic = backUpDelaisEntreChaqueTic;

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
