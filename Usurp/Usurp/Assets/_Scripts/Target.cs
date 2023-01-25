using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private DiceHolder holder;
    private DrawDice draw;

    public int completeCount;
    public int diceReward;
    public string targetName;
    public TextMesh nameDisplay;
    public Sprite plusDice;
    public Sprite minusDice;
    public SpriteRenderer leftDisplay;
    public SpriteRenderer RightDisplay;

    public GameObject[] dice;
    public bool[] targetCount;

    public bool completeTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        nameDisplay.text = targetName;
        targetCount = new bool[dice.Length];
        draw = FindObjectOfType<DrawDice>();

        rewardDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            //get the dice holder you want to check
            holder = dice[i].GetComponent<DiceHolder>();
            //if the dice holder is currently active (can't hold)
            if (holder.canHold == false)
            {
                // tick off that holder in the array
                targetCount[i] = true;
                completeCount++;
            }
        }

        if (completeCount < targetCount.Length)
        {
            completeCount = 0;
        }
        else
        {
            completeTarget = true;
        }

        completedTargetAction();

    }

    private void completedTargetAction()
    {
        //if all holders are completed
        if (completeTarget == true)
        {
            //stop the counter 
            completeCount = targetCount.Length;
            //debug
            Debug.Log("The Target has fallen");
            //Refund Dice
            draw.handSize += targetCount.Length;
            Debug.Log("You were refunded " + targetCount.Length + " Dice");
            //Give rewards
            draw.handSize += diceReward;
            //destroy the target (thhis should play like anmations and stuff too!
            Destroy(this.gameObject);
        }
    }

    private void rewardDisplay()
    {
        if (diceReward > 0)
        {
            leftDisplay.sprite = plusDice;
        }
        else if (diceReward < 0)
        {
            leftDisplay.sprite = minusDice;
        }
    }
}
