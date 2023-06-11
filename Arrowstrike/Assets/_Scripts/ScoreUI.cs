using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ScoreManager scoreManager;

    private void Update()
    {
        // Perbarui teks skor pada UI
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
    }
}
