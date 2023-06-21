using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public TimerManager timerManager;
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;
    public BuffSpawnManager buffSpawnManager;
    public GameObject mainMenuPanel;
    public GameObject gameModePanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    private bool isGameStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Mengambil nilai HighScore dari PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Menampilkan nilai HighScore
        highScoreText.text = "High Score: " + highScore;
    }

    public void StartGameModeEasy()
    {
        if (!isGameStarted)
        {
            // Setel mode permainan untuk Easy
            spawnManager.spawnRangeX = 20f;
            spawnManager.minSpawnPosZ = 115f;
            spawnManager.maxSpawnPosZ = 140f;
            spawnManager.minSpawnPosY = 13f;
            spawnManager.maxSpawnPosY = 22f;
            spawnManager.spawnInterval = 6f;
            spawnManager.despawnDelay = 7f;

            buffSpawnManager.spawnInterval = 5f;
            buffSpawnManager.despawnDelay = 7f;

            // Mulai permainan
            spawnManager.StartSpawning();
            buffSpawnManager.StartSpawning();
            timerManager.StartTimer();
            isGameStarted = true;

            // Menyembunyikan panel main menu dan panel game mode
            mainMenuPanel.SetActive(false);
            gameModePanel.SetActive(false);
        }
    }

    public void StartGameModeMedium()
    {
        if (!isGameStarted)
        {
            // Setel mode permainan untuk Medium
            spawnManager.spawnRangeX = 20f;
            spawnManager.minSpawnPosZ = 115f;
            spawnManager.maxSpawnPosZ = 140f;
            spawnManager.minSpawnPosY = 13f;
            spawnManager.maxSpawnPosY = 22f;
            spawnManager.spawnInterval = 7f;
            spawnManager.despawnDelay = 6f;

            buffSpawnManager.spawnInterval = 5f;
            buffSpawnManager.despawnDelay = 5f;

            // Mulai permainan
            spawnManager.StartSpawning();
            buffSpawnManager.StartSpawning();
            timerManager.StartTimer();
            isGameStarted = true;

            // Menyembunyikan panel main menu dan panel game mode
            mainMenuPanel.SetActive(false);
            gameModePanel.SetActive(false);
        }
    }

    public void StartGameModeHard()
    {
        if (!isGameStarted)
        {
            // Setel mode permainan untuk Hard
            spawnManager.spawnRangeX = 30f;
            spawnManager.minSpawnPosZ = 120f;
            spawnManager.maxSpawnPosZ = 140f;
            spawnManager.minSpawnPosY = 15f;
            spawnManager.maxSpawnPosY = 25f;
            spawnManager.spawnInterval = 9f;
            spawnManager.despawnDelay = 5f;

            buffSpawnManager.spawnInterval = 7f;
            buffSpawnManager.despawnDelay = 3f;

            // Mulai permainan
            spawnManager.StartSpawning();
            buffSpawnManager.StartSpawning();
            timerManager.StartTimer();
            isGameStarted = true;

            // Menyembunyikan panel main menu dan panel game mode
            mainMenuPanel.SetActive(false);
            gameModePanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        // Ketika permainan berakhir, lakukan tindakan yang diperlukan
        spawnManager.StopSpawning();
        buffSpawnManager.StopSpawning();

        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over";

        int finalScore = scoreManager.Score;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore;
        }
        else
        {
            highScoreText.text = "High Score: " + highScore;
        }

        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public void RestartGame()
    {
        ResetGameplay();
        gameOverPanel.SetActive(false);
    }

    private void ResetGameplay()
    {
        timerManager.ResetTimer();
        scoreManager.ResetScore();

        mainMenuPanel.SetActive(true);
        isGameStarted = false;

        PlayerPrefs.Save();
    }
}
