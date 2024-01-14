using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider sliderHealth;
    public Slider sliderShield;

    public void SetMaxHealth(float health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }
    
    public void SetHealth(float health)
    {
        sliderHealth.value = health;
    }
    public void SetShield(float shield)
    {
        sliderShield.value = shield;
    }
}
