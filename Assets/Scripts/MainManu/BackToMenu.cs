using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] PlayerDatas playerDatas;
    [SerializeField] private GameObject Esc;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowEsc();
    }
    private void ShowEsc()
    {
        playerDatas.EscOpened = !playerDatas.EscOpened;
        if (playerDatas.EscOpened)
        {
            TogglePause();
            Esc.SetActive(true);
        }
        else
        {
            TogglePause();
            Esc.SetActive(false);
        }
    }
    public void CloseEsc()
    {
        TogglePause();
        playerDatas.EscOpened = false;
        Esc.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void TogglePause()
    {
        playerDatas.isPaused = !playerDatas.isPaused;
        if (playerDatas.isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
