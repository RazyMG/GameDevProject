using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool paused;
    public Player player;
    private void Start()
    {
        pauseMenu.SetActive(false);
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                pauseMenu.SetActive(false);
                paused = false;
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.SetActive(true);
                paused = true;
                Time.timeScale = 0f;
            }
        }
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        paused = false;
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }



}
