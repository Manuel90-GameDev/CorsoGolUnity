using UnityEngine;

public class Rotazione : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Step 1 - far vedere la rotazione senza Time.deltaTime
        //transform.Rotate(0, 60, 0);

        //Step 2 - far vedere la rotazione con Time.deltaTime
        transform.Rotate(0, 60 * Time.deltaTime, 0);
        /*
         * Il Delta Time rappresenta il tempo che intercorre tra un frame e l'altro.
         * Se non applichiamo il Delta Time, la velocità di rotazione dipenderà dal numero di frame al secondo (FPS) e
         * l'Update verrà chiamato più volte al secondo su macchine più potenti, causando una rotazione più veloce.
         * Con il Delta Time, la rotazione diventa indipendente dagli FPS, garantendo una velocità costante su tutte le macchine.
         */
    }
}
