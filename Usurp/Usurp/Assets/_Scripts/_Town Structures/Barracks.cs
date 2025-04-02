using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    [SerializeField] private Structure structure;
    [SerializeField] private DiceInHand diceInHand;
    [SerializeField] private GameManager gameManager;
    private float count = 0;
    private float oldCount;


    void Start ()
    {   
        gameManager = FindObjectOfType<GameManager>();
        diceInHand = FindObjectOfType<DiceInHand>();
        count = oldCount;
    }
    
    public void CheckBarracks()
    {
        if(structure.CheckIfAllTargetsDestroyed()) // if all Targets are destoryed
        {
            Debug.Log("Barracks TRUE");
            structure.CheckAllInActive(); //Exceute Normal Destory structure function
        }
        else
        {
            Debug.Log("Barracks FALSE"); // if all targets arent destoryed
            structure.SetChildActive(structure.GetstructureRefNo(), true); 
            // Check how many targets are destoryed
            count = structure.CheckNoOfDestroyed();
            // Return Dice to hand
            if(count != oldCount)
            {
                diceInHand.SetHandSize(count);
            }
            
            oldCount = count;
            // Set all the Targets to active again
            structure.ActivateStructure();
        }
    }
}
