using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public ControlMirarCamara controlCamera;

    private void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;

        controlCamera.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
