using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyhealth;
    public Slider EhealthSlider;
    float emaxHealth = 200;
    public Animator anim;
    public GameObject enemyRsword;
    public GameObject enemyLsword;
    void Start()
    {
        
    }

   
    void Update()
    {
        EhealthSlider.value = enemyhealth;
        if (enemyhealth >= 200)
        {
            enemyhealth = 200;
        }
    }

    public void eGetDamage(float amount)
    {
        enemyhealth -= amount;
             if (enemyhealth <= 0)
            {
               Debug.Log("Uwon");
              enemyRsword.SetActive(false);
              enemyLsword.SetActive(false);
               anim.SetTrigger("enemydie");
              StartCoroutine(enemydestroy());
            }
    }

    IEnumerator enemydestroy()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(this.gameObject);
    }
}
