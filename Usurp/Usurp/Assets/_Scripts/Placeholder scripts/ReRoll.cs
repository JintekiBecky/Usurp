using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReRoll : MonoBehaviour
{
    public DrawDice draw;
    private Manager manager;

    public GameObject hand;



    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reRoll()
    {
        foreach (Transform child in hand.transform)
        {
            Destroy(child.gameObject);
        }

        manager.reRolls -= 1;
        draw.PullDice();
        Debug.Log("You rerolled the dice");
    }
}
