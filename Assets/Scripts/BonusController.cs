using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public static event Action TriggerBonus;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (this.CompareTag("HealthTag"))
            {
                other.GetComponent<PlayerController>().health += 10;
            }
            if (this.CompareTag("SpeedTag"))
            {
                other.GetComponent<PlayerController>().moveSpeed += 40;
                StartCoroutine(SetSpeedNormal(other));

            }
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator SetSpeedNormal(Collider2D other)
    {
        yield return new WaitForSeconds(7);
        other.GetComponent<PlayerController>().moveSpeed = 80;
    }
}
