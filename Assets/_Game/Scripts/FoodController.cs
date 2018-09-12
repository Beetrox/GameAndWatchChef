using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

    //[HideInInspector]
    public GameManager gameManager;
    public Transform positions;

    int currentPosition = 4;
    public float moveDelay = 1;
    float lastMovement;
    bool isFalling = true;
    int topPosition;

    // Use this for initialization
    void Start ()
    {
        transform.position = positions.GetChild(currentPosition).transform.position;
        lastMovement = Time.time;
        topPosition = positions.childCount;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            MovePosition();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void MovePosition()
    {
        if (currentPosition == 0)
        {
            gameManager.IsEatenByRat(gameObject);
            //DestroyFood();
            //if (gameManager.continueGame)
            //{
            //    StartCoroutine(gameManager.NewFood());
            //    //Debug.Log("Is eaten, new food");
            //    // StartCoroutine(NewFood());
            //}
            gameManager.LoseOneLife();
        }
        else if (currentPosition == topPosition)
        {
            //Debug.Log("top");
            currentPosition--;
            isFalling = true;
        }
        else if (currentPosition < topPosition && isFalling)
        {
            //Debug.Log("down");
            currentPosition--;
        }
        else if (currentPosition < topPosition && !isFalling)
        {
            //Debug.Log("up");
            currentPosition++;
        }

        transform.position = positions.GetChild(currentPosition).transform.position;

        lastMovement = Time.time;

        if (positions.GetChild(currentPosition).GetComponent<FoodPosition>().isLowestPosition)
        {
            //Debug.Log("is lowest");
            ////if (gameManager.IsEatenByRat(gameObject))
            ////{
            ////    //Debug.Log("destroy");
            ////    //gameManager.missingFood = true;
            ////    //DestroyFood();
            ////} 
            ////else if (!gameManager.IsEatenByRat(gameObject))
            ////{
            ////    gameManager.FoodSaved();
            ////    moveDelay = gameManager.SetGameSpeed(moveDelay);
            ////    //Debug.Log(moveDelay);
            ////}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter");
        gameManager.FoodSaved();
        moveDelay = gameManager.SetGameSpeed(moveDelay);
        Debug.Log(moveDelay);
        //Debug.Log("bottom");
        //Debug.Log(currentPosition);
        currentPosition++;
        //Debug.Log(currentPosition);
        topPosition = Random.Range(positions.childCount - 2, positions.childCount);
        //Debug.Log(topPosition);
        isFalling = false;

        transform.position = positions.GetChild(currentPosition).transform.position;

        lastMovement = Time.time;
    }

    //public void DestroyFood(GameObject food)
    //{
    //    //Debug.Log("destroyed!");
    //    //Destroy(transform.parent.gameObject);
    //    Destroy(food);
    //}
}
