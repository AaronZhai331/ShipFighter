using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public TextMeshPro scoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    private PlayerController _playerController;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("{0}{1}","Score: " , GameManager.Instance.score.ToString());
        waveText.text = string.Format("{0}{1}","Wave: " , GameManager.Instance.currentWave.ToString());
        slider.value = _playerController.health;
    }
}
