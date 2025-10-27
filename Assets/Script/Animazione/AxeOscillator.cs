using UnityEngine;

public class AxeOscillator : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float maxAngle = 45f;

    private float currentAngle = 0f;
    private float direction = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // aggiorna angolo
        currentAngle += speed * direction * Time.deltaTime;

        // limita con Clamp
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
        /*
         * Il Clamp serve a evitare che l'angolo superi i limiti di maxAngle e -maxAngle.
         * In pratica io devo fermare l'oscillazione esattamente a quei valori.
         * Es: se maxAngle è 45 e il minAngle è -45, l'angolo oscilla tra -45 e 45
         */

        // inverte direzione ai limiti
        if (currentAngle == maxAngle || currentAngle == -maxAngle)
            direction *= -1f;

        // applica la rotazione
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
        /*
         * Il Quaternion.Euler converte gli angoli di rotazione in gradi (in questo caso solo sull'asse Z).
         * Il Quaternion è una rappresentazione matematica della rotazione nello spazio 3D.
         */
    }
}
