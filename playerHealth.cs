using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public Slider healthSlider;
    float maxHealth = 100;
    void Update()
    {
        healthSlider.value = health;

        if(health>= 100)
        {
            health = 100;
        }
    }
    public void GetDamage(float amount)
    {
        health -= amount;
        
        if(health <= 0)
        {
            Debug.Log("diemfDIE");
        }
    }
}
