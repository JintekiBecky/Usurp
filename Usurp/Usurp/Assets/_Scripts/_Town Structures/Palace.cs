using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palace : MonoBehaviour
{
   // structures  under this one (The other one needs to be destoryed to activate this one)
    #region Childern Structure
    [Space(10)]
    [SerializeField] private Structure[] structures;
    [SerializeField] private int noOfChildern;
    [SerializeField] private bool[] isDestoryed;
    #endregion 

     #region DiceTargets
    [Space(10)]
    [Header("Dice Targets")]
    [SerializeField] private GameObject[] DiceTargets = new GameObject[5];
    [SerializeField] private bool[] active = new bool[5];
    [SerializeField] private int noOfTargets;
    [SerializeField] private DiceCollision dice;
    #endregion

}
