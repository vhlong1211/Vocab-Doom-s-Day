using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventoryScreen : MonoBehaviour
{
    public Text goldTxt;
    public CanvasPlayoptionScreen canvasPlayoptionScreen;
    //public List<GameObject> atkUpgradeColumn;
    //public List<GameObject> healthUpgradeColumn;
    //public List<GameObject> speedUpgradeColumn;
    //public List<GameObject> cooldownUpgradeColumn;

    //public Text atkCostTxt;
    //public Text healthCostTxt;
    //public Text speedCostTxt;
    //public Text cooldownCostTxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldTxt.text = DataManager.Instance.playerData.gold.ToString();
    }

    public void OnOpen() {
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnBack() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        canvasPlayoptionScreen.OnOpen();
        OnClose();
    }
}

public enum UpgradeType { 
    Attack,
    Health,
    Speed,
    Cooldown
}
