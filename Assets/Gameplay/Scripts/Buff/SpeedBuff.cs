using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour,IBuff
{
    private int index;
    private void Update()
    {
        if (GameManager.Instance.stopGameplayTrigger)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != TagUtility.TAG_PLAYER) return;
        StopCoroutine(PlayerManager.Instance.player.ie_SpeedUpBuff());
        StartCoroutine(PlayerManager.Instance.player.ie_SpeedUpBuff());
        BuffManager.Instance.existBuffIndex.RemoveAll(x => x == index);
        GameObject.Destroy(gameObject);
    }

    public void Setup(int i)
    {
        index = i;
    }
}
