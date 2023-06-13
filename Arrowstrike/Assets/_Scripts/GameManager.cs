using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public TimerManager timerManager;
    public ScoreManager scoreManager; // Tambahkan referensi ke ScoreManager
    public SpawnManager spawnManager;
    public GameObject mainMenuPanel; // Referensi ke panel main menu
    public GameObject gameModePanel; // Referensi ke panel game mode
    public GameObject gameOverPanel; // Referensi ke panel game over
    public TextMeshProUGUI gameOverText; // Referensi ke komponen TextMeshProUGUI pada panel game over
    public TextMeshProUGUI highScoreText; // Referensi ke komponen TextMeshProUGUI untuk menampilkan skor tertinggi
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

            // Mulai permainan
            spawnManager.StartSpawning();
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
            spawnManager.spawnInterval = 5f;
            spawnManager.despawnDelay = 6f;

            // Mulai permainan
            spawnManager.StartSpawning();
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
            spawnManager.spawnInterval = 4f;
            spawnManager.despawnDelay = 5f;

            // Mulai permainan
            spawnManager.StartSpawning();
            timerManager.StartTimer();
            isGameStarted = true;

            // Menyembunyikan panel main menu dan panel game mode
            mainMenuPanel.SetActive(false);
            gameModePanel.SetActive(false);
        }
    }

public void GameOver()
{
    // Ketika permainan berakhir, lakukan tindakan yang diperlukan, misalnya:
    // Menghentikan spawning
    spawnManager.StopSpawning();

    // Menampilkan panel game over
    gameOverPanel.SetActive(true);

    // Mengatur teks pada panel game over
    gameOverText.text = "Game Over";

    // Memeriksa skor akhir dengan skor tertinggi
    int finalScore = scoreManager.Score; // Mengakses properti Score dari ScoreManager
    int highScore = PlayerPrefs.GetInt("HighScore", 0);
    if (finalScore > highScore)
    {
        // Jika skor akhir lebih tinggi dari skor tertinggi sebelumnya, perbarui skor tertinggi dan tampilkan pesan
        highScore = finalScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        highScoreText.text = "High Score: " + highScore;
    }
    else
    {
        // Jika skor akhir tidak melebihi skor tertinggi, tampilkan skor tertinggi yang ada
        highScoreText.text = "High Score: " + highScore;
    }

    // Simpan nilai High Score
    PlayerPrefs.SetInt("HighScore", highScore);
    PlayerPrefs.Save();
}




    public void RestartGame()
    {
        // Memanggil metode ResetGameplay untuk mereset hanya mekanik gameplay
        ResetGameplay();

        // Menyembunyikan panel game over
        gameOverPanel.SetActive(false);
    }

    private void ResetGameplay()
    {
        // Mengatur ulang nilai-nilai gameplay seperti score, game mode, dan timer
        timerManager.ResetTimer();
        scoreManager.ResetScore();
        // Reset nilai-nilai lain yang perlu di-reset seperti score
        // ...

        // Menampilkan panel main menu dan panel game mode
        mainMenuPanel.SetActive(true);

        isGameStarted = false;

    // Menghapus PlayerPrefs "HighScore"
    // PlayerPrefs.DeleteKey("HighScore");
    PlayerPrefs.Save();
    }
}
