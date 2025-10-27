using UnityEngine;

public class LerpIsSlurpV2 : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float t = 0f;
    [SerializeField] private bool goingForward = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // aggiorna t
        if (goingForward)
            t += Time.deltaTime * speed;
        else
            t -= Time.deltaTime * speed;

        // inversione direzione ai limiti
        if (t >= 1f) goingForward = false;
        if (t <= 0f) goingForward = true;

        // posizione interpolata
        float x = Mathf.Lerp(-3f, 3f, t);
        transform.position = new Vector3(x, 0, 0);
    }
}
