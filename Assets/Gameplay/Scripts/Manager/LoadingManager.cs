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
        string filePath = Application.streamingAssetsPath + "/DictionaryData" + "/JSONTest.txt";
        List<string> fileLines = File.ReadAllLines(filePath).ToList();

        foreach(string line in fileLines){
            Debug.Log(line);
            string[] spliterArr = line.Split('=');
            dictionary.Add(spliterArr[0],spliterArr[1]);
        }
        CanvasMainMenu.Instance.loadingScreen.gameObject.SetActive(false);
        GameManager.Instance.startGameplayTrigger = true;

    }
}
