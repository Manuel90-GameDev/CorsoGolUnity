using TMPro;
using UnityEngine;

public class CanvasManagerWorld : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI salvaText;

    [SerializeField] private TextMeshProUGUI interactionLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.CanvasManagerWorld = this;
        salvaText.text = GameManager.Instance.TestoSalva.text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInteractionLabel(string label)
    {
        interactionLabel.text = "E: " + label;
    }
    
    public void ResetInteractionLabel()
    {
        interactionLabel.text = "";
    }
}
