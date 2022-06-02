using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCharUI : MonoBehaviour
{
    public Transform charHolder;
    public Transform panelPrefab;

    private float panelDistance = 380f;
    private float leftMargin;
    private int charCount;
    public Dictionary<int, TextMeshProUGUI> hiddenCharList = new Dictionary<int, TextMeshProUGUI>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        //playerHealthSlider.LookAt(Camera.main.transform);
        //playerHealthSlider.Rotate(0, 180, 0);
        //chosenCharUI.LookAt(Camera.main.transform);
        //chosenCharUI.Rotate(0, 180, 0);
        //charHolder.LookAt(Camera.main.transform);
        charHolder.LookAt(Camera.main.transform);
        charHolder.eulerAngles = new Vector3(-charHolder.eulerAngles.x, 0, 0);
    }

    public void Init(KeyValuePair<string,string> pair,List<int> weakIndexList) {
        this.charCount = pair.Key.Length;
        GetLeftMargin();
        int i = 0;
        foreach (char c in pair.Key) {
            Transform tempPanel = Instantiate(panelPrefab, charHolder);
            tempPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(leftMargin, 0);
            TextMeshProUGUI charTxt = tempPanel.GetChild(0).GetComponent<TextMeshProUGUI>();
            charTxt.text = c.ToString();
            foreach (int idex in weakIndexList) {
                if (i == idex) {
                    charTxt.text = "";
                    hiddenCharList.Add(i, charTxt);
                }
            }
            leftMargin += panelDistance;
            i++;
        }
    }

    private void GetLeftMargin() {
        if (charCount % 2 == 0)
        {
            leftMargin = -(panelDistance / 2)  - (panelDistance / 2) * (charCount / 2 - 1);
        }
        else {
            leftMargin = -(panelDistance * (charCount - 1) / 2);
        }
    }
}
