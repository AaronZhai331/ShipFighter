using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public bool isSpeedBonus = false;
    public bool isHealBonus = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeedBonus)
        {
            SpeedBonus();
        }

        else if (isHealBonus)
        {
            HealBonus();
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
