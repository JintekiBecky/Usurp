using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDice : MonoBehaviour
{

    float startPosX;
    float startPosY;

    public bool isHeld = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // convert mouse position to screen position

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // convert mouse position to screen position

            isHeld = true;
            Debug.Log("You Pick Up A Dice");
        }
    }
    private void OnMouseUp()
    {
        isHeld = false;
    }
}
