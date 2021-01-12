using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int currentScore = 0;
    int currentMul = 1;
    Text scoreText;
    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = "SCORE: " + currentScore.ToString() + "\nMUL: x" + currentMul.ToString();
    }

    public void IncreaseScore(int val = 10) {
        currentScore += val * currentMul;
    }

    public void AdjustMult(int val) {
        currentMul = Mathf.Max(currentMul + val, 0);
    }

    void Update() {
        scoreText.text = "SCORE: " + currentScore.ToString() + "\nMUL: x" + currentMul.ToString();
    }
}
