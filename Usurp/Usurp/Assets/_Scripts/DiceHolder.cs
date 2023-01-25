using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHolder : MonoBehaviour
{
    private SpriteRenderer display;
    private RollDice dice;
    public DrawDice draw;
    [SerializeField] MoveDice moveDice;

    public int numReq = 1;
    public Sprite[] diceDisplay;
    private Color activeColor = Color.green;
    private Color deactiveColor = Color.red;

    public bool canHold = true;

    // Start is called before the first frame update
    void Start()
    {
        draw = FindObjectOfType<DrawDice>();
        setDefaultColor();
        displayDice();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canHold == true)
        {
            //check what the other dice's value is
            dice = collision.GetComponent<RollDice>();
            //if its correct
            if (dice.diceValue == numReq)
            {
                //release the dice from the mouse
                moveDice = collision.GetComponent<MoveDice>();
                moveDice.isHeld = false;
                //snap the dice to the centre
                collision.transform.position = new Vector3
                (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
                //change the colour of the holder
                display.color = activeColor;
                //reduce the hand size;
                draw.handSize -= 1;
                // deleted the dice
                Destroy(collision.gameObject);
                //deactivate holder;
                canHold = false;
            }
        }
    }
    private void displayDice()
    {
        switch (numReq)
        {
            case 1:
                display.sprite = diceDisplay[0];
                break;
            case 2:
                display.sprite = diceDisplay[1];
                break;
            case 3:
                display.sprite = diceDisplay[2];
                break;
            case 4:
                display.sprite = diceDisplay[3];
                break;
            case 5:
                display.sprite = diceDisplay[4];
                break;
            case 6:
                display.sprite = diceDisplay[5];
                break;
        }
    }

    private void setDefaultColor()
    {
        display = GetComponent<SpriteRenderer>();
        display.color = deactiveColor;
    }
}
