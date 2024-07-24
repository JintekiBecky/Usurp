using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    #region DiceTargets
    [Space(10)]
    [Header("Dice Targets")]
    [SerializeField] private GameObject[] DiceTargets = new GameObject[5];
    [SerializeField] private bool[] active = new bool[5];
    [SerializeField] private int noOfTargets;
    #endregion

    public int count = 0;
    void Start ()
    {
        for(int i = 0; i < noOfTargets; i++)
        {
            DiceTargets[i].SetActive(true);
            active[i] = true;

        }

        for(int i = noOfTargets; i < DiceTargets.Length; i++)
        {
            DiceTargets[i].SetActive(false);
            active[i] = false;
        }

    }
    void Update ()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
        {
          //  CheckAllInActive();
        }
    }

    public void SetChildActive(int refNO, bool condition)
    {
        active[refNO] = condition;
    }

   /* private void CheckAllInActive()
    {   
        count = 0;
        for(int i = 0; i < noOfTargets; i++)
        {
            if(active[i])
            {
                
            }
            else
            {
                count++;
            }
        }
        
        if (count == noOfTargets)
        {
            Debug.Log("STRUCTURE DESTROYED");
        }
    }*/

}
