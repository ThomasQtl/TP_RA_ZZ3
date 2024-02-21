using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.IO;

public class GestionPneus : MonoBehaviour
{
    [SerializeField] private GameObject pneuPrefab;
    [SerializeField] private Transform benneJaune;
    [SerializeField] private Transform pos;
    [SerializeField] private int nombrePneus = 10;
    private float debut = 0f;
    [SerializeField] private TMP_Text chronometre;
    [SerializeField] private TMP_Text restext;
    [SerializeField] public bool estCorrect;
    [SerializeField] public bool detectionAutomatique;
    public static Dictionary<GameObject, bool> dict;
    public GameObject Keyboard;
    private bool dejaAppuye = false;
    private bool isChronoRunning;
    float temps;
    private string nomPerso;

    // Liste qui garde les temps
    public List<float> tempsList = new List<float>();

    private string filePath = "C:\\Users\\thquentel\\Documents\\temps.txt";


    void Start()
    {
        dict = new Dictionary<GameObject, bool>();
        EventManager.StartListening("nomAffichage", nomAffichage);
        //GenererPneusEtDemarrerChronometre();
    }

    public void GenererPneusEtDemarrerChronometre()
    {
        if (!dejaAppuye)
        {
            dejaAppuye = true;
            isChronoRunning = true;

            // Gestion du chronomètre
            debut = Time.time;
            if (isChronoRunning)
            {
                InvokeRepeating("MettreAJourChronometre", debut, 1f);
            }

            // Utilisation de la coroutine pour instancier les pneus avec un délai de 2 secondes
            StartCoroutine(InstancierPneusAvecDelai());
        }
    }

    private IEnumerator InstancierPneusAvecDelai()
    {
        for (int i = 0; i < nombrePneus; i++)
        {
            GameObject nouveauPneu = Instantiate(pneuPrefab, pos.position, Quaternion.identity);
            nouveauPneu.name = "pneu " + i;

            // Initialisation des propriétés du pneu de façon aléatoire (50% de chance à chaque fois)
            estCorrect = UnityEngine.Random.Range(0, 2) == 1;
            detectionAutomatique = UnityEngine.Random.Range(0, 2) == 1;
            dict[nouveauPneu] = false;

            // Application des propriétés au pneu
            nouveauPneu.GetComponent<InitialisationPneu>().InitialiserPneu(estCorrect, detectionAutomatique);

            nouveauPneu.tag = "Pneu";

            yield return new WaitForSeconds(1f); // Délai de 2 secondes entre chaque instantiation
        }
    }

    private void MettreAJourChronometre()
    {
        if (isChronoRunning)
        {
            temps = Time.time - debut;
            chronometre.text = "Chronomètre : " + temps.ToString("F2") + " s"; // Affichage avec deux décimales
        }
    }

    public void DetruirePneusExistants()
    {
        GameObject[] pneus = GameObject.FindGameObjectsWithTag("Pneu");

        foreach (GameObject pneu in pneus)
        {
            Destroy(pneu);
        }
        dejaAppuye = false;
        temps = 0;
    }

    //Lorsque tous les pneus sont placés
    public void DernierPneu()
    {
        Debug.Log("dernier pneu");
        bool res = true;
        foreach ((GameObject G, bool B) in dict)
        {
            if (!B)
            {
                res = false ;
                break;
            }
            Debug.Log("Nom autre script " + G.name + " Correct : " + B);
        }
        Debug.Log(res);
        if (res)
        {
            isChronoRunning = false;


            tempsList.Add(temps);
           
            Keyboard.SetActive(true);
            Debug.Log("chrono stop");
           

        }
    }

    // Sauvegarde des données
    private void SaveDataToFile(string filePath)
    {
        //NonNativeKeyboard script = Keyboard.GetComponentInParent<NonNativeKeyboard>();

        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            tempsList.Sort();
            foreach (float temps in tempsList)
            {

                writer.WriteLine(nomPerso);
                writer.WriteLine(temps.ToString());
            }
        }
    }



    // Formate le temps en minutes:secondes:millisecondes
    private string TempsBien(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(temps);
        return string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }

    private void nomAffichage(EventParam e)
    {
        EventParamString eventParamString = (EventParamString)e;
        nomPerso = eventParamString.NomPerso;
        SaveDataToFile(filePath);
        using (StreamReader reader = new StreamReader(filePath))
        {
  
                string line = reader.ReadToEnd();
                restext.text = line;
                Debug.Log(line);

            

        }

    }
}
