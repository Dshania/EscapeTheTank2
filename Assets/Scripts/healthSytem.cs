using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSytem : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    private void Update()
    {



    }
}
