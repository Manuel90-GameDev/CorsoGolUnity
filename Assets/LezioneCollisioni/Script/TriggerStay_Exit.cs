using UnityEngine;

public class TriggerStay_Exit : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    Vector3 finalScale = new Vector3(3, 3, 3);
    float growSpeed = 1.0f;
    Vector3 initScale = new();

    private void Start()
    {
        initScale = sphere.transform.localScale;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (sphere.activeSelf)
            {
                sphere.transform.localScale = Vector3.MoveTowards(
                    sphere.transform.localScale,
                    finalScale,
                    growSpeed * Time.deltaTime);
            }
            else
            {
                Debug.Log("Sfera non attiva");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sphere.transform.localScale = initScale; // reset quando esce
    }
}
