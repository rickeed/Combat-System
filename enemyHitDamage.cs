using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitDamage : MonoBehaviour
{
    public playerHealth pHealthsc;
    public Animator anim;

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealthsc.GetDamage(10);
            
            StartCoroutine(endhit());
        }


            
        
    }

    public void hit()
    {
        pHealthsc.GetDamage(10);
        anim.SetBool("playerhitReact", true);
        StartCoroutine(endhit());
    }

    IEnumerator endhit()
    {
        yield return new WaitForSecondsRealtime(0.10f);
        anim.SetBool("playerhitReact", false);
    }
}
