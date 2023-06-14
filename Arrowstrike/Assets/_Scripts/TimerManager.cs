using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeLimit = 60f; // Batas waktu dalam detik
    private float currentTime = 0f;
    private bool isTimerRunning = false;

    public TextMeshProUGUI timerText; // Reference ke UI TextMeshProUGUI untuk menampilkan waktu

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                GameOver();
            }

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        UpdateTimerText();
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "" + Mathf.CeilToInt(currentTime);
        }
    }

    private void GameOver()
    {
        StopTimer();
        GameManager.Instance.GameOver(); // Memanggil metode GameOver() dari GameManager
    }
}
