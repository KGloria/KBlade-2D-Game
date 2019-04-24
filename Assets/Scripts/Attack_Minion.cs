using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Minion : MonoBehaviour
{
    public Rigidbody2D fireball;
    public Rigidbody player;
    public float fireballSpeed = 8f;

    private void Update()
    {
        instFireball();

    }

    private void instFireball()
    {
        var fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector2(0, 0)));
        fireballInst.velocity = new Vector2(fireballSpeed, 0);
    }


    private void OnTriggerEnter2D(Rigidbody2D collision)
    {
        Destroy(collision.gameObject);
    }

}
