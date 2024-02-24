using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
    [SerializeField]
    public Material conformMaterial;
    public Material errorMaterial;
    public Material waitingMaterial;
    public Material NoScanMaterial;
    public GameObject ecran;
    public GameObject ok;

    public bool estSurPlateforme = false;

    void Start()
    {
        ecran.GetComponent<Renderer>().material = waitingMaterial;

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        InitialisationPneu props = other.gameObject.GetComponent<InitialisationPneu>();
        if (props != null)
        {
            estSurPlateforme = true;
            //Debug.Log("detection automatique " + props.detectionAutomatique);
            if (props.detectionAutomatique)
            {
                if (props.estCorrect)
                {
                    ecran.GetComponent<Renderer>().material = conformMaterial;
                }
                else
                {
                    ecran.GetComponent<Renderer>().material = errorMaterial;
                }
            }
            else
            {
                ecran.GetComponent<Renderer>().material = NoScanMaterial;
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        estSurPlateforme = false;
        ecran.GetComponent<Renderer>().material = waitingMaterial;
    }
}


