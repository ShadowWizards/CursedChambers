using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // References
    public Slider sliderHealth;
    public Slider sliderShield;

    // Sets a max health for the slider
    public void SetMaxHealth(float health)
    {
        if(sliderHealth.value > health)
            sliderHealth.value = health;
        
        sliderHealth.maxValue = health;

        if(sliderHealth.value <= health)
            SetHealth(sliderHealth.value);
    }
    
    // Sets the current health for the slider
    public void SetHealth(float health)
    {
        sliderHealth.value = health;
    }
    // Sets the current shield for the slider
    public void SetShield(float shield)
    {
        sliderShield.value = shield;
    }
}
