using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCollectablesStats : MonoBehaviour
{
    // Start is called before the first frame update+

    private TextMeshProUGUI _img1, _img3;
    void Start()
    {
        
        _img1 = GameObject.Find("nombreImage1").GetComponent<TextMeshProUGUI>();
        _img1.text = GameManager.Instance.PlayerData.Collectable1.ToString();

        _img3 = GameObject.Find("nombreImage3").GetComponent<TextMeshProUGUI>();
        _img3.text = GameManager.Instance.PlayerData.Collectable3.ToString();
    }

 
}
