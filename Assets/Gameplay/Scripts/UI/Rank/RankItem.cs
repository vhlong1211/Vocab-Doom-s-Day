using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankItem : MonoBehaviour
{

    public Text rankTxt;
    public Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(string rank,string time) {
        rankTxt.text = rank;
        scoreTxt.text = time;
    }
}
