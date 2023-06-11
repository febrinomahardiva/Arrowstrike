using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] targetPrefabs; // Array prefab objek target
    public float spawnRangeX = 20f; // Rentang spawn pada sumbu X
    public float minSpawnPosZ = 115f; // Posisi minimal spawn pada sumbu Z
    public float maxSpawnPosZ = 140f; // Posisi maksimal spawn pada sumbu Z
    public float minSpawnPosY = 13f; // Posisi minimal spawn pada sumbu Y
    public float maxSpawnPosY = 22f; // Posisi maksimal spawn pada sumbu Y
    public float spawnInterval = 2f; // Interval waktu antara spawn objek
    public float despawnDelay = 3f; // Waktu sebelum objek menghilang

    private bool isSpawning = true; // Flag untuk mengetahui apakah spawning sedang berlangsung

    private void Start()
    {
        // Tidak memulai spawning secara otomatis
    }

    private IEnumerator SpawnObjects()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnInterval);

            int spawnCount = Random.Range(1, 4); // Jumlah target yang akan di-spawn (1 atau 3)

            for (int i = 0; i < spawnCount; i++)
            {
                // Randomly generate target index dan spawn position
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX) + 70f, Random.Range(minSpawnPosY, maxSpawnPosY), Random.Range(minSpawnPosZ, maxSpawnPosZ));
                int targetIndex = Random.Range(0, targetPrefabs.Length);

                // Menginstansiasi objek target pada posisi acak
                GameObject spawnedTarget = Instantiate(targetPrefabs[targetIndex], spawnPos, targetPrefabs[targetIndex].transform.rotation);

                // Menghancurkan objek setelah jangka waktu tertentu
                Destroy(spawnedTarget, despawnDelay);
            }
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnObjects());
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
