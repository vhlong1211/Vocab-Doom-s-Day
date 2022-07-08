using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCharUI : MonoBehaviour
{
    public Transform charHolder;
    public Transform panelPrefab;
    public TextMesh floatingTextEng;
    public TextMesh floatingTextViet;

    private float panelDistance = 380f;
    private float leftMargin;
    private int charCount;
    [SerializeField]public Dictionary<int, TextMeshProUGUI> hiddenCharList = new Dictionary<int, TextMeshProUGUI>();

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
        charHolder.LookAt(Camera.main.transform);
        Vector3 faceDirection = new Vector3(-charHolder.eulerAngles.x, 0, 0);

        charHolder.eulerAngles = faceDirection;
        if (floatingTextEng == null || floatingTextViet == null) return;
        floatingTextEng.transform.eulerAngles = faceDirection;
        floatingTextViet.transform.eulerAngles = faceDirection;
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
