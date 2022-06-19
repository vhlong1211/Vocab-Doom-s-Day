using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerAnimator : MonoBehaviour
{   
    private static PlayerAnimator m_Instance;

    public static PlayerAnimator Instance
    {
        get
        {
            return m_Instance;
        }
    }
    private void Awake()
    {
        if (m_Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public NavMeshAgent agent;
    public Animator anim;
    public UnityEvent stopCastingEvent;
    public UnityEvent shootEvent;
    public UnityEvent castSkill1Event;
    public UnityEvent castSkill2Event;
    public UnityEvent castSkill3Event;
    public UnityEvent skill1Power;

    float motionSmoothTime = 0.1f;


    // Update is called once per frame
    void Update()
    {   
        float speed = agent.velocity.magnitude / agent.speed;
        if(agent.speed == 0)    speed = 0;
        anim.SetFloat("Speed",speed,motionSmoothTime,Time.deltaTime);
    }

    public void CastSkill1Anim(){
        anim.SetTrigger(AnimationTag.SKILL_1_TRIGGER);
    }

    public void CastSkill2Anim(){
        anim.SetTrigger(AnimationTag.SKILL_2_TRIGGER);
    }

    public void CastSkill3Anim(){
        anim.SetTrigger(AnimationTag.SKILL_3_TRIGGER);
    }

    public void AttackAnim(){
        anim.SetTrigger(AnimationTag.ATTACK_TRIGGER);
    }

    public void FinishCasting(){
        stopCastingEvent.Invoke();
    }

    public void Shoot(){
        shootEvent.Invoke();
    }

    public void UseSkill1() {
        castSkill1Event.Invoke();
    }

    public void UseSkill2()
    {
        castSkill2Event.Invoke();
    }

    public void UseSkill3()
    {
        castSkill3Event.Invoke();
    }

    public void Skill1Power() {
        skill1Power.Invoke();
    }

}
