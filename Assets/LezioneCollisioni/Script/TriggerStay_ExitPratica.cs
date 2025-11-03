using UnityEngine;

public class TriggerStay_ExitPratica : MonoBehaviour
{
    [SerializeField] GameObject albero;
    Vector3 finalScale = new Vector3(3, 3, 3);
    float growSpeed = 1.0f;
    Vector3 initScale = new();

    private void Start()
    {
        initScale = albero.transform.localScale;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (albero.activeSelf)
            {
                albero.transform.localScale = Vector3.MoveTowards(
                    albero.transform.localScale,
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
        albero.transform.localScale = initScale; // reset quando esce
    }
}
