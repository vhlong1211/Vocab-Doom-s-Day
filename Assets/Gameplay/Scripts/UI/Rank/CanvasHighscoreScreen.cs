using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHighscoreScreen : MonoBehaviour
{

    public List<RankItem> rankItemList = new List<RankItem>();
    public List<float> scoreList = new List<float>();
    public Text rankTypeTxt;
    private List<float> testList = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        testList.Add(13f);
        testList.Add(153f);
        testList.Add(17.6f);
        testList.Add(53f);
        testList.Add(97f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRank() {
        for (int i = 0; i < rankItemList.Count; i++) {
            rankItemList[i].Setup((i+1).ToString(), scoreList[i].ToString());
        }
    }

    public void GetRankType(string type) {
        Debug.Log(type);
        scoreList = testList;
        scoreList.Sort();
        UpdateRank();
        rankTypeTxt.text = type + " Rank";
    }
}
