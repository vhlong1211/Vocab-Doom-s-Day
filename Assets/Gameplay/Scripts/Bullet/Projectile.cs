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
    public void Setup(){
        //isSetup = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
