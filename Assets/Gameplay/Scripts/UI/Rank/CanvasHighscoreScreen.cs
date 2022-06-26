using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHighscoreScreen : MonoBehaviour
{

    public List<RankItem> rankItemList = new List<RankItem>();
    public List<float> scoreList = new List<float>();
    public Text rankTypeTxt;
    public CanvasPlayoptionScreen playoptionScreen;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRank() {
        for (int i = 0; i < scoreList.Count; i++) {
            if (i > 4) return;
            rankItemList[i].Setup((i+1).ToString(), scoreList[i].ToString("f2"));
        }
    }

    public void GetRankType(string type) {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        if (!DataManager.Instance.playerData.rankData.ContainsKey(type)) {
            ResetUI();
            return;
        }
        scoreList = DataManager.Instance.playerData.rankData[type];
        scoreList.Sort();
        ResetUI();
        UpdateRank();        
    }

    public void OnOpen() {
        gameObject.SetActive(true);
        GetRankType("A1");
    }

    private void ResetUI() {
        for (int i = 0; i < rankItemList.Count; i++)
        {
            rankItemList[i].Setup("","");
        }
    }

    public void OnBack() {
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        playoptionScreen.OnOpen();
    }
}
