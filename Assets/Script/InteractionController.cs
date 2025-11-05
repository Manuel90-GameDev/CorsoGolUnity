using UnityEngine;

public class InteractionController : MonoBehaviour
{

    //Questo socket serve per rendere modulare e scalabile il punto da cui parto per eseguire un raycast
    //che esegue la query su oggetti IInteractable
    [SerializeField] private Transform interactionSocket;
    [SerializeField] private float queryDistance = 1f;


    private IInteractable queriedInteractable = null;

    //Questo componente va sul player, si occupa di eseguire un raycast che esegue una query 
    //su soli oggetti IInteractable, comunica con la UI per visualizzare informazioni a schermo se serve
    void Update()
    {
        QueryInteractable();
    }


    private void QueryInteractable()
    {
        Ray queryRay = new Ray(interactionSocket.transform.position, interactionSocket.forward * queryDistance);

        Physics.Raycast(queryRay, out RaycastHit hitInfo);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if(queriedInteractable != interactable)
            {
                queriedInteractable = interactable;
                GameManager.Instance.CanvasManagerGame.SetInteractionLabel(interactable.interactionLabel);
            }
        }
        else
        {
            queriedInteractable = null;
            GameManager.Instance.CanvasManagerGame.ResetInteractionLabel();
        }
    }
    
    public void Interact()
    {
        if(queriedInteractable != null)
        {
            queriedInteractable.Interaction();
        }
    }
}
