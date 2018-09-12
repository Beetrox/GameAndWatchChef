using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

    //[HideInInspector]
    public GameManager gameManager;
    public Transform positions;

    int currentPosition = 4;
    public float gameSpeed = 1;
    bool isFalling = true;
    int topPosition;
    
    void Start ()
    {
        transform.position = positions.GetChild(currentPosition).transform.position;
        topPosition = positions.childCount;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameSpeed);
            MovePosition();
        }
    }

    void MovePosition()
    {
        if (currentPosition == 0)
        {
            gameManager.IsEatenByRat(gameObject);
            gameManager.LoseOneLife();
        }
        else if (currentPosition == topPosition)
        {
            currentPosition--;
            isFalling = true;
        }
        else if (currentPosition < topPosition && isFalling)
        {
            currentPosition--;
        }
        else if (currentPosition < topPosition && !isFalling)
        {
            currentPosition++;
        }

        transform.position = positions.GetChild(currentPosition).transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.FoodSaved();
        gameSpeed = gameManager.SetGameSpeed(gameSpeed);
        currentPosition++;
        topPosition = Random.Range(positions.childCount - 2, positions.childCount);
        isFalling = false;

        transform.position = positions.GetChild(currentPosition).transform.position;
    }
}
