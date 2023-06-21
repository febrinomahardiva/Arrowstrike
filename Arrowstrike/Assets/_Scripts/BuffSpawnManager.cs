using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnManager : MonoBehaviour
{
    public GameObject[] buffPrefabs; // Array prefab objek buff
    public float spawnRangeX = 20f; // Rentang spawn pada sumbu X
    public float minSpawnPosZ = 115f; // Posisi minimal spawn pada sumbu Z
    public float maxSpawnPosZ = 140f; // Posisi maksimal spawn pada sumbu Z
    public float minSpawnPosY = 13f; // Posisi minimal spawn pada sumbu Y
    public float maxSpawnPosY = 22f; // Posisi maksimal spawn pada sumbu Y
    public float spawnInterval = 8f; // Interval waktu antara spawn objek buff
    public float despawnDelay = 3f; // Waktu sebelum objek menghilang

    private bool isSpawning = false; // Flag untuk mengetahui apakah spawning sedang berlangsung

    private TimerManager timerManager; // Reference ke TimerManager untuk mengakses fungsi penambahan waktu

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnBuffs());
        }
        timerManager = FindObjectOfType<TimerManager>(); // Menemukan instance TimerManager
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(SpawnBuffs());
    }

    private IEnumerator SpawnBuffs()
    {
        while (isSpawning)
        {
            int buffCount = Random.Range(1, 3); // Jumlah buff yang akan di-spawn dalam interval ini

            for (int i = 0; i < buffCount; i++)
            {
                // Randomly generate buff spawn position
                Vector3 buffSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX) + 70f, Random.Range(minSpawnPosY, maxSpawnPosY), Random.Range(minSpawnPosZ, maxSpawnPosZ));
                int buffIndex = Random.Range(0, buffPrefabs.Length);

                // Menginstansiasi objek buff pada posisi acak
                GameObject spawnedBuff = Instantiate(buffPrefabs[buffIndex], buffSpawnPos, buffPrefabs[buffIndex].transform.rotation);

                // Menghancurkan buff setelah jangka waktu tertentu
                Destroy(spawnedBuff, despawnDelay);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
