using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public GameObject Joueur;
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

	// Use this for initialization
	void Start () {
        mySpriteRender = sizeGameObject.GetComponent<SpriteRenderer>();
        Debug.Log(mySpriteRender.bounds.size);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(nomButtonPlaceCell))
        {
            Joueur.GetComponent<Joueur>().placerCell();
        }

        if (Input.GetButtonDown(nomButtonCancer))
        {
            Debug.Log("test");
            Joueur.GetComponent<Joueur>().placerCancer();
        }

        if(Input.GetButtonDown(nomButtonHammer))
        {
            Joueur.GetComponent<Joueur>().faireHammer();
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

            if (Input.GetAxisRaw(nomHori) > 0.3f && Input.GetAxisRaw(nomVerti) > 0.3f)
            {
                if(transform.position.x < maxDistanceHori && transform.position.y < maxDistanceVerti)
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

    IEnumerator WaitForInput(float waitTime)
    {
        CanPress = false;
        yield return new WaitForSeconds(waitTime);
        CanPress = true;
    }
}
