using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CarController redCar, blueCar;
    public GameOverScreen GameOverScreen;

    [HideInInspector]
    public int scoreIndex;
    public TMP_Text scoreText;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        scoreIndex = 0;
        scoreText.text = scoreIndex.ToString();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.Setup(scoreIndex);
    }
}
