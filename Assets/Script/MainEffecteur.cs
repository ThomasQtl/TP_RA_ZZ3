using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.IO;

public class MainEffecteur: MonoBehaviour
{

    [SerializeField] GameObject pointDepart;
    [SerializeField] GameObject pointArrive;
    [SerializeField] GameObject ligne;

    // Chronomètre
    private float debut = 0f;
    private TMP_Text chronometre;
    private TMP_Text restext;
    private bool isChronoRunning;

    private float temps;

    private bool jeuTermine = false;

    [SerializeField] NonNativeKeyboard Keyboard;
    private string nomPerso;

    private string filePath;
    void Start()
    {
        ligne.SetActive(false);
                filePath = Application.streamingAssetsPath + @"\" + "temps2.txt";
    }

    void Update()
    {
        if(jeuTermine){
            Keyboard.OnTextSubmitted += nomAffichage;
            Keyboard.PresentKeyboard();
            Keyboard.gameObject.SetActive(true);
            Debug.Log("chrono stop");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Collision avec le point de départ
        if (other.CompareTag("depart")){
            ligne.SetActive(true);
            pointArrive.SetActive(true);
        }

        // Collision avec la ligne 
        if(other.CompareTag("ligne")){
            // Gestion du chronomètre
            debut = Time.time;
            if (isChronoRunning)
            {
                InvokeRepeating("MettreAJourChronometre", debut, 1f);
            }
        }
        
        //Collision avec le point d'arrivée
        if(other.CompareTag("arrive")){
            ligne.SetActive(false);
            pointDepart.SetActive(true);
            isChronoRunning = false;
            jeuTermine = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("depart")){
            isChronoRunning = true;
            // Gestion du chronomètre
            debut = Time.time;
            isChronoRunning = true;
        }
        
        if (other.CompareTag("ligne")){
            temps--;
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

    private void nomAffichage(object sender, EventArgs eventArgs)
    {
        nomPerso = Keyboard.InputField.text;
        SaveDataToFile(filePath);
        DetruirePneusExistants();
        using (StreamReader reader = new StreamReader(filePath))
        {
                string line = reader.ReadToEnd();
                restext.text = line;
                Debug.Log(line);
        }
        
        Keyboard.OnTextSubmitted -= nomAffichage;
    }

     private void SaveDataToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine(nomPerso);
            writer.WriteLine(temps.ToString());
        }
    }
}

