using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider Health;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        Health.value = CalcHealth();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "fireball")
        {
            DealDamage(2);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "tentacle")
        {
            DealDamage(8);
            Destroy(collision.gameObject);
        }
    }

    void DealDamage(float dmg)
    {
        CurrentHealth -= dmg;
        Health.value = CalcHealth();
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    float CalcHealth() => CurrentHealth / MaxHealth;

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("Player has Died.");
        SceneManager.LoadScene(6);
    }
}
