using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig", order = 1)]

public class PlayerScriptable : ScriptableObject
{
    public int health;
    public float speed;
    public float bulletSpeed;
    public float skill1Cooldown;
    public float skill2Cooldown;
    public float skill3Cooldown;
    public float skill4Cooldown;

    public float buffSpeedAmount;
    public float buffBulletAmount;
    public int buffHealthAmount;
    public float buffCooldownAmount;

}
