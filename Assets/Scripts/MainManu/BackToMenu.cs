using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private GameObject Esc;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowEsc();
    }
    private void ShowEsc()
    {
        Esc.SetActive(true);
    }
    public void CloseEsc()
    {
        Esc.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
