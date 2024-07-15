using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    private void Start() {
        Enemy.OnScoreCount += UpdateScore;

    }

    private void UpdateScore() {
        score++;
        scoreText.text = score.ToString();
    }

    
}
