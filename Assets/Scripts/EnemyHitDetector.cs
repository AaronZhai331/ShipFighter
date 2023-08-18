using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitDetector : MonoBehaviour
{

    protected GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);

            this.gameManager.UpdateScore(1);
        }

    }
}
