using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public GameObject Joueur;
    public int idJoueur;
    public float commentTasser;

    public string nomHori;
    public string nomVerti;
    public float maxDistanceHori;
    public float maxDistanceVerti;
    public string nomButtonPlaceCell;
    public string nomButtonHammer;
    public string nomButtonCancer;
    public string nomButtonBomb;

    public GameObject sizeGameObject;
    public float timeBetwenMove;

    private SpriteRenderer mySpriteRender;
    private bool CanPress = true;

    bool surdoseOK = false;

    // Use this for initialization
    void Start () {
        mySpriteRender = sizeGameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.laPartieEstCommencer)
        {

            if (Input.GetButtonDown(nomButtonPlaceCell))
            {
                Joueur.GetComponent<Joueur>().placerCell();
            }

            if (Input.GetButtonDown(nomButtonCancer))
            {

                Joueur.GetComponent<Joueur>().placerCancer();
            }

            if (Input.GetButtonDown(nomButtonBomb))
            {
                Debug.Log("test");
                Joueur.GetComponent<Joueur>().placerBomb();
            }

            if (Input.GetButtonDown(nomButtonHammer))
            {
                Joueur.GetComponent<Joueur>().faireHammer();
            }

            if(idJoueur == 2)
            {
                Debug.Log("ici");
                if (Input.GetButtonDown("PlaceCellKB"))
                {
                    Joueur.GetComponent<Joueur>().placerCell();
                }

                if (Input.GetButtonDown("PlaceCancerKB"))
                {

                    Joueur.GetComponent<Joueur>().placerCancer();
                }

                if (Input.GetButtonDown("PlaceBombKB"))
                {
                    Debug.Log("test");
                    Joueur.GetComponent<Joueur>().placerBomb();
                }

                if (Input.GetButtonDown("HammerKB"))
                {
                    Joueur.GetComponent<Joueur>().faireHammer();
                }
            }

            if (CanPress)
            {
                /*if (Input.GetAxis("Horizontal") > 0.3f && Input.GetAxis("Vertical") > 0.3f)
                {
                    Debug.Log("joystic");
                    transform.Translate(new Vector3(0.6f, 0, 0));
                    transform.Translate(new Vector3(0, 0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Horizontal") < -0.3f && Input.GetAxis("Vertical") > 0.3f)
                {
                    transform.Translate(new Vector3(-0.6f, 0, 0));
                    transform.Translate(new Vector3(0, 0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Horizontal") > 0.3f && Input.GetAxis("Vertical") < -0.3f)
                {
                    transform.Translate(new Vector3(0.6f, 0, 0));
                    transform.Translate(new Vector3(0, -0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Horizontal") < -0.3f && Input.GetAxis("Vertical") < -0.3f)
                {
                    transform.Translate(new Vector3(-0.6f, 0, 0));
                    transform.Translate(new Vector3(0, -0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Horizontal") > 0.8f)
                {
                    transform.Translate(new Vector3(0.6f, 0, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Vertical") > 0.8f)
                {
                    transform.Translate(new Vector3(0, 0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Horizontal") < -0.8f)
                {
                    transform.Translate(new Vector3(-0.6f, 0, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }
                else if (Input.GetAxis("Vertical") < -0.8f)
                {
                    transform.Translate(new Vector3(0, -0.6f, 0));
                    StartCoroutine(WaitForInput(timeBetwenMove));
                }*/

                //Dpad

                if (idJoueur == 2)
                {
                    if (Input.GetAxisRaw("HorizontalKB") > 0.3f && Input.GetAxisRaw("VerticalKB") > 0.3f)
                    {
                        if (transform.position.x < maxDistanceHori && transform.position.y < maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol++;
                            transform.Translate(new Vector3(0, commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne--;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }
                    }
                    else if (Input.GetAxisRaw("HorizontalKB") < -0.3f && Input.GetAxisRaw("VerticalKB") > 0.3f)
                    {
                        if (transform.position.x > -maxDistanceHori && transform.position.y < maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(-commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol--;
                            transform.Translate(new Vector3(0, commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne--;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("HorizontalKB") > 0.3f && Input.GetAxisRaw("VerticalKB") < -0.3f)
                    {
                        if (transform.position.x < maxDistanceHori && transform.position.y > -maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol++;
                            transform.Translate(new Vector3(0, -commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne++;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("HorizontalKB") < -0.3f && Input.GetAxisRaw("VerticalKB") < -0.3f)
                    {
                        if (transform.position.x > -maxDistanceHori && transform.position.y > -maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(-commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol--;
                            transform.Translate(new Vector3(0, -commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne++;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("HorizontalKB") > 0.1f)
                    {
                        if (transform.position.x < maxDistanceHori)
                        {
                            transform.Translate(new Vector3(commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol++;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("VerticalKB") > 0.1f)
                    {
                        if (transform.position.y < maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(0, commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne--;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("HorizontalKB") < -0.1f)
                    {
                        if (transform.position.x > -maxDistanceHori)
                        {
                            transform.Translate(new Vector3(-commentTasser, 0, 0));
                            Joueur.GetComponent<Joueur>().indexCol--;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }

                    }
                    else if (Input.GetAxisRaw("VerticalKB") < -0.1f)
                    {
                        if (transform.position.y > -maxDistanceVerti)
                        {
                            transform.Translate(new Vector3(0, -commentTasser, 0));
                            Joueur.GetComponent<Joueur>().indexLigne++;
                            StartCoroutine(WaitForInput(timeBetwenMove));
                        }
                    }
                }

                if (Input.GetAxisRaw(nomHori) > 0.3f && Input.GetAxisRaw(nomVerti) > 0.3f)
                {
                    if (transform.position.x < maxDistanceHori && transform.position.y < maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol++;
                        transform.Translate(new Vector3(0, commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne--;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }
                }
                else if (Input.GetAxisRaw(nomHori) < -0.3f && Input.GetAxisRaw(nomVerti) > 0.3f)
                {
                    if (transform.position.x > -maxDistanceHori && transform.position.y < maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(-commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol--;
                        transform.Translate(new Vector3(0, commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne--;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomHori) > 0.3f && Input.GetAxisRaw(nomVerti) < -0.3f)
                {
                    if (transform.position.x < maxDistanceHori && transform.position.y > -maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol++;
                        transform.Translate(new Vector3(0, -commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne++;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomHori) < -0.3f && Input.GetAxisRaw(nomVerti) < -0.3f)
                {
                    if (transform.position.x > -maxDistanceHori && transform.position.y > -maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(-commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol--;
                        transform.Translate(new Vector3(0, -commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne++;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomHori) > 0.1f)
                {
                    if (transform.position.x < maxDistanceHori)
                    {
                        transform.Translate(new Vector3(commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol++;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomVerti) > 0.1f)
                {
                    if (transform.position.y < maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(0, commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne--;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomHori) < -0.1f)
                {
                    if (transform.position.x > -maxDistanceHori)
                    {
                        transform.Translate(new Vector3(-commentTasser, 0, 0));
                        Joueur.GetComponent<Joueur>().indexCol--;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }

                }
                else if (Input.GetAxisRaw(nomVerti) < -0.1f)
                {
                    if (transform.position.y > -maxDistanceVerti)
                    {
                        transform.Translate(new Vector3(0, -commentTasser, 0));
                        Joueur.GetComponent<Joueur>().indexLigne++;
                        StartCoroutine(WaitForInput(timeBetwenMove));
                    }
                }
            }
        }
    }

    IEnumerator WaitForInput(float waitTime)
    {
        CanPress = false;
        yield return new WaitForSeconds(waitTime);
        CanPress = true;
    }

    int RNG(int min, int max)
    {
        int rand = UnityEngine.Random.Range(min, max);
        return rand;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Eclair")
        {
            
            Joueur.GetComponent<Joueur>().addResource(Joueur.GetComponent<Joueur>().valeurEclair);
            Destroy(other.gameObject);
            other.GetComponent<EclairScript>().RammaserEclair();
            if (RNG(1, 11) == 10)
            {
                int noJoueur = Joueur.GetComponent<Joueur>().NoJoueur;
                GameObject.FindGameObjectWithTag("TVANouvelles").GetComponent<InfoText>()
                        .AddNews("Joueur " + noJoueur + " se sent soudainement électrifié!");
            }
            if (!surdoseOK && Joueur.GetComponent<Joueur>().valeurEclair > 300)
            {
                int noJoueur = Joueur.GetComponent<Joueur>().NoJoueur;
                GameObject.FindGameObjectWithTag("TVANouvelles").GetComponent<InfoText>()
                            .AddNews("Joueur " + noJoueur + " est en overdose d'énergie!");
                surdoseOK = true;
            }
        }
    }

}
