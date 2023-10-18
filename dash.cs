using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rig;
    bool isDashing;
    public GameObject dashEF;
    bool cantdash;
    public GameObject DashEffect;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && !cantdash)
        {
            isDashing = true;
        }
        if (isDashing)
        {
            dashles();
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            dashles();
        }
    }
    public void dashles()
    {
        rig.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        isDashing = false;
        GameObject effect = Instantiate(dashEF, Camera.main.transform.position, dashEF.transform.rotation);
        effect.transform.parent = Camera.main.transform;
        effect.transform.LookAt(transform);
        StartCoroutine(cantDashh());
    }
    IEnumerator cantDashh()
    {
        cantdash = true;
        DashEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        DashEffect.SetActive(false);
        yield return new WaitForSecondsRealtime(4f);
        cantdash = false;
    }
}
