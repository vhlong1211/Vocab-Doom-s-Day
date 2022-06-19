using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMinimap : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = PlayerManager.Instance.player.transform;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
