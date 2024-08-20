using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    [SerializeField] private int countdown;
    [SerializeField] private Cavalry cavalry;
    [SerializeField] private Structure structure;
    
    [SerializeField] private List<GameObject> currentCountdown = new List<GameObject>();

    
    [Space(10)]
    [SerializeField]private Color activeColor = Color.red;
    [SerializeField]private Color deactiveColor = Color.grey;


     #region Grid dimensions for Countdown Display
    [Space(10)]
    [Header("UI Height")]
    [SerializeField] private int columnLenght;
    [SerializeField] private int rowLenght;
    [SerializeField] private float x_Space;
    [SerializeField] private float y_Space;
    [SerializeField] private float x_Start;
    [SerializeField] private float y_Start;
    [SerializeField] private float z_Start;
    #endregion

     private SpriteRenderer display;
     private int temp = 0;

    void OnEnable()
    {
        EventManager.OnClicked += ReRoll;
    }

    void OnDisable()
    {
        EventManager.OnClicked -= ReRoll;
    }

    void Start()
    {
        structure = this.GetComponent<Structure>();
        cavalry = FindObjectOfType<Cavalry>();
        countdown = 7 - structure.structureLevel;
        StartCountdown(countdown);
    }

    void ReRoll()
    {
        Countdown();
    }

     public void StartCountdown(int countdown)
    {
        for(int i = 0; i < 5; i++)
        {
            if(i < countdown - 1)
            {                                
                ChangeCountColorDeactive(i);
                currentCountdown[i].SetActive(true);
            }
            else 
            {    
                currentCountdown[i].SetActive(false);
            }
        }    
    }

    private void ChangeCountColorActive(int no)
    {
        display = currentCountdown[no].GetComponent<SpriteRenderer>(); 
        display.color= activeColor;

    }
    private void ChangeCountColorDeactive(int no)
    {
        display = currentCountdown[no].GetComponent<SpriteRenderer>(); 
        display.color= deactiveColor;

    }

    public void Countdown()
    {
        if(!(structure.destory == true))
        {
        countdown--;
        
        ChangeCountColorActive(temp++);
        //Debug.Log("" + countdown);
        if(countdown == 0)
        {
            cavalry.SetCavalryCounter(cavalry.GetCavalryCounter() - 1);
            ResetCountdown();
        }
        }
    }
    private void ResetCountdown()
    {
            temp = 0;
            countdown = 7 - structure.structureLevel; 
            for(int i = 0; i < countdown;i++)
            {
               
                ChangeCountColorActive(i);
            }
            StartCountdown(countdown);


    }
}
