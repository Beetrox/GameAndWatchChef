using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{

    private void OnEnable()
    {
        Click.OnLeftPressed += Click_OnLeftPressed;
        Click.OnRightPressed += Click_OnRightPressed;
    }

    private void OnDisable()
    {
        Click.OnLeftPressed -= Click_OnLeftPressed;
        Click.OnRightPressed -= Click_OnRightPressed;
    }

    private void Start()
    {
        //transform.position = positions[currentPosition].position;
    }

    void Click_OnLeftPressed()
    {
        //Debug.Log("Left pressed");
    }

    void Click_OnRightPressed()
    {
        //Debug.Log("Right pressed");
    }
}
