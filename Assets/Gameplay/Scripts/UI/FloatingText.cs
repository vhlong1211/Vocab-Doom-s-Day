using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float existTime = 2f;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(ie_TurnOffText());
    }


    private IEnumerator ie_TurnOffText() {
        yield return new WaitForSeconds(existTime);
        if (existTime > 2.5f)
        {
            GameObject.Destroy(gameObject);
        }
        else {
            gameObject.SetActive(false);

        }
    }
}
