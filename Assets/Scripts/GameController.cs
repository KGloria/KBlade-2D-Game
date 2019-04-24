using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject Boss;
    public Vector3 spawnValues;
    private float monsterHeath;

    private int score = 0;
    private float health;
    private bool gameover;

    private void Awake()
    {
        gameover = false;
        health = 100;
    }

    private void Start()
    {
        InvokeRepeating("spawnEnemies", 3.0f, Random.Range(5.0f, 7.0f));
        InvokeRepeating("spawnBoss", 16.0f, Random.Range(25.0f, 30.0f));
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameover = true;
        }
    }

    void spawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = new Quaternion();
        GameObject clone = Instantiate(hazard, spawnPosition, spawnRotation);
    }

    void spawnBoss()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = new Quaternion();
        Instantiate(Boss, spawnPosition, spawnRotation);
    }

}
