using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 100;
    private float damageVal = 50;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            health -= damageVal;
        }

        if (health <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }

}
