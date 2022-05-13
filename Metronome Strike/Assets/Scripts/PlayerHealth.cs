using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a temp player health script to test out the GUI function
// created by Jason Stark on 8/05/ 2022
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public  int currentHealth;

    public HealthBarScript healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

               TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
