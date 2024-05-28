using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private PlayerDatas playerDatas;
    [SerializeField] private Sprite MusicOn, MusicOff,SoundOn,SoundOff;
    [SerializeField] private AudioSource Sound, music;
    private Image image;
   public void LevelsButton() 
   {
        SceneManager.LoadScene("Levels");
   }
   public void SoundButton() 
   {
        ControlSound(); 
   }
   public void MusicButton() 
   {
       ControlMusic();
   }
   public void AchivementButton() 
   {
        SceneManager.LoadScene("Achivements");
   }
   public void EndlessButton()
   {
        SceneManager.LoadScene("SampleScene");
   }
   public void BacktoMenu() 
   {
        SceneManager.LoadScene("MainManu");
   }

    private void Start()
    {
        image = GetComponent<Image>();
        playerDatas.MusicOn = true;
        playerDatas.SoundOn = true;
        
    }

    public void ControlMusic()
    {
        if (playerDatas.MusicOn)
        {
            image.sprite = MusicOff;
            playerDatas.MusicOn = false;
            music.Pause();  
        }
        else
        {
            image.sprite = MusicOn;
            playerDatas.MusicOn=true;
            music.UnPause();
        }

    }
    public void ControlSound()
    {
        if (playerDatas.SoundOn)
        {
            image.sprite=SoundOff;
            playerDatas.SoundOn = false;
        }
        else
        {
            image.sprite = SoundOn;
            playerDatas.SoundOn = true;
        }
    }
}
