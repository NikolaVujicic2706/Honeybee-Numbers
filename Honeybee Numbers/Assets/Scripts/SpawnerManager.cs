using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerManager : MonoBehaviour
{
    
    private float timeToSpawn = 1f;
    private float timeBetweenSpawns = 5f;
    private Color randomColor;
    private readonly int[] muliplicationNumbers = {4,6,8,9,10,12,14,15,18,20,
                                                  21,24,25,27,28,30,32,35,36,40,
                                                  42,45,48,49,54,56,63,64,72,81};
    public TextMeshProUGUI textMP;
    public Transform[] spawnPoints;
    public GameObject EnemyPrefab;
   


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
        int randomIndex = Random.Range(0, 9);

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
                //textMP.text = Random.Range(2, 10).ToString();
                textMP.text = GenerateRandomNumber(muliplicationNumbers).ToString();
                GameObject spawnedEnemy = Instantiate(EnemyPrefab, spawnPoints[i].position, Quaternion.identity);
                spawnedEnemy.GetComponent<SpriteRenderer>().material.SetColor("_Color", randomColor);
            }
        }
    }

    private int GenerateRandomNumber(int[] numbers)
    {
        int randomNumber = Random.Range(0, numbers.Length);
        return numbers[randomNumber];
    }
}
