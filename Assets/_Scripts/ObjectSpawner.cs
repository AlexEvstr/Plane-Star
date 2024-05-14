using UnityEngine;

public class InfiniteObjectSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject lifeBonusPrefab;
    public GameObject coinPrefab;

    private float spawnX = 4.0f;
    private float minY = -4.0f;
    private float maxY = 4.0f;
    private float spawnInterval = 1.0f; // Интервал между спавнами

    void Start()
    {
        // Начинаем бесконечный спавн объектов
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    void SpawnObject()
    {
        GameObject objectToSpawn = GetRandomObject();
        Vector2 spawnPosition;
        bool validPosition;

        do
        {
            validPosition = true;
            float randomY = Random.Range(minY, maxY);
            spawnPosition = new Vector2(spawnX, randomY);

            // Проверка на перекрытие других объектов
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f);
            if (colliders.Length > 0)
            {
                validPosition = false;
            }
        } while (!validPosition);

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    GameObject GetRandomObject()
    {
        float rand = Random.value;
        if (rand < 0.5f)
        {
            return enemyPrefab;
        }
        else if (rand < 0.9f)
        {
            return coinPrefab;
        }
        else
        {
            return lifeBonusPrefab;
        }
    }
}
