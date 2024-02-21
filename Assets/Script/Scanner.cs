using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    public Material conformMaterial;
    public Material errorMaterial;
    public Material waitingMaterial;
    public Material NoScanMaterial;
    public GameObject ecran;
    public GameObject ok;
    public GameObject plate;


    void Start()
    {


    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        InitialisationPneu props = other.gameObject.GetComponent<InitialisationPneu>();
        Plateforme pla = plate.transform.GetComponent<Plateforme>(); ;
        if (props != null)
        {
            if (pla.estSurPlateforme)
            {
                //Debug.Log(props.detectionAutomatique.ToString());
                if (props.estCorrect)
                {
                    ecran.GetComponent<Renderer>().material = conformMaterial;
                    pla.estSurPlateforme = false;
                }
                else
                {
                    ecran.GetComponent<Renderer>().material = errorMaterial;
                    pla.estSurPlateforme = false;
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        ecran.GetComponent<Renderer>().material = waitingMaterial;
    }
}


/*
 * NullReferenceException: Object reference not set to an instance of an object
Scanner.OnTriggerEnter (UnityEngine.Collider other) (at Assets/Script/Scanner.cs:36)
*/