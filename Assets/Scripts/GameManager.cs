using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public int currentWave = 1;
    public PlayerController plyaerController;
    private static GameManager _instance;
    public GameObject panel;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (plyaerController.health <= 0)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    public void UpdateScore(int increment)
    {
        this.score += increment;

        if (score >= 6)  
        {
            
        }
    }


}
