using UnityEngine;

//Implementiamo l'interfaccia IInteractable (presumibilmente per oggetti interattivi nel gioco)
public class Fireplace : MonoBehaviour, IInteractable
{
    // Proprietà pubblica che restituisce il GameObject associato a questo script
    /*
     * E' una proprietà di sola lettura che restituisce il GameObject a cui questo script è associato.
     * =>: chiamato lambda arrow o expression body arrow e indica che la proprietà restituisce direttamente il valore dell’espressione a destra della freccia.
     * in pratica è come se stessimo scrivendo:
     * public GameObject Object
       {
           get
           {
               return this.gameObject;
           }
       }
     */
    public GameObject Object => this.gameObject;

    public string interactionLabel => "Accendi fuoco";

    [SerializeField] private Light fireLight;
    public void Interaction()
    {
        fireLight.gameObject.SetActive(!fireLight.gameObject.activeInHierarchy);
    }
}
