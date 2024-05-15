using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _totalScore;
    public TMP_Text scoreText;
    
    private void Start() {
        _totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        _score = 0;
        DefaultLogic.BallScore += ScorePlus;
    }

    private void ScorePlus(int score) {
        _score += score;
        scoreText.text = _score.ToString();
    }

    private void EndGameScore(){
        _totalScore += _score;
        PlayerPrefs.SetInt("TotalScore", _totalScore);
    }
}
