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
    public TextMeshProUGUI textMP;
    private Color randomColor;


    private void Awake()

    {
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
                randomColor = new Color(
                                     Random.Range(0f, 1f), //Red
                                     Random.Range(0f, 1f), //Green
                                     Random.Range(0f, 1f),//Blue
                                     1 //Alpha (transparency)
                                     );
                textMP.text = Random.Range(2, 10).ToString();
                GameObject spawnedEnemy = Instantiate(EnemyPrefab, spawnPoints[i].position, Quaternion.identity);
                spawnedEnemy.GetComponent<SpriteRenderer>().material.SetColor("_Color", randomColor);
            }
        }
    }
}
