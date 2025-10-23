using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Istanza del manager pubblica e statica, cosi da essere accessibile ad altri script
    public static GameManager Instance { get; private set; } // Properties per richiamare il manager 

    // Qui sotto possono essere linkati riferimenti ad altri oggetti in gioco, cosi da poterli sfruttare in scena
    public GameObject Player { get; set; } // ESEMPIO: oggetto player -> Registrandolo qui ho accesso al Game Object del player in qualsiasi punto 
                                                // NB: Ricordarsi di registrare oggetto/script 
    
    // ** NOTE: REGISTRARE IL CANVAS QUANDO E' PRONTO

    private void Awake()
    {
        // Singleton Gamemanager -> Assicura che nella scena ne esista solamente 
        if(Instance != null && Instance != this) // se esiste un'altra instaza la elimino
        {
            Destroy(gameObject);
            return;
        }

        Instance = this; // Altrimenti assegna l'istanza 

        DontDestroyOnLoad(gameObject); // Mantiene il gameobject attivo durante i cambi scena
    }

    private void Start()
    {
        if(Player != null)
        {
            Debug.Log("Giocatore in scena!");
        }
    }

}
