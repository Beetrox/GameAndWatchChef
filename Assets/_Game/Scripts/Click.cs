using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public bool Left;

    private void OnMouseDown()
    {
        if (OnLeftPressed != null && Left)
        {
            //Debug.Log("left");
            OnLeftPressed();
        }
        else if (OnRightPressed != null)
        {
            //Debug.Log("right");
            OnRightPressed();
        }
    }
}
