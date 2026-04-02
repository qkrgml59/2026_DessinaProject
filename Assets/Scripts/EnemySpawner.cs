using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRange = 13f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnposiiton = GetRandomEdgePosition();
        Instantiate(enemyPrefab, spawnposiiton, Quaternion.identity);

    }

    Vector3 GetRandomEdgePosition()
    {
        int side = Random.Range(0, 4);

        float x = 0f;
        float z = 0f;

        switch(side)
        {
            case 0:
                x = Random.Range(-spawnRange, spawnRange);
                z = spawnRange;
                break;
            case 1:
                x = Random.Range(-spawnRange, spawnRange);
                z = -spawnRange;
                break;
            case 2:
                x = spawnRange;
                z = Random.Range(-spawnRange, spawnRange);
                    break;
            case 3:
                x = -spawnRange;
                z = Random.Range(-spawnRange, spawnRange);
                break;
        }
        return new Vector3(x, 0.5f, z);
    }
}
