using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public SpriteRenderer diceDisplay;

    public Sprite[] diceArt;
    public int diceValue;

    // Start is called before the first frame update
    void Start()
    {
        Roll();
        this.gameObject.name = ("Dice " + diceValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }

    public void Roll()
    {
        diceValue = Random.Range(1, 7);
        switch (diceValue)
        {
            case 1:
                diceDisplay.sprite = diceArt[0];
                break;
            case 2:
                diceDisplay.sprite = diceArt[1];
                break;
            case 3:
                diceDisplay.sprite = diceArt[2];
                break;
            case 4:
                diceDisplay.sprite = diceArt[3];
                break;
            case 5:
                diceDisplay.sprite = diceArt[4];
                break;
            case 6:
                diceDisplay.sprite = diceArt[5];
                break;
        }
    }

}
