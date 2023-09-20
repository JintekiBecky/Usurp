using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int reRolls = 5;
    TextMesh display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = reRolls.ToString();
    }
}
