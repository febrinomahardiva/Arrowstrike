using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   
    public GameObject[] animalPrefabs; // Array prefab objek hewan
    public float spawnRangeX = 20f; // Rentang spawn pada sumbu X
    public float minSpawnPosZ = 115f; // Posisi minimal spawn pada sumbu Z
    public float maxSpawnPosZ = 140f; // Posisi maksimal spawn pada sumbu Z
    public float minSpawnPosY = 13f; // Posisi minimal spawn pada sumbu Y
    public float maxSpawnPosY = 22f; // Posisi maksimal spawn pada sumbu Y
    public float spawnInterval = 2f; // Interval waktu antara spawn objek
    public float despawnDelay = 3f; // Waktu sebelum objek menghilang

    private void Start()
    {
        // Memulai coroutine untuk melakukan spawn otomatis
        StartCoroutine(SpawnObjects());

    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Menunggu selama interval waktu sebelum melakukan spawn objek
            yield return new WaitForSeconds(spawnInterval);

            int spawnCount = Random.Range(1, 3); // Jumlah target yang akan di-spawn (1 atau 2)

            for (int i = 0; i < spawnCount; i++)
            {
                // Randomly generate animal index dan spawn position
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX) + 70f, Random.Range(minSpawnPosY, maxSpawnPosY), Random.Range(minSpawnPosZ, maxSpawnPosZ));
                int animalIndex = Random.Range(0, animalPrefabs.Length);

                // Menginstansiasi objek hewan pada posisi acak
                GameObject spawnedAnimal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

                // Menghancurkan objek setelah jangka waktu tertentu
                Destroy(spawnedAnimal, despawnDelay);
            }
            
        }
    }
}
