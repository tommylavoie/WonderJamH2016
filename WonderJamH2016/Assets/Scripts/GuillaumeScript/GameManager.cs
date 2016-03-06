﻿using UnityEngine;
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

    //Pour le debut d'une partie ****************************//
    public GameObject troisDeuxUnGo;
    //*******************************************************//

    //Pour la fin *******************************************//
    public float tempsDuFinish;
    bool laPartieEstFinit = false;
    bool jaiDejaFaisLeTroisDeuxUnGo = false;
    //*******************************************************//

    public AudioSource audioSource;
    public Pathfinder pathfinder;
    public bool ilYAEuUneExplosionCeTourCiSauveQuiPeut = false;

    bool leTexteDeLaNouvelleDesSoixanteSecondesAMaintenantEteAfficheAuTVANouvelles = false;
    bool leTexteDeLaNouvelleDesTrenteSecondesAMaintenantEteAfficheAuTVANouvelles = false;
    bool leTexteDeLaNouvelleDesQuatreVingtDixSecondesAMaintenantEteAfficheAuTVANouvelles = false;

    bool lesAmisVirguleIlEstLeTempsDeSeDepecherUnPeuVirguleLeTempsPresseVirguleVousNeVoyezPasQuilResteSeulementTrenteSecondesALaPartie = false;

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

        minutes = Mathf.Floor(leTemps / 60).ToString("0");
        seconds = Mathf.Floor(leTemps % 60).ToString("00");

        leTimer.GetComponent<Text>().text = minutes + " : " + seconds;

	}

    void Update()
    {
        if (ilYAEuUneExplosionCeTourCiSauveQuiPeut)
        {
            GameObject.FindGameObjectWithTag("TVANouvelles").GetComponent<InfoText>()
                .AddNews("Des explosions ont eu lieu dans le cortex cérébral!");
            pathfinder.UpdateShortestPaths();
            ilYAEuUneExplosionCeTourCiSauveQuiPeut = false;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (laPartieEstCommencer == true)
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

                bool afficherScore = false;
                if (!leTexteDeLaNouvelleDesQuatreVingtDixSecondesAMaintenantEteAfficheAuTVANouvelles && leTemps < 90)
                {
                    afficherScore = true;
                    leTexteDeLaNouvelleDesQuatreVingtDixSecondesAMaintenantEteAfficheAuTVANouvelles = true;
                }
                if (!leTexteDeLaNouvelleDesSoixanteSecondesAMaintenantEteAfficheAuTVANouvelles && leTemps < 60)
                {
                    afficherScore = true;
                    leTexteDeLaNouvelleDesSoixanteSecondesAMaintenantEteAfficheAuTVANouvelles = true;
                }
                if (!leTexteDeLaNouvelleDesTrenteSecondesAMaintenantEteAfficheAuTVANouvelles && leTemps < 28)
                {
                    afficherScore = true;
                    leTexteDeLaNouvelleDesTrenteSecondesAMaintenantEteAfficheAuTVANouvelles = true;
                }
                if (afficherScore)
                {
                    GameObject joueur = joueur2;
                    if (joueur1.GetComponent<Joueur>().score > joueur2.GetComponent<Joueur>().score)
                        joueur = joueur1;
                    GameObject.FindGameObjectWithTag("TVANouvelles").GetComponent<InfoText>()
                            .AddNews("Joueur " + joueur.GetComponent<Joueur>().NoJoueur + " mène avec " + joueur.GetComponent<Joueur>().score + " points!");
                }

                if (!lesAmisVirguleIlEstLeTempsDeSeDepecherUnPeuVirguleLeTempsPresseVirguleVousNeVoyezPasQuilResteSeulementTrenteSecondesALaPartie && leTemps < 30)
                {
                    SpeedUp();
                }
            }
        }
        else
        {
            if (laPartieEstFinit == true)
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

            else
            {
                if (jaiDejaFaisLeTroisDeuxUnGo == false)
                {
                    //On vient juste d'arriver dans la scene
                    //On instancie le 321
                    Instantiate(troisDeuxUnGo, Vector3.zero, Quaternion.identity);
                    Debug.Log("Je fonctionne");
                    jaiDejaFaisLeTroisDeuxUnGo = true;
                }
            }
        }
	}

    void SpeedUp()
    {
        backUpDelaisEntreChaqueTic = 0.25f;
        InfoText info = GameObject.FindGameObjectWithTag("TVANouvelles").GetComponent<InfoText>();
        info.ClearNews();
        info.AddNews("Plus vite, il ne reste que 30 secondes!");
        audioSource.pitch = 1.25f;
        leManagerDeLumiere.GetComponent<LumiereManager>().SpeedUp();
        lesAmisVirguleIlEstLeTempsDeSeDepecherUnPeuVirguleLeTempsPresseVirguleVousNeVoyezPasQuilResteSeulementTrenteSecondesALaPartie = true;
    }


    public void commencerTimer()
    {
        laPartieEstCommencer = true;
    }


}
