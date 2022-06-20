using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class LoadingManager : MonoBehaviour
{   
    private static LoadingManager instance;

    public static LoadingManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LoadingManager>();
            }

            return instance;
        }
    }

    public Dictionary<string,string> dictionary = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDictionary(){
        dictionary.Clear();
        string filePath = Application.streamingAssetsPath + "/DictionaryData" + "/JSONC1.txt";
        List<string> fileLines = File.ReadAllLines(filePath).ToList();
        
        foreach(string line in fileLines){
            string[] spliterArr = line.Split('=');
            dictionary.Add(spliterArr[0],spliterArr[1]);
        }
        StartCoroutine(ie_LoadSlowly(fileLines.Count));
    }

    private IEnumerator ie_LoadSlowly(int lineCount) {
        while (CanvasLoadingScreen.Instance.loadingSlider.value > 0 || dictionary.Count < lineCount) {
            CanvasLoadingScreen.Instance.UpgradeValue();
            yield return new WaitForSeconds(0.1f);
        }
        CanvasLoadingScreen.Instance.OnClose();
        GameManager.Instance.startGameplayTrigger = true;
    }
}
