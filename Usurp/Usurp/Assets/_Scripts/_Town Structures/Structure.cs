using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{

    public bool destory = false;
    #region Parent Structure
    [Space(10)]
    [SerializeField] private Structure structure;
    [SerializeField] private int tier;
    #endregion
    #region Childern Structure
    [Space(10)]
    [SerializeField] private Structure[] structures;
    [SerializeField] private int noOfChildern;
    [SerializeField] private bool[] isDestoryed;

    #endregion 
    #region DiceTargets

    [Space(10)]
    [Header("Dice Targets")]
    [SerializeField] public int structureLevel;
    [SerializeField] private GameObject[] DiceTargets = new GameObject[5];
    [SerializeField] private bool[] active = new bool[5];
    [SerializeField] private int noOfTargets;

    [SerializeField] private DiceCollision dice;
    #endregion
    public int count = 0;
    public Transform child;
    public Collider2D collider;
    [SerializeField] private int structureRefNo;
    [SerializeField] private DiceInHand diceInHand;
    
    [SerializeField] private GameManager gameManager;

    private bool iDestoryed = false;

    void Start ()
    {
        
        
        gameManager = FindObjectOfType<GameManager>();
        diceInHand = FindObjectOfType<DiceInHand>();
        noOfChildern = structures.Length;
        
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
        

            switch(noOfChildern){
                case 1:
                isDestoryed = new bool[] {false};
                break;
                case 2:
                isDestoryed = new bool[] {false,false};
                break;
                case 3:
                isDestoryed = new bool[] {false,false,false};
                break;
            }

    
        if(!(structures.Length==0))
        {
            for(int i = 0; i < noOfTargets; i++)
            {
                    SetChildActive(i, false);
                    dice = DiceTargets[i].GetComponent<DiceCollision>();
                    dice.setDefaultColor(Color.grey);
            } 
        }

    }
    void Update ()
    {  

    }
     

    public void SetChildActive(int refNO, bool condition)
    {
        active[refNO] = condition;
        child = this.gameObject.transform.GetChild(refNO);
        collider = child.GetComponent<Collider2D>();
        collider.enabled = condition;
    }

    public void CheckAllInActive()
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
            isStructureDestoryed(structureRefNo);
            
            diceInHand.SetHandSize(noOfTargets);
            gameManager.diceBonus = true;
            Debug.Log("STRUCTURE DESTROYED");
            destory = true;
            if(structure.CheckAllChildernDestroyed())
            {   
                structure.ActivateStructure();
            }
        }
    }
    private bool CheckAllChildernDestroyed()
    {
        count = 0 ;
        for(int i = 0;i < noOfChildern; i++)
        {
            if(isDestoryed[i] == true)
            {
                count++;
            }
        }
        if(count == noOfChildern)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void isStructureDestoryed(int refNO)
    {
        Debug.Log("" + refNO);
        iDestoryed = true;
        structure.childDestoryed(refNO);
    }

    public void childDestoryed(int refNO)
    {
        isDestoryed[refNO] = true;
    }

    public void ActivateStructure()
    {
        for(int i = 0;i < noOfTargets; i++)
        {
            SetChildActive(i, true);
            dice = DiceTargets[i].GetComponent<DiceCollision>();
            dice.setDefaultColor(Color.white);
        }
    }
   
   }
