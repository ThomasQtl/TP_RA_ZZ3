using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenneRouge : MonoBehaviour
{
    public GameObject ok;
    private GestionPneus gp;

    private void Start()
    {
        gp = ok.transform.GetComponent<GestionPneus>();
    }

    private void OnTriggerEnter(Collider other)
    {

        InitialisationPneu props = other.gameObject.GetComponent<InitialisationPneu>();

        if (props != null)
        {
            if (!props.estCorrect)
            {
                GestionPneus.dict[other.gameObject] = true;
                Debug.Log("Nom " + other.gameObject.name + " Correct : " + props.estCorrect);
            }

            gp.DernierPneu();
        }
        //Debug.Log("mauvaise benne");


    }

    private void OnTriggerExit(Collider other)
    {
        InitialisationPneu props = other.gameObject.GetComponent<InitialisationPneu>();
        if (props != null)
        {
            GestionPneus.dict[other.gameObject] = false;
        }
        //gp.DernierPneu();
        //Debug.Log("mauvaise benne sortie");
    }
}


