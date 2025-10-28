using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject pannelloScena;
    [SerializeField] private TMP_InputField inputFieldSalva;
    [SerializeField] private TextMeshProUGUI testoSalva;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pannelloScena.SetActive(!pannelloScena.activeSelf);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SalvaTesto()
    {
        testoSalva.text = inputFieldSalva.text;
    }

    public void CaricaScenaWorld()
    {
        SceneManager.LoadScene("World");
    }
}
