//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InputController : MonoBehaviour
//{

//    PlayerController playerController;

//    Vector3 moveInput;
//    Vector3 viewInput;
//    Vector2 attackInput;

//    bool leftStrafe;
//    bool rightStrafe;
//    bool isStrafing;

//    bool resetCamera;

//    [SerializeField]
//    float threshold = 0.5f;

//    public bool inputEnabled = true;

//    private float normalFov = 60f;
//    public float zoomFov = 30;

//    [SerializeField]
//    private Camera mainCamera;
    

//    void Start()
//    {
//        playerController = GetComponent<PlayerController>();

//        Cursor.lockState = CursorLockMode.Locked;
//    }

//    private void Update()
//    {
//        if (inputEnabled)
//        {
//            float horMove = Input.GetAxisRaw("Horizontal");
//            float verMove = Input.GetAxisRaw("Vertical");

//            float horView = Input.GetAxisRaw("Mouse Y");
//            float verView = Input.GetAxisRaw("Mouse X");
//            float horAtk = Input.GetAxisRaw("Rightstick Y");

//            bool resetView()
//            {
//                if (Input.GetAxisRaw("leftTrigger") != 0 && Input.GetAxisRaw("rightTrigger") != 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }              
//            }

//            resetCamera = resetView();

//            leftStrafe = Input.GetButton("leftBumper");
//            rightStrafe = Input.GetButton("rightBumper");

//            strafeInput();

//            moveInput = new Vector3(horMove, 0, verMove);
//            viewInput = new Vector3(horView, verView).normalized;
//            attackInput = new Vector2(verView, horAtk).normalized;

//            if (attackInput.magnitude != 0)
//            {
//                playerController.Attack(attackInput);
//            }

//            if(Input.GetButtonDown("Submit"))
//            {
//                playerController.isRunning = true;
//                playerController.Interact();
//            }

//            if (Input.GetButton("Submit"))
//            {
//                playerController.isRunning = true;
//            }
//            else
//            {
//                playerController.isRunning = false;
//            }
//        }
//        else
//        {
//            moveInput = new Vector3(0, 0, 0);
//            viewInput = new Vector3(0, 0);
//            leftStrafe = false;
//            rightStrafe = false;

//            if (Input.GetButtonDown("Submit"))
//            {
//                playerController.Interact();
//            }
//        }
//    }

//    private void FixedUpdate()
//    {

//        playerController.GetInput(moveInput, viewInput, leftStrafe, rightStrafe, resetCamera);
//        if (inputEnabled)
//        {
//            mainCamera.GetComponent<Headbob>().Headbobbing(isStrafing);
//        }

//        if (Input.GetKey(KeyCode.Escape))
//        {
//            Cursor.lockState = CursorLockMode.None;
//            Cursor.visible = true;
//        }
//    }

//    bool strafeInput()
//    {
//        if (leftStrafe || rightStrafe)
//        {
//            isStrafing = true;
//            return true;
//        }
//        else
//        {
//            isStrafing = false;
//            return false;
//        }
//    }
//}
