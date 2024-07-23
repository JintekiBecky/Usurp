using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInHand : MonoBehaviour
{
    #region Handsize
    [Space(10)]
    [Header("Hand Size")]
    [SerializeField] private int handSize;
    #endregion

    #region Dice In Hand
    [Space(10)]
    [Header("Dice in Hand")]
    [SerializeField] private List<GameObject> currentDice = new List<GameObject>();
    [SerializeField] GameObject dice;
    #endregion

    #region Grid dimensions for Dice in Hand
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
    // Start is called before the first frame update
    void Start ()
    {
        DrawDice();
    }

    private void DrawDice(){

    for (int i = 0;i < handSize && i < columnLenght * rowLenght; i++)
   {
    GameObject d1 = Instantiate(dice,new Vector3(x_Start + (x_Space * (i % columnLenght)), y_Start + (-y_Space * (i / columnLenght)), z_Start), Quaternion.identity) as GameObject;
    d1.transform.parent = gameObject.transform;
    currentDice.Add(d1);
    }
   
    }

}
