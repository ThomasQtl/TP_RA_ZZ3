using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialisationPneu : MonoBehaviour
{
    public bool estCorrect;
    public bool detectionAutomatique;

    public void InitialiserPneu(bool correct, bool automatique)
    {
        estCorrect = correct;
        detectionAutomatique = automatique;
    }


}
