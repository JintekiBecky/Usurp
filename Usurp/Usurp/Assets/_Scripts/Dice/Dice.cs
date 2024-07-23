using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
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
    private float TotalChance = 0;
    private float Roll;


    
    void Start(){
        UpdateModifers();
        for (int i = 0;i < Chance.Length; i++)
        {
        CalculateChance(i);
        }
        
        CalculateTotalChance();
        RollDice();
    }

 void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
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

        Debug.Log(TotalChance + "    " + Roll);

      
        if(Roll <= Chance[0]){
            
                diceDisplay.sprite = diceArt[0];
        }
        else if(Roll <= Chance[1]){
            
                diceDisplay.sprite = diceArt[1];
        }
        else if(Roll <= Chance[2]){
            
                diceDisplay.sprite = diceArt[2];

        }
        else if(Roll <= Chance[3]){
            
                diceDisplay.sprite = diceArt[3];

        }
        else if(Roll <= Chance[4]){
            
                diceDisplay.sprite = diceArt[4];

        }
        else if(Roll <= Chance[5]){
            
                diceDisplay.sprite = diceArt[5];
        }
        else
        {
            Debug.Log("ERROR");
        }



    }

    private void UpdateModifers()
    {
        for(int i = 0; i < Chance.Length; i++)
        {
            Modifer[i] = player.GetModifer(i);
        }
    }
    private void DisplayChance()            // For Debugging purposes to view the all the Chances
    {
        for(int i =0; i < Chance.Length ; i++)
        {
            Debug.Log(Chance[i] + "    ");
        }
    }






}
