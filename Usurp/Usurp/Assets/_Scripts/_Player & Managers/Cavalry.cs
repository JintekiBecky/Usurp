using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalry : MonoBehaviour
{
    [SerializeField] private int cavalryCounter;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DiceInHand diceInHand;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        diceInHand = FindObjectOfType<DiceInHand>();
        //cavalryCounter = (int)((diceInHand.GetHandSize() / 2) + diceInHand.GetHandSize());
        SetCavalryCounter(cavalryCounter);
    }

    void Update()
    {

    }

    public int GetCavalryCounter()
    {
        return cavalryCounter;

    }
    public void SetCavalryCounter(int no)
    {
        cavalryCounter = no;
        gameManager.ChangeCalvaryText(no);

        if(cavalryCounter <= 0)
        {
            gameManager.EndGame();
        }
    }
}
