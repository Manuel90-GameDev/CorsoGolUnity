using UnityEngine;

public class LerpIsSlurp : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float t = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;     // incrementa t nel tempo
        t = Mathf.Clamp01(t);            // impedisce che superi 1

        float x = Mathf.Lerp(-3f, 3f, t); // calcola la posizione interpolata
        transform.position = new Vector3(x, 0, 0);

        /*
         * Il Lerp (Linear Interpolation) è una tecnica utilizzata per calcolare un valore intermedio tra due valori estremi in base a un parametro t.
         * Nel nostro caso, stiamo interpolando la posizione x di un oggetto tra -3 e 3 e il tempo non va oltre 1.
         */
    }
}
