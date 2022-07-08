using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    private Transform m_Transform;
    //private bool isSetup = false;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
            {
                m_Transform = transform;
            }
            return m_Transform;
        }
    }
    
    private float speed = 30f;
    public char chosenChar;
    public ProjectileMover particle;

    // Start is called before the first frame update
    void OnEnable()
    {
        speed = PlayerManager.Instance.bulletSpeed;
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {   
        Move();
    }

    private void Move()
    {   
        //if(!isSetup)    return;
        Transform.position += Transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagUtility.TAG_ENEMY)) return;
        particle.HandleCollision(transform.position);
        //GameObject.Destroy(gameObject);
        SimplePool.Despawn(gameObject);
        StopAllCoroutines();
    }

    private IEnumerator DestroyBullet() { 
        yield return new WaitForSeconds(3);
        //GameObject.Destroy(gameObject);
        SimplePool.Despawn(gameObject);
    }
}
