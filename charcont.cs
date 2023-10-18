using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcont : MonoBehaviour
{
    [Header("met")]
    public float damp;
    [Range(1, 20)]
    public float rotationSpeed;
    [Range(1, 20)]
    public float StrafeTurnSpeed;

    float normalFov;
    public float sprintFov;

    float inputx;
    float inputy;
    float maxSpeed;

    public Transform playerTransform;

    Animator anim;
    Vector3 stickDirection;
    Camera cam;

    public KeyCode SprintButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;

    public bool runJattack = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        normalFov = cam.fieldOfView;
    }
    private void LateUpdate()
    {
        
       
        inputMove();
        inputRotation();
        movement();


    } 

    public void movement()
    {
        stickDirection = new Vector3(inputx, 0, inputy); 

        if (Input.GetKey(SprintButton))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, sprintFov, Time.deltaTime * 2);
            maxSpeed = 2;
            inputx = 2 *Input.GetAxis("Horizontal");
            inputy = 2 *Input.GetAxis("Vertical");
            runJattack = true;
        }
        else if (Input.GetKey(WalkButton))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFov, Time.deltaTime * 2);
            maxSpeed = 0.2f;
            inputx =  Input.GetAxis("Horizontal");
            inputy =  Input.GetAxis("Vertical");
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFov, Time.deltaTime * 2);
            maxSpeed = 1f;
            inputx = Input.GetAxis("Horizontal");
            inputy = Input.GetAxis("Vertical");

        }



        
    }

    
    public void inputMove()
    {
        anim.SetFloat("Speed", Vector3.ClampMagnitude(stickDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10);
    }
    public void inputRotation()
    {
        Vector3 rotOfSet = cam.transform.TransformDirection(stickDirection);
        rotOfSet.y = 0;
        playerTransform.forward = Vector3.Slerp(playerTransform.forward, rotOfSet, Time.deltaTime * rotationSpeed);
    }
}
