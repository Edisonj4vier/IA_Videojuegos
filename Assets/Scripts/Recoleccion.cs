using UnityEngine;
using UnityEngine.UI;

public class Recoleccion : MonoBehaviour
{
    public int cantidadMonedas;
    public Text textoMonedas;
    public GameObject monedaPrefab;

    public float tamanoTerreno = 500f;
    
    private void Update()
    {
        textoMonedas.text = "Monedas: " + cantidadMonedas;
        GenerarNuevasMonedas();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            cantidadMonedas++;
        }
    }
    
    public void GenerarMonedas()
    {
        Vector3 posicionAleatoria = new Vector3(
            Random.Range(-tamanoTerreno / 4f, tamanoTerreno / 4f),
            Random.Range(2f, 3f),
            Random.Range(-tamanoTerreno / 4f, tamanoTerreno / 4f)
        );
        
        Instantiate(monedaPrefab, posicionAleatoria, Quaternion.identity);
    }

    public void GenerarNuevasMonedas()
    {
        GenerarMonedas();
    }
}
