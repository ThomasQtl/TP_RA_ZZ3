using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenneVerte : MonoBehaviour
{

    public GameObject ok;
    private GestionPneus gp;
    void Start()
    {
        gp = ok.transform.GetComponent<GestionPneus>();

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        InitialisationPneu props = other.gameObject.GetComponent<InitialisationPneu>();
        Debug.Log("bonne benne");
        if (props != null)
        {
            if (props.estCorrect)
            {
                GestionPneus.dict[other.gameObject] = true;
                Debug.Log("Nom " + other.gameObject.name + " Correct : " + props.estCorrect);
            }
        }


        gp.DernierPneu();

    }

    private void OnTriggerExit(Collider other)
    {
        GestionPneus.dict[other.gameObject] = false;
        gp.DernierPneu();
        Debug.Log("bonne benne sortie");
    }
}


