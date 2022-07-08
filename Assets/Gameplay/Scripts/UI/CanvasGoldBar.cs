using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGoldBar : MonoBehaviour
{
    public Text goldTxt; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldTxt.text = PlayerManager.Instance.goldCollected.ToString();
    }
}
