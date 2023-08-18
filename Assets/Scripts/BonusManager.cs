using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusManager : MonoBehaviour
{
    public bool isSpeedBonus = false;
    public bool isHealBonus = false;
    public float nextTime = 10;
    private GameObject[] _bonusGO=new GameObject[4];


    private void Awake()
    {
        for (int i = 0; i < _bonusGO.Length; i++)
        {
            _bonusGO[i] = transform.GetChild(i).gameObject;
            _bonusGO[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawn bonus after 5 seconds
        if (Time.time > nextTime)
        {
            if (isSpeedBonus)
            {
                
                SpeedBonusSpawn();
            }

            else if (isHealBonus)
            {
                
                HealBonusSpawn();
            }
            nextTime = Time.time + 5;
        }

    }
    void SpeedBonusSpawn()
    {
        RandomSpawnBonus();
    }
    void HealBonusSpawn()
    {
        RandomSpawnBonus();
    }
    void RandomSpawnBonus()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childGameObject = _bonusGO[i];
            if (childGameObject.activeSelf==false)
            {
                int isSpawn = Random.Range(0, 2);
                if (isSpawn == 1)
                {
                    childGameObject.SetActive(true);
                }
            }
        }
    }
    

}
