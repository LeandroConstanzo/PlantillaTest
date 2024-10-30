using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Prefab del enemigo que se spawnear�
    public GameObject enemyPrefab;

    // Tiempo entre cada spawneo de enemigos
    public float spawnInterval = 2.0f;

    // N�mero de enemigos a spawnear
    public int enemyCount = 10;

    // Rango de la distancia a la que los enemigos pueden spawnearse desde el centro
    public float spawnRadius = 5.0f;

    // La posici�n central donde los enemigos ser�n generados alrededor
    public Vector3 spawnCenter = Vector3.zero;

    // Comenzar el spawneo al iniciar el juego
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Corrutina que controla el spawneo de enemigos
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // M�todo para spawnear un solo enemigo
    private void SpawnEnemy()
    {
        // Generar una posici�n aleatoria dentro del rango
        Vector3 spawnPosition = spawnCenter + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0; // Asegurarse de que los enemigos se generen en el suelo si es necesario

        // Crear el enemigo en la posici�n generada
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
