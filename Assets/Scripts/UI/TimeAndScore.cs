using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndScore : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text timeText;
    public Text MaxTime;
    public int contadorScore = 0;
    private int highScore = 0;
    private int time = 0;
    private int contadorTime = 0;
    public int coinScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        ActualizarPuntajes();
    }

    private void Update()
    {
        contadorScore = (int)(Time.time) + coinScore;
        contadorTime = (int)(Time.time);
        if (contadorTime > time)
        {
            time = contadorScore;
            PlayerPrefs.SetInt("MaxTime", highScore);
            PlayerPrefs.Save();
        }
        if (contadorScore > highScore)
        {
            highScore = contadorScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        ActualizarPuntajes();
    }

    private void ActualizarPuntajes()
    {
        timeText.text = "Tiempo: " + contadorScore.ToString("D");
        scoreText.text = "Puntaje: " + contadorScore.ToString("D");
        highScoreText.text = "Puntaje más alto: " + highScore.ToString("D");
        MaxTime.text = "El tiempo máximo fue de: " + time.ToString("D");
    }

    public void ActiveScreen()
    {
        gameObject.SetActive(true);
    }

    public void DisableScreen()
    {
        gameObject.SetActive(false);
    }

    public void AddScore(int score)
    {
        contadorScore += score;
    }
}
