using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CanvasBookScreen : MonoBehaviour
{

    public BookItem wordPrefab;
    public List<GameObject> scrollView;
    public List<GameObject> contentHolder;
    public string[] typeStr = { "A1", "A2", "B1", "B2", "C1" };

    private void Start()
    {
        //LoadBook();
    }

    public void LoadBook() {
        int i = 0;
        foreach (string type in typeStr) {
            string filePath = Application.streamingAssetsPath + "/DictionaryData" + "/JSON" + type + ".txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();
            foreach (string line in fileLines)
            {
                string[] spliterArr = line.Split('=');
                BookItem item = Instantiate(wordPrefab);
                item.word.text = spliterArr[0] + " : " + spliterArr[1];
                item.transform.parent = contentHolder[i].transform;

            }
            i++;
        }
        foreach (GameObject go in scrollView) {
            go.SetActive(false);
        }
    }

    public void OpenBook(int index) {
        scrollView[index].SetActive(true);
    }

    public void OnOpen() {
        gameObject.SetActive(true);
    }

    public void OnClose() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.clickSound);
        foreach (GameObject go in scrollView)
        {
            go.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
