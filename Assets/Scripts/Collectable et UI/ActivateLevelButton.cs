using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActivateLevelButton : MonoBehaviour
{
    // Start is called before the first frame update
        Button _button = null;
    void Start()
    {
        int nbLvl = GameManager.Instance.PlayerData.LevelTermine;
        if (nbLvl >= 2)
        {
            _button = GameObject.Find("ButtonNiv2").GetComponent<Button>();
            _button.interactable = true;
        }

        if (nbLvl >= 3)
        {
            _button = GameObject.Find("ButtonNiv3").GetComponent<Button>();
            _button.interactable = true;
        }
    }
}
