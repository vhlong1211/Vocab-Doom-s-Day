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
        PlayerManager.Instance.player.GetSpeedBuff();
        BuffManager.Instance.existBuffIndex.RemoveAll(x => x == index);
        GameObject.Destroy(gameObject);
    }

    public void Setup(int i)
    {
        index = i;
    }
}
