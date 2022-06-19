using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasGameplay : UICanvas
{   
    private static CanvasGameplay m_Instance;

    public static CanvasGameplay Instance
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
        health = PlayerManager.Instance.health;
    }

    //UI canvas
    public CanvasDieScreen canvasDieScreen;
    public TimerClock timerClock;

    //Variable of player stat
    private int health;

    //UI player health
    public Transform playerHealthSlider;
    public Transform chosenCharUI;
    public Slider playerHealthSlider3D;
    public Slider playerHealthSlider2D;
    public TextMeshProUGUI chosenCharText;

    //UI for ability
    [Header("Ability1")]
    public Image abilityImage1;
    public float cooldown1 = 5f;
    bool isCooldown1 = false;
    public KeyCode ability1;

    [Header("Ability2")]
    public Image abilityImage2;
    public float cooldown2 = 5f;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability3")]
    public Image abilityImage3;
    public float cooldown3 = 5f;
    bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability4")]
    public Image abilityImage4;
    public float cooldown4 = 5f;
    bool isCooldown4 = false;
    public KeyCode ability4;

    void Start() {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;

        playerHealthSlider2D.maxValue = health;
        playerHealthSlider3D.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1Display();
        Ability2Display();
        Ability3Display();
        Ability4Display();

        playerHealthSlider2D.value = PlayerManager.Instance.health;
        playerHealthSlider3D.value = playerHealthSlider2D.value;
    }

    void LateUpdate() {
        playerHealthSlider.LookAt(Camera.main.transform);
        playerHealthSlider.Rotate(0,180,0);
        chosenCharUI.LookAt(Camera.main.transform);
        chosenCharUI.Rotate(0,180,0);
    }

    void Ability1Display(){
        if(Input.GetKey(ability1) && isCooldown1 == false){
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown1){
            abilityImage1.fillAmount -= 1 /cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0){
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }

    void Ability2Display(){
        if(Input.GetKey(ability2) && isCooldown2 == false){
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if(isCooldown2){
            abilityImage2.fillAmount -= 1 /cooldown2 * Time.deltaTime;

            if(abilityImage2.fillAmount <= 0){
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3Display(){
        if(Input.GetKey(ability3) && isCooldown3 == false){
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if(isCooldown3){
            abilityImage3.fillAmount -= 1 /cooldown3 * Time.deltaTime;

            if(abilityImage3.fillAmount <= 0){
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Ability4Display(){
        if(Input.GetKey(ability4) && isCooldown4 == false){
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }

        if(isCooldown4){
            abilityImage4.fillAmount -= 1 /cooldown4 * Time.deltaTime;

            if(abilityImage4.fillAmount <= 0){
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
