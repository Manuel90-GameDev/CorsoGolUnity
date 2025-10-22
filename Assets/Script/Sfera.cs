using UnityEngine;

public class Sfera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // fai vedere allo start che la sfera cambia colore una volta
        gameObject.GetComponent<Renderer>().material.color = Color.cyan; 
        Debug.Log("Guarda quante volte vengo richiamato ->");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Guarda quante volte vengo richiamato ->");
    }
}
