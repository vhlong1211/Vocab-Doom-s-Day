using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(EnemyStateManager enemy);

    public abstract void UpdateState(EnemyStateManager enemy);

    public virtual void OnTriggerEnter(EnemyStateManager enemy,Collider hit) {
        if (hit.transform.CompareTag(TagUtility.TAG_BULLET)) {
            char chosenChar = hit.gameObject.GetComponent<Projectile>().chosenChar;
            GameObject.Destroy(hit.gameObject);
            int i = 0;
            foreach (KeyValuePair<char, int> entry in enemy.weakCharHolder) {
                if (chosenChar.Equals(entry.Key)) {
                    TextMeshProUGUI charTxt = enemy.enemyCharUI.hiddenCharList[entry.Value];
                    charTxt.text = chosenChar.ToString();
                    enemy.weakCharHolder.RemoveAt(i);
                    break;
                }
                i++;
            }
            if (enemy.weakCharHolder.Count == 0) {
                enemy.Die();
            }
        }
    }

}
