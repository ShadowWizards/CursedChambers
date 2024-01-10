using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider,_sfxSlider;
    public void ToggleMusic(){
        AudioMenager.Instance.ToggleMusic();
    }
   public void ToggleSFX(){
    AudioMenager.Instance.ToggleSFX();
   }
   public void MusicVolume(){
    AudioMenager.Instance.MusicVolume(_musicSlider.value);
   }
   public void SFXVolume(){
    AudioMenager.Instance.SFXVolume(_sfxSlider.value);
   }
}
