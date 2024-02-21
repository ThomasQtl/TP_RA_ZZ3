using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPneus : MonoBehaviour
{/*
    [SerializeField]
    public Material conformMaterial;
    public Material errorMaterial;
    public Material waitingMaterial;
    public Material NoScanMaterial;
    public GameObject ecran;

    private bool estSurPlateforme = false;

    void Start()
    {
        ecran.GetComponent<Renderer>().material = waitingMaterial;

    }

    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on triggerenter");
        if (other.CompareTag("PlateformeDetection"))
        {
            GestionPneus props = other.transform.parent.GetComponent<GestionPneus>();
            Debug.Log("plateforme");
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

        if (other.CompareTag("PlateformeDetection"))
        {
            ecran.GetComponent<Renderer>().material = waitingMaterial;
        }
    }*/
}


