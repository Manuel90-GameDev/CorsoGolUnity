using UnityEngine;

//Required Comp ???
public interface IInteractable
{

    //Questa property mi è utile per accedere facilmente al GameObject dell'oggetto interagibile
    //infatti l'oggetto dovrà implementare il get di questa property restituendo il suo GameObject
    //perchè le interfaces non hanno metodi come .TryGetComponent o GetComponent
    public GameObject Object { get; }

    public string interactionLabel { get; }

    //Definisco un metodo Interaction() che tutti gli oggetti interagibili dovranno implementare
    public void Interaction();
}
