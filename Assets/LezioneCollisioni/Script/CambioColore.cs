using UnityEngine;

public class CambioColore : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sphere"))
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);

            GetComponent<Renderer>().material.color = new Color(r, g, b, 1f);
        }
    }
}
