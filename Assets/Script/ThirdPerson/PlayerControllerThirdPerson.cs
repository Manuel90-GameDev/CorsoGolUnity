using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControllerThirdPerson : MonoBehaviour
{
    [Header("Parametri movimento")]
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 6f;

    [Header("Parametri camera")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] float yawSens = 120f;
    [SerializeField] float pitchSens = 120f;
    [SerializeField] float minPitch = -30f;     // guarda giù
    [SerializeField] float maxPitch = 60f;      // guarda su

    [Header("Jump & Gravity")]
    [SerializeField] float jumpHeight = 1.6f;        // Altezza del salto in metri
    [SerializeField] float gravity = -9.81f;         // Gravit�
    [SerializeField] float groundedGravity = -2f;    // Spinta verso il basso per restare ancorati al terreno

    // Variabili cache
    CharacterController characterController;
    private float pitch; // Rotazione camera verticale
    private float verticalVelocity; // Velocit� verticale accumulata (gravit�/salto)
    float currentSpeed;

    private void Start()
    {
        pitch = NormalizeAngle(playerCamera.localEulerAngles.x);
        Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore
        characterController = GetComponent<CharacterController>(); // Salva componente CC
    }

    private void Update()
    {
        Move(); // Metodo di movimento
        Look(); // Metodo di rotazione della camera

    }

    private void LateUpdate()
    {
    }

    // Rotate camera
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * yawSens * Time.deltaTime; // Prendi il valore di input e moltiplicalo per la sens
        float mouseY = Input.GetAxis("Mouse Y") * pitchSens * Time.deltaTime; // Prendi il valore di input e moltiplicalo per la sens

        // Yaw = ruota il corpo del player alla rotazione orizzontale del mouse
        transform.Rotate(0f, mouseX, 0f); // Rotate() -> ruota in base ai 3 assi 
        
        pitch -= mouseY; // pitch -> viene calcolato ogni frame quando sottraendo il valore rilevato dal movimento del mouse
        pitch = Math.Clamp(pitch, minPitch, maxPitch); // Clamp() -> impone due valori come estremi. Serve per non capovolgere la visuale

        // Quaternion.Euler -> converte quell’angolo in una rotazione 3D reale.
        // localRotation -> applicata agli assi della camera, rispetto al suo oggetto genitore (Player)
        playerCamera.localRotation = Quaternion.Euler(pitch, 0, 0);

    }

    // Movimento del player
    private void Move()
    {
        // (WASD)
        float horizontal = Input.GetAxis("Horizontal"); // Rileva input orizzontale (AD)
        float vertical = Input.GetAxis("Vertical"); // Rileva input verticale (WS)

        Vector3 input = new(horizontal, 0, vertical);

        // nomralized -> Trasforma il vettore in unitario (= 1)
        // Serve per ottenere la stessa velocita in tutte le direzioni
        Vector3 moveDirection = transform.TransformDirection(input.normalized);

        // --- GESTIONE GRAVIT� & SALTO ---
        bool isGrounded = characterController.isGrounded; // controlla se il player sta toccando il terreno
        if (isGrounded && verticalVelocity < 0f)
        {
            currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; ; // Se premi shift, sostituisci la currentspeed con runspeed

            // Un leggero �ancoraggio� al suolo per evitare il rimbalzo
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


        // Aggiungo la velocita attuale al movimento del player
        Vector3 movement = moveDirection * currentSpeed;
        movement.y = verticalVelocity; // asse y = salto
        characterController.Move(movement * Time.deltaTime); // Muovo il player 
    }

    // Questa funzione serve a converte i gradi passati come parametro in un intervallo piu comodo
    // Serve ad evitare che gli angoli crescano oltre i 360 gradi o sotto gli 0 gradi
    // Serve ad avere delle rotazioni di camera piu fluide
    float NormalizeAngle(float a)
    {
        a %= 360f;          // riduce l’angolo tra -360 e 360
        if (a > 180f) a -= 360f;
        else if (a < -180f) a += 360f;
        return a;
    }

}
