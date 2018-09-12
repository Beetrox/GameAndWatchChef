using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour {

    public List<Transform> ChefPositions = new List<Transform>();

    int CurrentChefPosition = 1;

    private void OnEnable()
    {
        Click.OnLeftPressed += Input_OnLeftPressed;
        Click.OnRightPressed += Input_OnRightPressed;
    }

    private void OnDisable()
    {
        Click.OnLeftPressed -= Input_OnLeftPressed;
        Click.OnRightPressed -= Input_OnRightPressed;
    }

    private void Start()
    {
        transform.position = ChefPositions[CurrentChefPosition].position;
    }


    void Input_OnLeftPressed()
    {
        if (CurrentChefPosition > 0)
        {
            CurrentChefPosition--;
            transform.position = ChefPositions[CurrentChefPosition].position;
        }
    }

    void Input_OnRightPressed()
    {
        if (CurrentChefPosition < ChefPositions.Count - 1)
        {
            CurrentChefPosition++;
            transform.position = ChefPositions[CurrentChefPosition].position;
        }
    }
}
