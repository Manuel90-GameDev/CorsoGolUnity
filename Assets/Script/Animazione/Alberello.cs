using UnityEngine;

public class Alberello : MonoBehaviour, IInteractable
{
    public GameObject Object => this.gameObject;

    public string interactionLabel => "ABBATTIMIIIII";

    public void Interaction()
    {
        GetComponent<Animator>().SetTrigger("IsCaduta");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
