using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatcontroller : MonoBehaviour
{
    
    bool isStafe = false;
    bool canAttack = true;
    bool canBlock = false;
    bool isBlock = false;
    Animator anim;
    public GameObject HandSword;
    public GameObject BackSword;
    public GameObject trail;
    public GameObject rjattackTrail;
    public GameObject rjAttackTrigger;
    charcont charcontt;
    public GameObject swordhitTrigger;
    public GameObject blockhit;
    public GameObject enemyswordhittr;
    void Start()
    {
        anim = GetComponent<Animator>();
        charcontt = GetComponent<charcont>();
        trailOf();
        rjTrailOf();
    }

    
    void Update()
    {
        anim.SetBool("is", isStafe);
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStafe = !isStafe;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && isStafe == true && canAttack == true)
        {
          
            anim.SetTrigger("attack");
        }

        if(isStafe == true)
        {
            GetComponent<ıkLook>().of();
            canBlock = true;
            
        }
        if (isStafe == false)
        {
            GetComponent<ıkLook>().on();
        }
        if (Input.GetKey(KeyCode.Mouse1)&& canBlock == true && isStafe == true)
        {
            anim.SetBool("blockk", true);
            anim.SetTrigger("block");
            isBlock = true;
            blockhit.SetActive(false);
            enemyswordhittr.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Mouse1)&& isBlock==true)
        {
            anim.SetBool("blockk", false);
            blockhit.SetActive(true);
            enemyswordhittr.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q)  && isStafe == true)
        {
            anim.SetTrigger("RJattack");
        }


    }
    
    public void equıp()
    {
        BackSword.SetActive(false);
        HandSword.SetActive(true);
    }

    public void unEquıp()
    {
        BackSword.SetActive(true);
        HandSword.SetActive(false);
    }

    public void trailOn()
    {
        for(int i = 0; i < trail.transform.childCount; i++)
        {
            trail.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = true;
            swordhitTrigger.SetActive(true);
            enemyswordhittr.SetActive(false);
        }
        
    }
    public void trailOf()
    {
        for (int i = 0; i < trail.transform.childCount; i++)
        {
            trail.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = false;
            swordhitTrigger.SetActive(false);
            enemyswordhittr.SetActive(true);
        }
    }

    public void rjTrailOn()
    {
        for (int i = 0; i < rjattackTrail.transform.childCount; i++)
        {
            trail.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = true;
        }
        rjAttackTrigger.SetActive(true);
    }
    public void rjTrailOf()
    {
        for (int i = 0; i < rjattackTrail.transform.childCount; i++)
        {
            trail.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = false;
        }

        rjAttackTrigger.SetActive(false);
    }
}
