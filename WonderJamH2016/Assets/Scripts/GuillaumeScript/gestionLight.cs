using UnityEngine;
using System.Collections;

public class gestionLight : MonoBehaviour {

    public bool updateMaLumiere = false;
    Light maLumiere;
    float leDelaisDuTic;
    float tempsQuiPasse;

    bool AllerFait = false;


	// Use this for initialization
	void Start () {
        maLumiere = GetComponent<Light>();
        leDelaisDuTic = GameManager.instance.delaisEntreChaqueTic / 2;
	
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
}
