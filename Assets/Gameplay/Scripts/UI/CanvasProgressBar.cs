using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class CanvasProgressBar : MonoBehaviour
{
    public int current;
    public int max;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        max = EnemyManager.Instance.maxEnemyDead;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentFill();
    }

    private void CurrentFill() {
        current = EnemyManager.Instance.deadEnemyCount;
        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;

    }
}
