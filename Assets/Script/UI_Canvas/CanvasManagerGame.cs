using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject pannelloScena;
    [SerializeField] private TMP_InputField inputFieldSalva;
    [SerializeField] private TextMeshProUGUI testoSalva;

    [SerializeField] private TextMeshProUGUI interactionLabel;

    private void Awake()
    {
        /*
         * SECONDO MODO LEZIONE UI
         * 
         * Singleton Gamemanager -> Assicura che nella scena ne esista solamente
         * Il problema di farlo in questo modo e che se ci sono piu canvas in scena
         * Non si ha un totale controllo se si hanno CanvasManager multipli o diversi tra loro
         */
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.CanvasManagerGame = this; //SECONDO MODO LEZIONE UI
        //this -> riferimento all'istanza corrente di questo script
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

        //PRIMO MODO LEZIONE UI
        GameManager.Instance.TestoSalva = testoSalva;
    }

    public void CaricaScenaWorld()
    {
        SceneManager.LoadScene("World");
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
