using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject FoodPrefab;
    public GameObject ChefPrefab;
    public LifeController lifeController;
    public ScoreController scoreController;
    public FoodController foodController;

    public Vector3 foodOneLocation = new Vector3(-5, 0, 0);
    public Vector3 foodTwoLocation = new Vector3(0, 0, 0);
    public Vector3 foodThreeLocation = new Vector3(5, 0, 0);

    Collider2D ChefCollider;
    public bool continueGame = true;
    int score = 0;
    //public bool missingFood = false;

	// Use this for initialization
	void Start ()
    {
        ChefCollider = ChefPrefab.GetComponentInChildren<Collider2D>();

        lifeController.RestoreAllLives();

        StartCoroutine(FoodSpawner());
    }

    IEnumerator FoodSpawner()
    {
         StartCoroutine(NewFood());
     
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public IEnumerator NewFood()
    {
        yield return null;
        if (!GameObject.FindGameObjectWithTag("Food 1"))
        {  
            //Debug.Log("spawn food 1");
            GameObject food1 = Instantiate(FoodPrefab, foodOneLocation, transform.rotation);
            FoodController foodController1 = food1.GetComponentInChildren<FoodController>();
            foodController1.gameManager = this;
            food1.tag = "Food 1";
            yield return new WaitForSeconds(0.3f);

        }

        if (!GameObject.FindGameObjectWithTag("Food 2"))
        {
            //Debug.Log("spawn food 2");
            GameObject food2 = Instantiate(FoodPrefab, foodTwoLocation, transform.rotation);
            FoodController foodController2 = food2.GetComponentInChildren<FoodController>();
            foodController2.gameManager = this;
            food2.tag = "Food 2";
            yield return new WaitForSeconds(0.3f);

        }

        if (!GameObject.FindGameObjectWithTag("Food 3"))
        {        
            //Debug.Log("spawn food 3");
            GameObject food3 = Instantiate(FoodPrefab, foodThreeLocation, transform.rotation);
            FoodController foodController3 = food3.GetComponentInChildren<FoodController>();
            foodController3.gameManager = this;
            food3.tag = "Food 3";
        }
        //jumperController.moveDelay = delay;
    }

    public void FoodSaved()
    {
        score++;
        scoreController.SetScore(score);
        //SetGameSpeed();
    }

    //public bool IsEatenByRat(GameObject Food)
    //{

    //    Collider2D FoodCollider = FoodPrefab.GetComponentInChildren<Collider2D>();

    //    if (FoodCollider == null || ChefCollider == null)
    //    {
    //        Debug.Log("Collider not found");
    //    }

    //    if (FoodCollider.IsTouching(ChefCollider))
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        Debug.Log("Eaten by rat");
    //        return true;
    //    }
    //}

        public void IsEatenByRat(GameObject food)
    {
        //foodController.DestroyFood(food);
        Destroy(food.transform.parent.gameObject);
        if (continueGame)
        {
            StartCoroutine(NewFood());
            //Debug.Log("Is eaten, new food");
            // StartCoroutine(NewFood());
        }
    }

    //public bool IsEatenByRat(GameObject food)
    //{
    //    LayerMask mask = LayerMask.GetMask("Chef");
    //    RaycastHit2D hit = Physics2D.Raycast(food.transform.position, Vector2.down, Mathf.Infinity, mask);
    //    if (hit.collider != null)
    //    {
    //        //Debug.Log("Saved!");
    //        return false;
    //    }
    //    else
    //    {
    //        Destroy(food.transform.parent.gameObject);
    //        if (continueGame)
    //        {
    //            StartCoroutine(NewFood());
    //            //Debug.Log("Is eaten, new food");
    //           // StartCoroutine(NewFood());
    //        }
    //        LoseOneLife();
    //        //Debug.Log("Nom nom");
    //        //StartCoroutine(Pause(1));
    //        //spawn new food
    //        //NewFood();
    //        //if (missingFood && continueGame)
    //        //{
    //        //    Debug.Log("spawn new food");
    //        //    StartCoroutine(NewFood());
    //        //    missingFood = false;
    //        //}
    //        return true;
    //    }
    //}

    //private IEnumerator PauseGame(int p)
    //{
    //    Debug.Log("pause started");
    //    Debug.Log("pause ended");
    //    Time.timeScale = 0.1f;
    //    yield return new WaitForSeconds(p);
    //    Time.timeScale = 1;
    //}

    public void LoseOneLife()
    {
        if (!lifeController.RemoveLife())
        {
            Debug.Log("Game Over!");
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

