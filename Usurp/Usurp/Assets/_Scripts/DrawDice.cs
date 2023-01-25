using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDice : MonoBehaviour
{
    [Header("Hand Size")]
    public int handSize;

    [Header("Dice in Hand")]
    public List<GameObject> currentDice = new List<GameObject>();
    [SerializeField] GameObject dice;

    [Header("UI Height")]
    public float firstRowHeight;
    public float secondRowHeight;

    // Start is called before the first frame update
    void Start()
    {
        PullDice();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void PullDice()
    {
        for (int i = 0; i < handSize; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject d1 = Instantiate(dice, new Vector3(0, firstRowHeight, 0), Quaternion.identity) as GameObject;
                    d1.transform.parent = gameObject.transform;
                    currentDice.Add(d1);
                    break;

                case 1:
                    GameObject d2 = Instantiate(dice, new Vector3(1f, firstRowHeight, 0), Quaternion.identity) as GameObject;
                    d2.transform.parent = gameObject.transform;
                    currentDice.Add(d2);
                    break;

                case 2:
                    GameObject d3 = Instantiate(dice, new Vector3(-1f, firstRowHeight, 0), Quaternion.identity) as GameObject;
                    d3.transform.parent = gameObject.transform; 
                    currentDice.Add(d3);
                    break;

                case 3:
                    GameObject d4 = Instantiate(dice, new Vector3(2f, firstRowHeight, 0), Quaternion.identity) as GameObject;
                    d4.transform.parent = gameObject.transform; 
                    currentDice.Add(d4);
                    break;

                case 4:
                    GameObject d5 = Instantiate(dice, new Vector3(-2f, firstRowHeight, 0), Quaternion.identity) as GameObject;
                    d5.transform.parent = gameObject.transform; 
                    currentDice.Add(d5);
                    break;

                case 5:
                    GameObject d6 = Instantiate(dice, new Vector3(0f, secondRowHeight, 0), Quaternion.identity) as GameObject;
                    d6.transform.parent = gameObject.transform; 
                    currentDice.Add(d6);
                    break;

                case 6:
                    GameObject d7 = Instantiate(dice, new Vector3(1f, secondRowHeight, 0), Quaternion.identity) as GameObject;
                    d7.transform.parent = gameObject.transform; 
                    currentDice.Add(d7);
                    break;

                case 7:
                    GameObject d8 = Instantiate(dice, new Vector3(-1f, secondRowHeight, 0), Quaternion.identity) as GameObject;
                    d8.transform.parent = gameObject.transform; 
                    currentDice.Add(d8);
                    break;

                case 8:
                    GameObject d9 = Instantiate(dice, new Vector3(2f, secondRowHeight, 0), Quaternion.identity) as GameObject;
                    d9.transform.parent = gameObject.transform; 
                    currentDice.Add(d9);
                    break;

                case 9:
                    GameObject d10 = Instantiate(dice, new Vector3(-2f, secondRowHeight, 0), Quaternion.identity) as GameObject;
                    d10.transform.parent = gameObject.transform; 
                    currentDice.Add(d10);
                    break;
            }


        }
    }
}