using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
 /*   // Liste qui garde les temps
    public List<float> tempsList = new List<float>();
    public Text chronoText;
    public Transform Keyboard;



    // Affichage du clavier virtuel
    private void ClavierVirtuel()
    {
        Keyboard.Instance.AffichageNom += OnTextSubmitted;
        Keyboard.Instance.PresentKeyboard("Entrez votre nom : ");
    }

    // Affichage du nom  (OnTextSubmitted ???)
    private void OnTextSubmitted(string playerName)
    {
        Keyboard.Instance.AffichageNom -= OnTextSubmitted;

        tempsList.Add(chronoTime);
        tempsList.Sort();

        // Mettre notre chemin
        string filePath = "notrechemin";
        SaveDataToFile(filePath);

        AffichageTemps();
    }

    // Sauvegarde des données
    private void SaveDataToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float temps in tempsList)
            {
                writer.WriteLine(temps.ToString());
            }
        }
    }

    // Affiche les temps classés à revoir pour afficher après sur l'écran
    private void AffichageTemps()
    {
        Debug.Log("Temps classés du plus rapide au moins rapide : ");
        foreach (float temps in tempsList)
        {
            Debug.Log(TempsBien(temps));
        }
    }

    // Formate le temps en minutes:secondes:millisecondes
    private string TempsBien(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }*/
}


/* Chose à faire 
- Faire pour que les 10 pneus tombent comme il faut dans la benne
- Vérifier la détection des pneus sur la plateforme (mettre Debug.Log si besoin)
- Vérifier l'écran de la console lorsque la détection des pneus est bonne
- Faire même code pour la douchette pour scanner le pneu lorsque c'est pas bon
- Ajouter cette partie dans les différentes fonctions où on détecte la collision avec la plateforme :
    public Transform benneRouge; 
    private bool pneuscanne = false; //Pour vérifier que le pneu a été scanné
    private GameObject pneuActuel;

    public void SurPlacementDansBenne(GameObject benne)
    {
        if (pneuscnaee && pneuActuel != null)
        {
            if (benne == benneJaune && pneuActuel.GetComponent<InitialisationPneu>().EstCorrect)
            {
                // Voir ce qu'on met là quand le pneu est correct et est bien placé
            }
            else if (benne == benneRouge && !pneuActuel.GetComponent<InitialisationPneu>().EstCorrect)
            {
                // Voir ce qu'on met là quand le pneu est correct et est bien placé
            }
            else
            {
                // Voir ce qu'on met là quand le pneu n'est pas bien placé
            }

        }
    }
- Tout vérifier avant de commencer la partie 2 pour être sûre que tout fonctionne bien */