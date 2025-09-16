using UnityEngine;

public class PontosDeFala : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou na zona de fala");
            // Aqui você pode adicionar a lógica para iniciar o diálogo
        }
    }
}
