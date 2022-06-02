using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using System.Diagnostics;

public class PlayerController : MonoBehaviour
{   

    public Transform gunPosition;
    public NavMeshAgent agent;
    public Transform bulletPrefab;

    private float rotateVelocity ;
    private float speed = 7;
    private bool isCasting = false;
    private Vector3 clickPosBuffer;
    
     
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            if(isCasting)   return;
            RaycastHit hit;
            //Check if raycast hit sthing
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity)){
                //Move to the raycast point
                agent.SetDestination(hit.point);
            }
        } 
        if(Input.GetMouseButtonDown(0)){
            if(isCasting)   return;
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity);
            clickPosBuffer = hit.point;
            NormalAttack();
        } 
        DoRotation();
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput(){
        if(isCasting)   return;
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(1)){
        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        if(Input.GetKeyDown(KeyCode.A)){
            //Debug.Log("a");
            ChangeWord('a');
        }else if(Input.GetKeyDown(KeyCode.B)){
            //Debug.Log("b");
            ChangeWord('b');
        }else if(Input.GetKeyDown(KeyCode.C)){
            //Debug.Log("c");
            ChangeWord('c');               
        }else if(Input.GetKeyDown(KeyCode.D)){
            //Debug.Log("d");
            ChangeWord('d');
        }else if(Input.GetKeyDown(KeyCode.E)){
            //Debug.Log("e");
            ChangeWord('e');
        }else if(Input.GetKeyDown(KeyCode.F)){
            //Debug.Log("f");
            ChangeWord('f');
        }else if(Input.GetKeyDown(KeyCode.G)){
            //Debug.Log("g");
            ChangeWord('g');
        }else if(Input.GetKeyDown(KeyCode.H)){
            //Debug.Log("h");
            ChangeWord('h');
        }else if(Input.GetKeyDown(KeyCode.I)){
            //Debug.Log("i");
            ChangeWord('i');
        }else if(Input.GetKeyDown(KeyCode.J)){
            //Debug.Log("j");
            ChangeWord('j');
        }else if(Input.GetKeyDown(KeyCode.K)){
            //Debug.Log("k");
            ChangeWord('k');
        }else if(Input.GetKeyDown(KeyCode.L)){
            //Debug.Log("l");
            ChangeWord('l');
        }else if(Input.GetKeyDown(KeyCode.M)){
            //Debug.Log("m");
            ChangeWord('m');
        }else if(Input.GetKeyDown(KeyCode.N)){
            //Debug.Log("n");
            ChangeWord('n');
        }else if(Input.GetKeyDown(KeyCode.O)){
            //Debug.Log("o");
            ChangeWord('o');
        }else if(Input.GetKeyDown(KeyCode.P)){
            //Debug.Log("p");
            ChangeWord('p');
        }else if(Input.GetKeyDown(KeyCode.Q)){
            //Debug.Log("q");
            ChangeWord('q');
        }else if(Input.GetKeyDown(KeyCode.R)){
            //Debug.Log("r");
            ChangeWord('r');
        }else if(Input.GetKeyDown(KeyCode.S)){
            //Debug.Log("s");
            ChangeWord('s');
        }else if(Input.GetKeyDown(KeyCode.T)){
            //Debug.Log("t");
            ChangeWord('t');
        }else if(Input.GetKeyDown(KeyCode.U)){
            //Debug.Log("u");
            ChangeWord('u');
        }else if(Input.GetKeyDown(KeyCode.V)){
            //Debug.Log("v");
            ChangeWord('v');
        }else if(Input.GetKeyDown(KeyCode.W)){
            //Debug.Log("w");
            ChangeWord('w');
        }else if(Input.GetKeyDown(KeyCode.X)){
            //Debug.Log("x");
            ChangeWord('x');
        }else if(Input.GetKeyDown(KeyCode.Y)){
            //Debug.Log("y");
            ChangeWord('y');
        }else if(Input.GetKeyDown(KeyCode.Z)){
            //Debug.Log("z");
            ChangeWord('z');
        }else if(Input.GetKeyDown(KeyCode.Alpha1)){
            //Debug.Log("1");
            PlayerAnimator.Instance.CastSkill1();
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            //Debug.Log("2");
            PlayerAnimator.Instance.CastSkill2();
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            //Debug.Log("3");
            PlayerAnimator.Instance.CastSkill3();
        }else if(Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Space");
            Blink();
        }else{
            return;
        }
        // stopwatch.Stop();
        // Debug.Log(stopwatch.ElapsedMilliseconds*10000);
        }
    }

    private void ChangeWord(char word){
        CanvasGameplay.Instance.chosenCharText.SetText(word.ToString());
        PlayerManager.Instance.chosenChar = word;
    }

    private void NormalAttack(){
        agent.speed = 0;
        agent.SetDestination(transform.position);
        isCasting = true;
        PlayerAnimator.Instance.Attack();
    }

    private void DoRotation(){
        if(!isCasting)  return;
        clickPosBuffer = new Vector3(clickPosBuffer.x,transform.position.y,clickPosBuffer.z);
        Quaternion rotationToLookAt = Quaternion.LookRotation(clickPosBuffer - transform.position);
        float angleDiff = Quaternion.Angle(transform.rotation,rotationToLookAt);
        //Debug.Log("root:" +transform.eulerAngles + "---" + rotationToLookAt.eulerAngles);
        //Debug.Log(angleDiff);
        float turnTime = 0.19f / 2f;
        rotateVelocity = angleDiff / turnTime * 2;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotationToLookAt,rotateVelocity*Time.deltaTime);
    }

    public void Shoot(){
        Transform bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<Projectile>().chosenChar = PlayerManager.Instance.chosenChar;
        bullet.position = gunPosition.position;
        bullet.rotation = gunPosition.rotation;
    }

    public void FinishCasting(){
        agent.speed = speed;
        isCasting = false;
    }

    public void Blink(){
        if(isCasting)   return;
        float blinkDistance = 5f;
        agent.enabled = false;
        for(int i = 0 ; i < 10 ; i++){
            Vector3 destination = transform.position + transform.forward * (blinkDistance - blinkDistance * i/10);
            NavMeshHit hit;
            bool isBaked = NavMesh.SamplePosition(destination,out hit ,0f,NavMesh.AllAreas);
            if(isBaked){
                transform.position = destination;
                agent.enabled = true;
                NavMeshHit hitParam;
                if(NavMesh.SamplePosition(destination + transform.forward,out hitParam ,0f,NavMesh.AllAreas)){
                    Debug.Log("case 1:"+ (destination + transform.forward));
                    agent.SetDestination(destination + transform.forward);
                }else{
                    Debug.Log("case 2:"+destination);
                    agent.SetDestination(destination);
                }
                return;
            }
        }
        agent.enabled = true; 
    }
}
