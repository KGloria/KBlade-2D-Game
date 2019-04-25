using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    private float damageVal = 50;
    public GameObject sprite;
    private float currHealth;
    public bool movement;

    private float latestDirChTime;
    private readonly float directinChangeTime = 3f;
    private float characterVel = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        latestDirChTime = 0f;
        CalcNewMoveVec();
        currHealth = health;
    }

    void CalcNewMoveVec()
    {
        movementDirection = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;
        movementPerSecond = movementDirection * characterVel;
    }

    private void moveEnemy()
    {
        if (movement == true)
        {
            if (Time.time - latestDirChTime > directinChangeTime)
            {
                latestDirChTime = Time.time;
                CalcNewMoveVec();
            }

            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();

        if (this.currHealth <= 0)
        {
            Destroy(this.gameObject, 0.3f);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("Enemy"))
            {
                this.currHealth -= damageVal;
            }
        }

    }

}

   
