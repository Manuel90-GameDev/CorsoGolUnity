using UnityEngine;

public class TriggerEnterPratica : MonoBehaviour
{
    //Step 1
    [SerializeField] private GameObject altalena;
    //Step 2
    [SerializeField] private GameObject sfera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Step 1
            altalena.GetComponent<Renderer>().material.color = Color.red;

            //Step2
            sfera.SetActive(true);

            Destroy(gameObject);
        }
    }
}
