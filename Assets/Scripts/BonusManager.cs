using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public bool isSpeedBonus = false;
    public bool isHealBonus = false;
    public float nextTime = 10;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            if (isSpeedBonus)
            {
                SpeedBonus();
            }

            else if (isHealBonus)
            {
                HealBonus();
            }
            nextTime = Time.time + 5;
        }

    }
    void SpeedBonus()
    {
        
    }
    void HealBonus()
    {
        
    }
    void RandomSpawnBonus()
    {
        
        Transform childTF;
        for (int i = 0; i < transform.childCount; i++)
        {
            childTF = transform.GetChild(i);
            SpriteRenderer childSpriteRenderer=childTF.GetComponent<SpriteRenderer>();
            if (childSpriteRenderer.enabled == false)
            {
                int isSpawn = Random.Range(0, 2);
                if (isSpawn == 1)
                {
                    childSpriteRenderer.enabled = true;
                    childTF.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }
    void CountTime()
    {
        
    }
}
