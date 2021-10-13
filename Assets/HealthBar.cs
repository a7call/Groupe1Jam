using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    
    private void Update()
    {
    }
    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        print(slider.maxValue);
    }
}
