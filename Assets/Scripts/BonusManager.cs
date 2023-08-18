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
        //spawn bonus after 5 seconds
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
        RandomSpawnBonus();
    }
    void HealBonus()
    {
        RandomSpawnBonus();
    }
    void RandomSpawnBonus()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childGameObject = transform.GetChild(i).GetComponent<GameObject>();
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
