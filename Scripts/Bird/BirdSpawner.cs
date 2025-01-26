using System.Collections;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject[] birdPrefabs;
    public float minSpawnTime = 1f; 
    public float maxSpawnTime = 5f; 

    private bool gameIsRunning = true; 
    

    void Start()
    {
        StartCoroutine(SpawnBirdsContinuously());
    }

    IEnumerator SpawnBirdsContinuously()
    {
        while (gameIsRunning) 
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnBird();
        }
    }

    void SpawnBird()
    {
        if (birdPrefabs.Length == 0) return; 

        int randomIndex = Random.Range(0, birdPrefabs.Length);
        GameObject selectedPrefab = birdPrefabs[randomIndex];

        Vector3 spawnPosition = GetRandomPositionInBox();

        Vector3 spawnDirection = Vector3.forward;

        Quaternion spawnRotation = Quaternion.LookRotation(spawnDirection) * Quaternion.Euler(0, 180, 0);

        Instantiate(selectedPrefab, spawnPosition, spawnRotation);

    }

    Vector3 GetRandomPositionInBox()
    {
        Vector3 boxSize = transform.localScale;

        float randomX = Random.Range(-boxSize.x / 2, boxSize.x / 2);
        float randomY = Random.Range(-boxSize.y / 2, boxSize.y / 2);
        float randomZ = Random.Range(-boxSize.z / 2, boxSize.z / 2);

        return transform.position + new Vector3(randomX, randomY, randomZ);
    }

    public void StopSpawning()
    {
        gameIsRunning = false;
    }

   
}
