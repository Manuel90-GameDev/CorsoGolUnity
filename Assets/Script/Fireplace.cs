using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    public GameObject Object => this.gameObject;

    public string interactionLabel => "Accendi fuoco";

    [SerializeField] private Light fireLight;
    public void Interaction()
    {
        fireLight.gameObject.SetActive(!fireLight.gameObject.activeInHierarchy);
    }
}
