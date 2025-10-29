using UnityEngine;

public class SpawPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
