using TMPro;
using UnityEngine;

public class Loja : MonoBehaviour
{
    [Header("Referências")]
    public TextMeshProUGUI fala;
    public GameObject painelDaLoja;

    private bool dentroDaLoja = false;
    private GameObject player;

    void Start()
    {
        if (painelDaLoja != null)
            painelDaLoja.SetActive(false);

        if (fala != null)
            fala.text = "";

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Só deixa interagir se o player estiver dentro da área
        if (dentroDaLoja && Input.GetKeyDown(KeyCode.F))
        {
            // Se a loja já está aberta → fecha
            if (painelDaLoja.activeSelf)
            {
                painelDaLoja.SetActive(false);
                fala.text = "Volte sempre!";
            }
            else
            {
                // Se está fechada → abre
                painelDaLoja.SetActive(true);
                fala.text = "Seja bem-vindo à minha loja!";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            dentroDaLoja = true;
            fala.text = "Pressione [F] para falar";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            dentroDaLoja = false;
            painelDaLoja.SetActive(false);
            fala.text = "";
        }
    }
    //falta colocar som de abrir e fechar a loja e o icone de interagir com a imagem
}
