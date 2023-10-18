using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ıkLook : MonoBehaviour
{
    float weight = 0.6f;
    Animator anim;
    Camera maincam;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        maincam = Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weight, .2f, 0.8f, 0.5f, 0.5f);
        Ray lookAtRay = new Ray(transform.position, maincam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }

    public void on()
    {
        weight = Mathf.Lerp(weight, 1f, Time.deltaTime);
    }
    public void of()
    {
        weight = Mathf.Lerp(weight, 0, Time.deltaTime);
    }
}
