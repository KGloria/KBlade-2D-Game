using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Boss;
    public Vector3 spawnValues;
    public GameObject hazard;
    [SerializeField] Text scoreText;
    public int _score;
    private float count;
    private float div;
    private bool nexWave;

    private float health;
    public AudioClip Music;
    public AudioSource MyAudioSrc;

    private void Start()
    {
        MyAudioSrc.clip= Music;
        MyAudioSrc.playOnAwake = false;
        _score = 0;
        count = 0;
        div = 1;
        nexWave = false;
        scoreText.text = "TimeScore = 0";
        InvokeRepeating("spawnEnemies", 3.0f, Random.Range(5.0f, 7.0f));
        InvokeRepeating("spawnBoss", 16.0f, Random.Range(25.0f, 30.0f));
        MyAudioSrc.Play();
    }

    private void Update()
    {
        if (50 < _score && nexWave == false)
        {
            InvokeRepeating("spawnEnemies", 3.0f, Random.Range(1.5f, 3.0f));
            InvokeRepeating("spawnBoss", 6.0f, Random.Range(12.0f, 16.0f));
            nexWave = true;
        }

        if (80 < _score && nexWave == true)
        {
            InvokeRepeating("spawnEnemies", 2.0f, Random.Range(2.0 f, 3.0f));
            InvokeRepeating("spawnBoss", 2.0f, Random.Range(4.0f, 7.0f));
            nexWave = true;
        }
        count += 1;
        if (count >= div)
        {
            _score += (int) (count / div);
            count = 0;
            div += 2;
        }
        scoreText.text = "TimeScore = " + _score;
    }

    void spawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = new Quaternion();
        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    void spawnBoss()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = new Quaternion();
        Instantiate(Boss, spawnPosition, spawnRotation);
    }

}
