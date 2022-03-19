using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuButtonAction : MonoBehaviour
{
    /// <summary>
    /// Permet d'afficher un panel transmis en paramètre
    /// </summary>
    /// <param name="PanelAOuvrir">Panel à afficher</param>
    public void AfficherPanel(GameObject PanelAOuvrir)
    {
        PanelAOuvrir.SetActive(true);
    }

    public void ActiverBoutonNiveau(PlayerData data)
    {
        Button button = null;
        if (data.LevelTermine == 2)
        {
            button = GameObject.Find("ButtonNiv2").GetComponent<Button>();
        }
        else if (data.LevelTermine == 3)
        {
            button = GameObject.Find("ButtonNiv3").GetComponent<Button>();
        }

        if (button != null)
            button.interactable = true;
    }

    /// <summary>
    /// Permet de ferme aussi le panel actuel
    /// </summary>
    /// <param name="PanelAFermer">Panel à fermer</param>
    public void FermerPanel(GameObject PanelAFermer)
    {
        PanelAFermer.SetActive(false);
    }

    /// <summary>
    /// Permet de charger un niveau
    /// </summary>
    /// <param name="nom">Nom du niveau à charger</param>
    public void ChargerNiveau(string nom)
    {
        SceneManager.LoadScene(nom);
    }

    /// <summary>
    /// Permet de fermer l'application
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }
}
