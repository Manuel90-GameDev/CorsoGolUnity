using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region FIELDS
    //STEP 1
    [SerializeField] private GameObject mostraTesto;

    //STEP 2
    [SerializeField] private TMP_InputField inputNumero1;
    [SerializeField] private TMP_InputField inputNumero2;
    [SerializeField] private TextMeshProUGUI risultatoSomma;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //STEP 1
    public void MostraTesto()
    {
        //Setto l'oggetto di testo attivo
        mostraTesto.SetActive(true);
    }

    //STEP 2
    public void SommaNumeri()
    {
        //Leggo i numeri dagli input field
        int numero1 = int.Parse(inputNumero1.text);
        int numero2 = int.Parse(inputNumero2.text);

        //Sommo i numeri
        int somma = numero1 + numero2;

        //Mostro il risultato nella UI
        risultatoSomma.text = somma.ToString();
    }

    //STEP 3
    //Aggiunge il controllo per verificare che gli input siano numeri validi
    public void SommaNumeriConControllo()
    {
        //Dichiaro delle variabili locali
        int numero1;
        int numero2;

        //Leggo i numeri dagli input field
        bool isNumero1Valido = int.TryParse(inputNumero1.text, out numero1);
        bool isNumero2Valido = int.TryParse(inputNumero2.text, out numero2);

        if (isNumero1Valido && isNumero2Valido)
        {
            //Sommo i numeri
            int somma = numero1 + numero2;
            //Mostro il risultato nella UI
            risultatoSomma.text = somma.ToString();
        }
        else
        {
            //Mostro un messaggio di errore
            risultatoSomma.text = "Input non valido!";
        }
    }
}
