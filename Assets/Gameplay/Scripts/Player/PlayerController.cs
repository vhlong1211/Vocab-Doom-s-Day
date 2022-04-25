using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;
    
    private 
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            RaycastHit hit;
            //Check if raycast hit sthing
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity)){
                //Move to the raycast point
                agent.SetDestination(hit.point);
                //Rotation
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                rotationToLookAt.eulerAngles.y,
                ref rotateVelocity,
                rotateSpeedMovement * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0,rotationY,0);
            }
        } 
        
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput(){
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(1)){
        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("a");
            ChangeWord('A');
        }else if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("b");
            ChangeWord('B');
        }else if(Input.GetKeyDown(KeyCode.C)){
            Debug.Log("c");
            ChangeWord('C');               
        }else if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("d");
            ChangeWord('D');
        }else if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("e");
            ChangeWord('E');
        }else if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("f");
            ChangeWord('F');
        }else if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log("g");
            ChangeWord('G');
        }else if(Input.GetKeyDown(KeyCode.H)){
            Debug.Log("h");
            ChangeWord('H');
        }else if(Input.GetKeyDown(KeyCode.I)){
            Debug.Log("i");
            ChangeWord('I');
        }else if(Input.GetKeyDown(KeyCode.J)){
            Debug.Log("j");
            ChangeWord('J');
        }else if(Input.GetKeyDown(KeyCode.K)){
            Debug.Log("k");
            ChangeWord('K');
        }else if(Input.GetKeyDown(KeyCode.L)){
            Debug.Log("l");
            ChangeWord('L');
        }else if(Input.GetKeyDown(KeyCode.M)){
            Debug.Log("m");
            ChangeWord('M');
        }else if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("n");
            ChangeWord('N');
        }else if(Input.GetKeyDown(KeyCode.O)){
            Debug.Log("o");
            ChangeWord('O');
        }else if(Input.GetKeyDown(KeyCode.P)){
            Debug.Log("p");
            ChangeWord('P');
        }else if(Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("q");
            ChangeWord('Q');
        }else if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("r");
            ChangeWord('R');
        }else if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("s");
            ChangeWord('S');
        }else if(Input.GetKeyDown(KeyCode.T)){
            Debug.Log("t");
            ChangeWord('T');
        }else if(Input.GetKeyDown(KeyCode.U)){
            Debug.Log("u");
            ChangeWord('U');
        }else if(Input.GetKeyDown(KeyCode.V)){
            Debug.Log("v");
            ChangeWord('V');
        }else if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("w");
            ChangeWord('W');
        }else if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("x");
            ChangeWord('X');
        }else if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("y");
            ChangeWord('Y');
        }else if(Input.GetKeyDown(KeyCode.Z)){
            Debug.Log("z");
            ChangeWord('Z');
        }else{
            return;
        }
        // stopwatch.Stop();
        // Debug.Log(stopwatch.ElapsedMilliseconds*10000);
        }
    }

    private void ChangeWord(char word){
        CanvasGameplay.Instance.chosenCharText.SetText(word.ToString());
        PlayerManager.Instance.chosenWord = word;
    }

}
