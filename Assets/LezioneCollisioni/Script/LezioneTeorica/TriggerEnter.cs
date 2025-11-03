using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject sphere;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sphere.SetActive(true);
        }
    }
}
