using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }


    public static KeyCode Up = KeyCode.UpArrow;

    public static KeyCode Down = KeyCode.DownArrow;


    public static KeyCode Left = KeyCode.LeftArrow;

    public static KeyCode Right = KeyCode.RightArrow;


    public static KeyCode Punch = KeyCode.UpArrow;

    public static KeyCode Shoot = KeyCode.UpArrow;


    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
