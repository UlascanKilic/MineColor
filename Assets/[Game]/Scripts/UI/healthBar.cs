using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image border;
    public Image hearth;
    private int maxHealth;
 
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        maxHealth = health;
        fill.color = gradient.Evaluate(1f);
        border.color = gradient.Evaluate(1f);
        hearth.color = gradient.Evaluate(1f);
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        border.color = gradient.Evaluate(slider.normalizedValue);
        hearth.color = gradient.Evaluate(slider.normalizedValue);
    }
}
