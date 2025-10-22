using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControllerOld : MonoBehaviour
{    
    [Header ("Opzioni player")]
    [SerializeField] private float speed = 5.0f; // Velocita di movimento
    [SerializeField] private float mouseSensitivity = 2.0f; // sensibilita di rotazione
    [SerializeField] private Transform cameraTransform; // riferimento alla posizione della camera

    [Header("Jump & Gravity")]
    [SerializeField] float jumpHeight = 1.6f;        // Altezza del salto in metri
    [SerializeField] float gravity = -9.81f;         // Gravità
    [SerializeField] float groundedGravity = -2f;    // Spinta verso il basso per restare ancorati al terreno

    private float xRotation = 0f;
    private Vector3 velocity;
    private CharacterController characterController;
    private float verticalVelocity; // Velocità verticale accumulata (gravità/salto)

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); // Ottieni character controller del player
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Nascondi il cursore
    }

    // Update is called once per frame
    void Update()
    {
        // I comandi devono essere richiamanti ogni istatnte
        Move();
        Look();
    }

    // Gestione del movimento 
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // Ottieni valore asse orizzontale da InputManager
        float moveZ = Input.GetAxis("Vertical"); // Ottieni valore asse verticale da InputManager

        // -- GESTIONE MOVIMENTO --
        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;

        // --- GESTIONE GRAVITÀ & SALTO ---
        bool isGrounded = characterController.isGrounded; // controlla se il player sta toccando il terreno
        if (isGrounded && verticalVelocity < 0f)
        {
            // Un leggero “ancoraggio” al suolo per evitare il rimbalzo
            verticalVelocity = groundedGravity;
        }
        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // v = sqrt(2gh)
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Calcolo della gravita 
        verticalVelocity += gravity * Time.deltaTime;

        // Muovi il player
        Vector3 velocity = moveDir * speed; // == direzione * velocita
        velocity.y = verticalVelocity; // asse y = salto
        characterController.Move(velocity * Time.deltaTime);
    }

    // Gestione della visuale
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // ottieni il valore orizzontale del mouse
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // ottieni il valore verticale del mouse

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
