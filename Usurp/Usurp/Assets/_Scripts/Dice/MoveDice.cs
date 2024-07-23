using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDice : MonoBehaviour
{

    float startPosX;
    float startPosY;
    
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool isHeld = false;

    void Start()
    {
        startPosX = this.gameObject.transform.localPosition.x;
        startPosY = this.gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    /*void Update()
    {
        if(isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // convert mouse position to screen position
            Debug.Log("    " + mousePos.x + "    " + mousePos.y);
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
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }*/

    void OnMouseDown()
    {
        isHeld = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    private void OnMouseUp()
    {
        isHeld = false;
        this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, 0);
    }
}
