using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score => score; // Tambahkan properti Score untuk mengakses nilai score

    public TextMeshProUGUI scoreText;

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ShowFinalScore()
    {
        // Implementasikan logika yang sesuai untuk menampilkan skor akhir
        Debug.Log("Final Score: " + score);
    }

    public void ResetScore()
{
    score = 0;
    UpdateScoreText();
}

}
