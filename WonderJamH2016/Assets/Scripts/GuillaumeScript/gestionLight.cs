using UnityEngine;
using System.Collections;

public class gestionLight : MonoBehaviour {

    public bool updateMaLumiere = false;
    //Light maLumiere;
    float leDelaisDuTic;
    float tempsQuiPasse;

    bool AllerFait = false;

    public GameObject maLumiere;

	// Use this for initialization
	void Start () {
        /*maLumiere = GetComponent<Light>();
        leDelaisDuTic = GameManager.instance.delaisEntreChaqueTic / 4;*/


	
	}
	
	// Update is called once per frame
	/*void Update () {

        if (updateMaLumiere == true)
        {
            if (AllerFait == false)
            {
                tempsQuiPasse += Time.deltaTime;
                maLumiere.intensity += (Time.deltaTime * 8 / leDelaisDuTic);
                if (maLumiere.intensity >= 8)
                {
                    AllerFait = true;
                }
            }
            else
            {
                tempsQuiPasse += Time.deltaTime;
                maLumiere.intensity -= (Time.deltaTime * 8 / leDelaisDuTic);

                if (maLumiere.intensity <= 0)
                {
                    AllerFait = false;
                    updateMaLumiere = false;
                }
            }
        }
	}*/

    void Update()
    {
        if (updateMaLumiere == true)
        {
            //maLumiere.GetComponent<Animator>().SetBool("lumiereAuSpawner", false);
        }
    }

    public void animationBouger()
    {
        maLumiere.GetComponent<Animator>().SetBool("lumiereAuSpawner", false);
    }

    public void animationQuandBougePas()
    {
        maLumiere.GetComponent<Animator>().SetBool("lumiereAuSpawner", true);

    }
}
