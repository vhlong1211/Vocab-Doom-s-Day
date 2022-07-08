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
    public List<ParticleSystem>  particlePrefabs;
    public Transform particleHolder;
    public Transform bulletPool;

    private float rotateVelocity ;
    private float speed = 7;
    private float cooldown1;
    private bool isCooldown1;
    private float cooldown2;
    private bool isCooldown2;
    private float cooldown3;
    private bool isCooldown3;
    private float cooldown4;
    private bool isCooldown4;

    [HideInInspector]
    public bool isCasting = false;
    private Vector3 clickPosBuffer;

    private int groundLayerFilter = 4096;
    
     
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.chosenChar = 'a';
        SimplePool.Preload(bulletPrefab.gameObject,10,bulletPool);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.Instance.isStartGame) return;
        if (PlayerManager.Instance.isDead) return;
        HandleCooldown();
        if (Input.GetMouseButtonDown(1)){
            if(isCasting)   return;
            RaycastHit hit;
            //Check if raycast hit sthing
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity,groundLayerFilter)){
                //Move to the raycast point
                clickPosBuffer = hit.point;
                agent.SetDestination(hit.point);
            }
        } 
        if(Input.GetMouseButtonDown(0)){
            if(isCasting)   return;
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity,groundLayerFilter);
            clickPosBuffer = hit.point;
            NormalAttack();
        } 
        DoRotation();
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput(){
        //if(isCasting)   return;
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
            if(isCasting || isCooldown1)   return;
            HandlePreCast();
            //isCastingSkill = false;
            PlayerAnimator.Instance.CastSkill1Anim();
            isCooldown1 = true;
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            //Debug.Log("2");
            if(isCasting || isCooldown2)   return;
            HandlePreCast();
            PlayerAnimator.Instance.CastSkill2Anim();
            isCooldown2 = true;
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            //Debug.Log("3");
            if(isCasting || isCooldown3)   return;
            HandlePreCast();
            PlayerAnimator.Instance.CastSkill3Anim();
            isCooldown3 = true;
        }else if(Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Space");
            if(isCasting || isCooldown4)   return;
            Blink();
            isCooldown4 = true;
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
        HandlePreCast();
        //isCastingSkill = false;
        PlayerAnimator.Instance.AttackAnim();
    }

    private void DoRotation(){
        if(!isCasting )  return;
        clickPosBuffer = new Vector3(clickPosBuffer.x,transform.position.y,clickPosBuffer.z);
        Quaternion rotationToLookAt = Quaternion.LookRotation(clickPosBuffer - transform.position);
        float angleDiff = Quaternion.Angle(transform.rotation,rotationToLookAt);
        //Debug.Log("root:" +transform.eulerAngles + "---" + rotationToLookAt.eulerAngles);
        //Debug.Log(angleDiff);
        float turnTime = 0.19f / 2f;
        rotateVelocity = angleDiff / turnTime * 2;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotationToLookAt,rotateVelocity*Time.deltaTime);
    }

    public void GetHit() {
        if (PlayerManager.Instance.health > 2)
        {
            PlayerManager.Instance.health -= 2;
        }
        else {
            PlayerManager.Instance.health -= 2;
            HandleDeath();
        }
    }

    public void HandleDeath() {
        PlayerAnimator.Instance.anim.SetTrigger("Death");
        agent.speed = 0;
        PlayerManager.Instance.isDead = true;
        GameManager.Instance.stopGameplayTrigger = true;
        GameManager.Instance.isWin = false;
    }
    public void Shoot(){
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.shotSound);
        //Transform bullet = Instantiate(bulletPrefab);
        GameObject bullet = SimplePool.Spawn(bulletPrefab.gameObject,gunPosition.position,gunPosition.rotation);
        bullet.GetComponent<Projectile>().chosenChar = PlayerManager.Instance.chosenChar;
        //bullet.position = gunPosition.position;
        //bullet.rotation = gunPosition.rotation;
    }

    public void FinishCasting(){
        agent.speed = speed;
        isCasting = false;
    }

    public void HandleCooldown() {
        if (isCooldown1)
        {
            cooldown1 -= Time.deltaTime;
            if (cooldown1 < 0) {
                cooldown1 = PlayerManager.Instance.cooldown1;
                isCooldown1 = false;
            }
        }
        if (isCooldown2) {
            cooldown2 -= Time.deltaTime;
            if (cooldown2 < 0)
            {
                cooldown2 = PlayerManager.Instance.cooldown2;
                isCooldown2 = false;
            }
        }
        if (isCooldown3)
        {
            cooldown3 -= Time.deltaTime;
            if (cooldown3 < 0)
            {
                cooldown3 = PlayerManager.Instance.cooldown3;
                isCooldown3 = false;
            }
        }
        if (isCooldown4)
        {
            cooldown4 -= Time.deltaTime;
            if (cooldown4 < 0)
            {
                cooldown4 = PlayerManager.Instance.cooldown4;
                isCooldown4 = false;
            }
        }
    }

    public void Blink(){
        if(isCasting)   return;

        //particleHolder.transform.position = transform.position;
        //particleHolder.eulerAngles = transform.eulerAngles;
        particlePrefabs[3].transform.position = transform.position;
        particlePrefabs[3].transform.eulerAngles = transform.eulerAngles;
        particlePrefabs[3].gameObject.SetActive(true);
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.BlinkSound);
        StartCoroutine(TurnOffParticle(particlePrefabs[3].gameObject));

        float blinkDistance = 5f;
        //particleHolder.transform.position = transform.position;
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
                    //Debug.Log("case 1:"+ (destination + transform.forward));
                    agent.SetDestination(destination + transform.forward);
                }
                else{
                    //Debug.Log("case 2:"+destination);
                    agent.SetDestination(destination);
                }
                return;
            }
        }
        agent.enabled = true; 
    }

    public void CastSkill1() {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.Skill1Sound);
        particleHolder.transform.position = transform.position;
        particleHolder.eulerAngles = transform.eulerAngles;
        particlePrefabs[0].gameObject.SetActive(true);
        StartCoroutine(TurnOffParticle(particlePrefabs[0].gameObject));
    }

    public void CastSkill2()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.Skill2Sound);
        particleHolder.transform.position = transform.position;
        particleHolder.eulerAngles = transform.eulerAngles;
        particlePrefabs[1].gameObject.SetActive(true);
        StartCoroutine(TurnOffParticle(particlePrefabs[1].gameObject));
        Skill2Power();
    }

    public void CastSkill3()
    {
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.ShieldSwingSound);
        particleHolder.transform.position = transform.position;
        particleHolder.eulerAngles = transform.eulerAngles;
        particlePrefabs[2].gameObject.SetActive(true);
        StartCoroutine(TurnOffParticle(particlePrefabs[2].gameObject));
        Skill3Power();
    }

    private void Skill3Power() {
        List<EnemyStateManager> enemyAffected = EnemyManager.Instance.OverlapEnemy(transform, 7f, 100f);
        foreach (EnemyStateManager enemy in enemyAffected) {
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.Skill3Sound);
            Vector3 pushDir = enemy.transform.position - transform.position;
            enemy.SwitchState(enemy.PushBackState);
            enemy.rbody.AddForce(pushDir.normalized * 5000);
        }
    }

    private void Skill2Power()
    {
        List<EnemyStateManager> enemyAffected = EnemyManager.Instance.OverlapEnemy(transform, 10f, 360f);
        //StopCoroutine(ie_SpeedUpBuff());
        //StartCoroutine(ie_SpeedUpBuff());
        GetSpeedBuff();
        foreach (EnemyStateManager enemy in enemyAffected)
        {
            enemy.SwitchState(enemy.StunState , 3f);
        }
    }

    public void Skill1Power() {
        float skillLength = 13f;
        float skillWidth = 2f;
        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.position + transform.forward * skillLength;
        List<EnemyStateManager> enemyAffected = EnemyManager.Instance.GetEnemyFoward(startPoint, endPoint, skillWidth);
        foreach (EnemyStateManager enemy in enemyAffected)
        {
            enemy.enemyCharUI.floatingTextEng.gameObject.SetActive(true);
        }

    }

    public IEnumerator ie_SpeedUpBuff() {
        speed = 10f;
        agent.speed = speed;
        yield return new WaitForSeconds(10f);
        speed = 7f;
        agent.speed = speed;
    }

    public void GetSpeedBuff() {
        StopCoroutine("ie_SpeedUpBuff");
        StartCoroutine("ie_SpeedUpBuff");
    }

    public void GetHealth() {
        PlayerManager.Instance.health += 5;
        PlayerManager.Instance.health = PlayerManager.Instance.health > 20 ? 20 : PlayerManager.Instance.health;
    }

    private void HandlePreCast() {
        agent.speed = 0;
        agent.SetDestination(transform.position);
        isCasting = true;
        //isCastingSkill = true;
    }
    public void GetStat() {
        cooldown1 = PlayerManager.Instance.cooldown1;
        cooldown2 = PlayerManager.Instance.cooldown2;
        cooldown3 = PlayerManager.Instance.cooldown3;
        cooldown4 = PlayerManager.Instance.cooldown4;
        speed = PlayerManager.Instance.speed;
    }

    public IEnumerator TurnOffParticle(GameObject particle) {
        yield return new WaitForSeconds(2f);
        particle.SetActive(false);
    }
}
