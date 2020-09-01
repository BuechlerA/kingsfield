﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions actions;
    private CharacterController charController;
    private Camera viewCam;

    Vector2 moveInput;
    Vector2 viewInput;

    Vector3 moveVector;

    public float turnSpeed = 100f;

    public float walkSpeed = 1f;
    public float runSpeed = 5f;

    float GRAVITY = -8f;

    float xRotation = 0f;
    float yRotation = 0f;

    [SerializeField]
    bool isPressingSprint;
    [SerializeField]
    bool isSprinting;
    [SerializeField]
    bool isCamFOV;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        viewCam = GameObject.Find("ViewCamera").GetComponent<Camera>();

        //InputActions
        actions = new PlayerInputActions();
        actions.bindingMask = new InputBinding { groups = "ModernPC" };

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        moveInput = actions.Gameplay.Movement.ReadValue<Vector2>();
        viewInput = actions.Gameplay.View.ReadValue<Vector2>();

        Move();
        Look();
    }
    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }

    //New Input System
    public void Move()
    {
        if (isPressingSprint && moveInput.y == 1f && moveInput.x == 0f)
        {
            isSprinting = true;
            charController.Move(transform.TransformDirection(moveInput.x, GRAVITY, moveInput.y) * Time.deltaTime * runSpeed);
            if (viewCam.fieldOfView <= 61f && !isCamFOV)
            {
                StartCoroutine(CamSprintFOV(60f, 70f));
            }
        }
        else
        {
            isSprinting = false;
            charController.Move(transform.TransformDirection(moveInput.x, GRAVITY, moveInput.y) * Time.deltaTime * walkSpeed);
            if (viewCam.fieldOfView >= 61f && !isCamFOV)
            {
                StartCoroutine(CamSprintFOV(70f, 60f));
            }
        }
        viewCam.GetComponent<Headbob>().Headbobbing(moveInput.x, moveInput.y, isSprinting);
    }

    public void Look()
    {
        xRotation -= viewInput.y * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += viewInput.x * Time.deltaTime;

        viewCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            isPressingSprint = true;      
        }
        else
        {
            isPressingSprint = false;        
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            RaycastHit hit;
            Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green, 2f);

            if (Physics.Raycast(ray, out hit, 2f))
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.GetComponent<InteractableBehaviour>())
                {
                    Debug.Log(hit.collider.GetComponent<InteractableBehaviour>().dialogueText);
                }
            }
        }
    }

    //public void Attack(Vector2 attackVector)
    //{
    //    if (!isAttacking)
    //    {
    //        isAttacking = true;

    //        if (attackVector.x >= -0.5f)
    //        {
    //            Debug.Log("left swing!");
    //        }
    //        if (attackVector.x >= 0.5f)
    //        {
    //            Debug.Log("right swing!");
    //        }

    //        audioSource.PlayOneShot(swingSound);

    //        isAttacking = false;
    //    }
    //}

    IEnumerator CamSprintFOV(float startValue, float endValue)
    {
        isCamFOV = true;
        float timeElapsed = 0f;

        while (timeElapsed < 0.5f)
        {
            viewCam.fieldOfView = Mathf.Lerp(startValue, endValue, timeElapsed / 0.5f);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        isCamFOV = false;
    }
}

