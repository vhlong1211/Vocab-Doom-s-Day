using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGoldBar : MonoBehaviour
{
    public Text goldTxt; 
    // Update is called once per frame
    void Update()
    {
        goldTxt.text = PlayerManager.Instance.goldCollected.ToString();
    }
}
