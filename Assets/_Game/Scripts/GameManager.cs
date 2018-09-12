using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject FoodPrefab;
    public GameObject ChefPrefab;
    public LifeController lifeController;
    public ScoreController scoreController;

    public Vector3 foodOneLocation = new Vector3(-5, 0, 0);
    public Vector3 foodTwoLocation = new Vector3(0, 0, 0);
    public Vector3 foodThreeLocation = new Vector3(5, 0, 0);

    public bool continueGame = true;
    int score = 0;

	void Start ()
    {
        lifeController.RestoreAllLives();

        StartCoroutine(FoodSpawner());
    }

    IEnumerator FoodSpawner()
    {
         StartCoroutine(NewFood());
     
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator NewFood()
    {
        yield return null;
        if (!GameObject.FindGameObjectWithTag("Food 1"))
        {
            GameObject food1 = Instantiate(FoodPrefab, foodOneLocation, transform.rotation);
            FoodController foodController1 = food1.GetComponentInChildren<FoodController>();
            foodController1.gameManager = this;
            food1.tag = "Food 1";
            yield return new WaitForSeconds(0.3f);

        }

        if (!GameObject.FindGameObjectWithTag("Food 2"))
        {
            GameObject food2 = Instantiate(FoodPrefab, foodTwoLocation, transform.rotation);
            FoodController foodController2 = food2.GetComponentInChildren<FoodController>();
            foodController2.gameManager = this;
            food2.tag = "Food 2";
            yield return new WaitForSeconds(0.3f);

        }

        if (!GameObject.FindGameObjectWithTag("Food 3"))
        {
            GameObject food3 = Instantiate(FoodPrefab, foodThreeLocation, transform.rotation);
            FoodController foodController3 = food3.GetComponentInChildren<FoodController>();
            foodController3.gameManager = this;
            food3.tag = "Food 3";
        }
    }

    public void FoodSaved()
    {
        score++;
        scoreController.SetScore(score);
    }

        public void IsEatenByRat(GameObject food)
    {
        Destroy(food.transform.parent.gameObject);
        if (continueGame)
        {
            StartCoroutine(NewFood());
        }
    }

    public void LoseOneLife()
    {
        if (!lifeController.RemoveLife())
        {
            continueGame = false;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public float SetGameSpeed(float currentGameSpeed)
    {
        float newGameSpeed = currentGameSpeed - (0.0005f * score);
        return newGameSpeed;
    }
}

