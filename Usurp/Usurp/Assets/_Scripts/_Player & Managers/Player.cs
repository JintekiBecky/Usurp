using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Header Dice Chance Values
    [Space(10)]
    [Header("Dice Modifer Values")]
    #endregion
     #region Tooltip
    [Tooltip("The place where modifer values are stored when the player unlocks perks : 1 = Eye, 2 = Sword, 3 = Spear, 4 = Shield, 5 = Bomb , 6 = Plane")]
    #endregion
    [SerializeField] private float[] Modifer = new float[6];


    public float GetModifer(int no)
    {
        return Modifer[no];
    }

    public void SetModifier(int no, float mod)
    {
        Modifer[no] = mod;
    }
}
