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

    public static KeyCode? GetFromName(string name) {
        var st = typeof(KeyCode).GetEnumNames();
        int i =0;
        for (; i < st.Length; i++)
        {
            if(st[i].ToLowerInvariant() == name.ToLowerInvariant().Trim()) {
                i = -i;
                break;
            }
        }

        if(i < 0) {
            return (KeyCode)KeyCode.Parse(typeof(KeyCode),st[-i]);
        }

        return null;
    }


    public static KeyCode Up = KeyCode.UpArrow;

    public static KeyCode Down = KeyCode.DownArrow;


    public static KeyCode Left = KeyCode.LeftArrow;

    public static KeyCode Right = KeyCode.RightArrow;


    public static KeyCode Punch = KeyCode.F;

    public static KeyCode Shoot = KeyCode.T;


    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}