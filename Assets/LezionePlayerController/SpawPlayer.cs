using UnityEngine;

public class SpawPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * Istanzio il CLONE del player nella posizione e rotazione dell'oggetto SpawPlayer
         * E' importante che il prefab del player non sia gia presente nella scena
         * in quanto potrebbe esserci sempre il rischi di avere il Prefab originale
         * e modificarlo in Game, lo modifico anche come Prefab originale
         * ed è pericoloso.
         */
        GameObject playerClone = playerPrefab;

        /*
         * Instantiate crea una copia dell'oggetto specificato
         * Esistono diversi overload di questo metodo e qui ne vedremo due in particolare:
         * - Instantiate(original, position, rotation) : Crea una copia dell'oggetto originale nella posizione e rotazione specificate.
         * - Instantiate(original, position, Quaternion.identity) : Crea una copia dell'oggetto originale nella posizione specificata con rotazione identità (nessuna rotazione).
         */

        /*
         * Qui vado a istanziare il playerClone (copia del prefab del player) nella posizione e rotazione
         * del nostro oggetto SpawPlayer. In automatico il player aprende la posizione e rotazione di SpawPlayer.
         */
        //Instantiate(playerClone, transform.position, transform.rotation);

        /*
         * Qui vado a istanziare il playerClone (copia del prefab del player) nella posizione del nostro oggetto SpawPlayer
         * MA la rotazione è impostata a Quaternion.identity (nessuna rotazione).
         * Come rotazione il player avrà la rotazione di default del prefab.
         */
        Instantiate(playerClone, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
