using UnityEngine;

public class Scala : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * 0.3f;
        transform.localScale = new Vector3(scale, scale, scale);

        /*
         * Mathf è un struttura che contiene funzioni matematiche utili, offerta da Unity.
         * Stiamo usando la funzione Sin (seno) per creare un'oscillazione fluida della scala dell'oggetto.
         */
    }
}
