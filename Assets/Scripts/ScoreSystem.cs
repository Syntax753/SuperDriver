using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int scoreMultiplier = 10;

public const string HighScoreKey = "HighScore";

    private float score;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime*scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        int current= PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > current) {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
