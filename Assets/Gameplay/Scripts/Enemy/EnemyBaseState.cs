using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(EnemyStateManager enemy);

    public abstract void UpdateState(EnemyStateManager enemy);

    public virtual void EnterState(EnemyStateManager enemy, float time) { }


    public virtual void OnTriggerEnter(EnemyStateManager enemy,Collider hit) {
        if (hit.transform.CompareTag(TagUtility.TAG_BULLET))
        {
            char chosenChar = hit.gameObject.GetComponent<Projectile>().chosenChar;
            //GameObject.Destroy(hit.gameObject);
            SimplePool.Despawn(hit.gameObject);
            int i = 0;
            bool isHit = false;
            foreach (KeyValuePair<char, int> entry in enemy.weakCharHolder)
            {
                if (chosenChar.Equals(entry.Key))
                {
                    isHit = true;
                    TextMeshProUGUI charTxt = enemy.enemyCharUI.hiddenCharList[entry.Value];
                    charTxt.text = chosenChar.ToString();
                    enemy.weakCharHolder.RemoveAt(i);
                    break;
                }
                i++;
            }
            if (isHit)
            {
                SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.HitSound2);
            }
            else {
                SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.HitSound1);
            }
            if (enemy.weakCharHolder.Count == 0)
            {
                PlayerManager.Instance.goldCollected += Random.Range(10, 15);
                enemy.PrepareDie();
                //enemy.Die();
            }
        }
        else if (hit.transform.CompareTag(TagUtility.TAG_PLAYER)) {
            foreach (KeyValuePair<char, int> entry in enemy.weakCharHolder)
            {
                TextMeshProUGUI charTxt = enemy.enemyCharUI.hiddenCharList[entry.Value];
                charTxt.text = entry.Key.ToString();
            }
            enemy.PrepareDie();
            PlayerManager.Instance.player.GetHit();
        }
    }

}
