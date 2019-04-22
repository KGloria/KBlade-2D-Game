using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{

    public int SkillPts;
    public int ExpPoints;

    private int Atk;
    private int Def;
    private int Str;
    private int Special;

    private int HitPoints = 100;
    private int BossHP;
    public float enemyHealth;

    // Start is called before the first frame update
    void newGame()
    {
        SkillPts = 0;
        ExpPoints = 0;
        Atk = 0;
        Def = 0;
        Str = 0;
        Special = 0;

    }

    void setHP(int num)
    {
        BossHP = num;
    }

    public void dealDmg()
    {
        int dmg = calcDMG();
        enemyHealth -= dmg;
        if (enemyHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(HitPoints <= 0)
        {
            //insert game over screen
        }

        if(BossHP <= 0)
        {
            //fetch next scene
        }

    }



    public void SkillPtsup(bool leveld)
    {
        if (leveld == true) SkillPts += 2;
    }

    public void incStat(int Stattype)
    {
        if (Stattype == 1) Atk += 1;
        else if (Stattype == 2) Def += 1;
        else if (Stattype == 3) Str += 1;
        else if (Stattype == 4) Special += 1;
    }

    int calcDMG()
    {
        Random random = new Random();
        return (int)random.Next(0 + Str, 3 + Atk);
    }
}
