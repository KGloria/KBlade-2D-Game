using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Minion : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireballSpawn;
    public Rigidbody2D player;
    public float fireballSpeed;

    public AudioClip EnemySound;
    public AudioSource MyAudioSrc;

    private void Start()
    {
        MyAudioSrc.clip = EnemySound;
        MyAudioSrc.playOnAwake = false;

        Invoke("ShootFireBall", Random.Range(0.0f, 8.0f));
        InvokeRepeating("ShootFireBall", Random.Range(0.0f, 15.0f), Random.Range(4.0f, 10.0f));
    }

    private void Update()
    {
    }

    public void ShootFireBall()
    {
        var acannonBall = Instantiate(fireball, fireballSpawn.transform.position, Quaternion.identity);
        Rigidbody2D fireBallRigidBody = acannonBall.GetComponent<Rigidbody2D>();
        fireBallRigidBody.velocity = Quaternion.Euler(0, 0, 90) * Vector3.right * fireballSpeed;
        MyAudioSrc.Play();
    }

}
