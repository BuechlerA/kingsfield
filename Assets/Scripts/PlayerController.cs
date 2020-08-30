using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions actions;
    private CharacterController charController;
    [SerializeField] private Camera viewCam;

    public GameObject weapon;

    [SerializeField]
    private bool isAttacking;
    public bool isRunning;

    Vector2 moveInput;
    Vector2 viewInput;

    Vector3 moveVector;

    float strafeInput;

    public float charSpeed = 1f;
    public float turnSpeed = 100f;

    public float walkSpeed = 1f;
    public float runSpeed = 1.5f;

    float attackTimer = 0f;

    [SerializeField]
    private Canvas UICanvas;

    //Sounds
    public AudioSource audioSource;
    public AudioClip[] stepSounds = new AudioClip[2];
    public AudioClip swingSound;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        viewCam = GameObject.Find("ViewCamera").GetComponent<Camera>();

        //Sounds
        audioSource = GetComponent<AudioSource>();

        //InputActions
        actions = new PlayerInputActions();
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
        moveVector = new Vector3(moveInput.x, 0, moveInput.y);
        charController.Move(transform.TransformDirection(moveVector.normalized) * charSpeed * Time.deltaTime);
    }

    public void Look()
    {
        transform.localEulerAngles += new Vector3(-viewInput.y, viewInput.x, 0f) * turnSpeed * Time.deltaTime;
    }

    //public void GetInput(Vector3 moveVector, Vector3 viewVector, bool leftStep, bool rightStep, bool viewReset)
    //{
    //    movePlayer = moveVector;
    //    viewPlayer += viewVector;
    //    viewPlayer.x = Mathf.Clamp(viewPlayer.x, -60, 60);

    //    if (leftStep && !rightStep)
    //    {
    //        strafeInput = -1;
    //    }
    //    else if (!leftStep && rightStep)
    //    {
    //        strafeInput = 1;
    //    }
    //    else
    //    {
    //        strafeInput = 0;
    //    }

    //    Movement();
    //    View(viewReset);
    //}

    //public void Movement()
    //{

    //    if (isRunning)
    //    {
    //        charSpeed = runSpeed;
    //    }
    //    else
    //    {
    //        charSpeed = walkSpeed;
    //    }

    //    charController.Move(transform.TransformDirection(strafeInput, 0, movePlayer.z)* charSpeed * Time.deltaTime);


    //    if (Mathf.Abs(movePlayer.z) >= 0.5f || strafeInput != 0)
    //    {
    //        //Sounds
    //        int i = 0;
    //        if (audioSource.isPlaying)
    //        {
    //            return;
    //        }
    //        else if (!audioSource.isPlaying)
    //        {
    //            audioSource.PlayOneShot(stepSounds[i]);
    //            i++;
    //            if (i > 1)
    //            {
    //                i = 0;
    //            }
    //        }
    //    }
    //}

    //public void View(bool resetValue)
    //{
    //        transform.localEulerAngles += new Vector3(0, movePlayer.x, 0) * turnSpeed;

    //    Camera.main.transform.localEulerAngles = new Vector3(Mathf.Clamp(viewPlayer.x, -60, 60), 0, 0);

    //    if (resetValue)
    //    {
    //        Camera.main.transform.localEulerAngles += new Vector3(Mathf.LerpAngle(transform.localEulerAngles.x, 0.0f, Time.deltaTime * 1.5f), 0 , 0);
    //    }
    //}

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

    //public void Interact()
    //{
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    //    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green, 2f);

    //    if (Physics.Raycast(ray, out hit, 2f))
    //    {
    //        Debug.Log(hit.collider.gameObject.name);

    //        if (hit.collider.GetComponent<InteractableBehaviour>() && GetComponent<InputController>().inputEnabled)
    //        {
    //            string myText = hit.collider.GetComponent<InteractableBehaviour>().dialogueText;

    //            GetComponent<InputController>().inputEnabled = false;
    //            UICanvas.GetComponentInChildren<Text>().text = myText;
    //            UICanvas.GetComponent<UIBehaviour>().FadeIn();
    //        }
    //        else if (hit.collider.GetComponent<InteractableBehaviour>() && !GetComponent<InputController>().inputEnabled)
    //        {
    //            GetComponent<InputController>().inputEnabled = true;
    //            UICanvas.GetComponent<UIBehaviour>().FadeOut();
    //        }
    //        else
    //        {
    //            return;
    //        }

    //    }
    //}


}

