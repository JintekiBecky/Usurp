using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCollision : MonoBehaviour
{
    #region Header Player Manager
    [Space(10)]
    [Header("Player Reference")]
    [SerializeField] private Player player;
    #endregion
    #region Header Dice Chance Values
    [Space(10)]
    [Header("Dice Chance Values")]
    [Tooltip("Add the base chance for each side of the dice : 1 = Eye, 2 = Sword, 3 = Spear, 4 = Shield, 5 = Bomb , 6 = Plane")]
    [SerializeField] private float[] Chance = new float[6];
     private float TotalChance = 0;
    private float Roll;
    #endregion
    #region Tooltip
    [Tooltip("Add the Chance modifers for each side of the dice This can be changed with SetModifier() : 1 = Eye, 2 = Sword, 3 = Spear, 4 = Shield, 5 = Bomb , 6 = Plane")]
    [SerializeField] private float[] Modifer = new float[6];
    #endregion
    #region Header Dice Sprite Art
    [Header("Dice Sprite Art")]
   
    [Tooltip("Dice Base Placeholder")]
    [SerializeField] private SpriteRenderer diceDisplay;

    [Tooltip("Sprites for each face of the dice : 1 = Eye, 2 = Sword, 3 = Spear, 4 = Shield, 5 = Bomb , 6 = Plane")]
    [SerializeField] private Sprite[] diceArt;
    #endregion
    #region Target Values
    [Space(10)]
    [Header("Target Values")]
    [SerializeField] private bool canHold = true;
    private float reqNum;
    private Dice dice;
    #endregion
    #region Parent Structure
    [Space(10)]
    [Header("Parent Structure")]
    
    [SerializeField] private Structure parentStructure;
    [SerializeField] private int childReferenceNo;
    #endregion

    [Space(10)]
    [SerializeField]private Color activeColor = Color.white;
    [SerializeField]private Color selectedColor = Color.green;
    [SerializeField]private Color deactiveColor = Color.grey;

    [SerializeField] private Color incorrectColor = Color.red;
    [SerializeField] private DiceInHand diceInHand;
    [SerializeField] private MoveDice moveDice;
    private SpriteRenderer display;


    void Start()
    {
        
        diceInHand = FindObjectOfType<DiceInHand>();
        setDefaultColor();
        UpdateModifers();
        for (int i = 0;i < Chance.Length; i++)
        {
        CalculateChance(i);
        }
        
        CalculateTotalChance();
        RollDice();
        
    }

     private void OnTriggerStay2D(Collider2D collision)
    {

        if(canHold == true)
        {
                
                dice = collision.GetComponent<Dice>();
                 
                if(dice.GetFace() == reqNum)
                {
                        display.color = selectedColor;
                }
                else
                {
                        display.color = incorrectColor;
                }
        }

    }     

    private void OnTriggerExit2D(Collider2D other)
    {   if(canHold== true)
        {
                
                dice = other.GetComponent<Dice>();

                if(dice.GetFace() == reqNum)
                {
                        moveDice = other.GetComponent<MoveDice>();
                        if(moveDice.isHeld == false)
                        {
                                other.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
                                display.color = deactiveColor;
                                diceInHand.SetHandSize(-1);
                                Destroy(other.gameObject);
                                canHold = false;
                                parentStructure.SetChildActive(childReferenceNo,false);
                               
                        }
                        else
                        {
                         
                                display.color = activeColor;        
                        }
                }
                else
                {
                     
                        display.color = activeColor;   
                }
        }
    } 


     private void CalculateChance(int no)
    {
       

        Chance[no] += Chance[no] * Modifer[no] / 100;
        if(no !=0)
        Chance[no]+= Chance[no-1];
        
        
    }

    private void CalculateTotalChance()
    {
            TotalChance = Chance[5];
    }

    private void RollDice()
    {
        Roll = Random.Range(0, TotalChance);

      
        if(Roll <= Chance[0]){
            
                diceDisplay.sprite = diceArt[0];
                reqNum = 1;
        }
        else if(Roll <= Chance[1]){
            
                diceDisplay.sprite = diceArt[1];
                reqNum = 2;
        }
        else if(Roll <= Chance[2]){
            
                diceDisplay.sprite = diceArt[2];
                reqNum = 3;

        }
        else if(Roll <= Chance[3]){
            
                diceDisplay.sprite = diceArt[3];
                reqNum = 4;

        }
        else if(Roll <= Chance[4]){
            
                diceDisplay.sprite = diceArt[4];
                reqNum = 5;

        }
        else if(Roll <= Chance[5]){
            
                diceDisplay.sprite = diceArt[5];
                reqNum = 6;
        }



    }

    private void UpdateModifers()
    {
        for(int i = 0; i < Chance.Length; i++)
        {
            Modifer[i] = player.GetModifer(i);
        }
    }

    private void setDefaultColor()
    {
        display = GetComponent<SpriteRenderer>();
        display.color = activeColor;
    }
}
