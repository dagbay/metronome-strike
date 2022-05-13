using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  Main Health GUI script Created By Jason Stark
public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    // Start is called before the first frame update
  public void SetHealth(int health)
  {
       slider.value = health;

  }
}
