using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPlayoptionScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CanvasChooseMap canvasChooseMapScreen;
    
    public void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public void OnMainModeClick() {
        canvasChooseMapScreen.OnOpen();
        gameObject.SetActive(false);
    }

}
