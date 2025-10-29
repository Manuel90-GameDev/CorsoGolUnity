using TMPro;
using UnityEngine;

public class CanvasManagerWorld : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI salvaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        salvaText.text = GameManager.Instance.TestoSalva.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
