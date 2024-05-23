using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
public class RegenerativeHealth : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public Image fillImage;
    public int healthregenamount;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;

     

            
        

    }

    private void Update()
    {
        if (slider.value < slider.maxValue)
        {
            healthregenamount = 5;
            slider.value += healthregenamount * Time.deltaTime;
        }
        else if (slider.value > slider.maxValue)
        {
            healthregenamount = 0; 
        }
        else if (slider.value == 0f)
        {
            slider.value = 0f;
            healthregenamount = 0;
        }

        if (slider.value < 100 && slider.value > 50)
        {
            fillImage.color = Color.Lerp(Color.green, Color.green, slider.value / 100);
        }
        if (slider.value < 50 && slider.value > 25)
        {
            fillImage.color = Color.Lerp(Color.yellow, Color.red, slider.value / 100);
        }
        if (slider.value < 25)
        {
            fillImage.color = Color.Lerp(Color.red, Color.red, slider.value / 100);

        }
    }
}
