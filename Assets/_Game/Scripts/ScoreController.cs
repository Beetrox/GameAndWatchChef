using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {

    TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();

        textMesh.SetText("0");

        if (textMesh == null)
        {
            Debug.LogError("Textmesh component not found!");
        }
    }


    public void SetScore(int score)
    {
        textMesh.SetText(score.ToString());
    }
}
