using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Scripting.APIUpdating;

public class PlayercharacterControllerNew : MonoBehaviour
{
    private PlayerInputActions inputActions;          // classe generata dall'asset .inputactions
    private CharacterController characterController;

    [Header("Movimento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.6f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundedGravity = -2f;

    [Header("Visuale")]
    [SerializeField] private Transform cameraTransform; // riferimento alla posizione della camera
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float minPitch = -85f;
    [SerializeField] private float maxPitch = 85f;

    private float verticalVelocity;
    private float pitchRotation;

    private void Awake()
    {
        GameManager.Instance.Player = gameObject; // Registro al GameManager l'oggetto player, cosi da poterlo sfruttare in altri punti del gioco

        characterController = GetComponent<CharacterController>(); // Ottieni character controller del player
        inputActions = new PlayerInputActions(); // Istanzia la classe generata
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Nascondi il cursore
    }

    void OnEnable()
    {
        inputActions.Player.Enable(); // Abilita ActionMap creata
        inputActions.Player.Jump.performed += ctx => Jump(ctx);
    }


    void OnDisable()
    {
        inputActions.Player.Disable(); // disabilita ActionMap creata
        inputActions.Player.Jump.performed -= ctx => Jump(ctx);
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        bool grounded = characterController.isGrounded;

        if (grounded && verticalVelocity < 0f)
            verticalVelocity = groundedGravity;

        // gravità
        verticalVelocity += gravity * Time.deltaTime;

        // movimento finale
        Vector3 velocity = move * moveSpeed;
        velocity.y = verticalVelocity;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void Look()
    {
        Vector2 lookInput = inputActions.Player.Look.ReadValue<Vector2>() * mouseSensitivity;

        // rotazione orizzontale (player)
        transform.Rotate(Vector3.up * lookInput.x);

        // rotazione verticale (camera)
        pitchRotation -= lookInput.y;
        pitchRotation = Mathf.Clamp(pitchRotation, minPitch, maxPitch);
        cameraTransform.localRotation = Quaternion.Euler(pitchRotation, 0f, 0f);
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        // esegue solo quando l'azione è performed
        if (ctx.performed && characterController.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}

