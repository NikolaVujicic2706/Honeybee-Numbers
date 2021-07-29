using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject EnemyPrefab;
    private float timeToSpawn = 2f;
    private float timeBetweenSpawns = 2f;
    private Enemy enemy;
    public TextMeshProUGUI textMP;

    private void Awake()

    {
        enemy = EnemyPrefab.GetComponent<Enemy>();
        textMP = EnemyPrefab.GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnEnemies();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }
       

    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                textMP.text = Random.Range(2,10).ToString();
                Instantiate(EnemyPrefab, spawnPoints[i].position, Quaternion.identity);
                
            }
        }
    }
}
