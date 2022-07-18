using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankItem : MonoBehaviour
{

    public Text rankTxt;
    public Text scoreTxt;

    public void Setup(string rank,string time) {
        rankTxt.text = rank;
        scoreTxt.text = time;
    }
}
