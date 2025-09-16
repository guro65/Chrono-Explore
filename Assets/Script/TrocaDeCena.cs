using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Usado para manipular texto da UI padrão

public class TrocaDeCena : MonoBehaviour
{
    [Header("Nome da cena que será carregada")]
    public string nomeDaCena;

    [Header("Texto na tela (UI) que aparece 'Pressione F'")]
    public Text textoPressioneF;

    private bool jogadorDentroDaArea = false;

    void Start()
    {
        // Esconde o texto no início do jogo
        if (textoPressioneF != null)
        {
            textoPressioneF.enabled = false;
        }
    }

    void Update()
    {
        // Se o jogador estiver na área e apertar F, carrega a nova cena
        if (jogadorDentroDaArea && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Verifica se o objeto que entrou na área tem a tag "Player"
        if (outro.CompareTag("Player"))
        {
            jogadorDentroDaArea = true;

            // Exibe o texto "Pressione F" na tela
            if (textoPressioneF != null)
            {
                textoPressioneF.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D outro)
    {
        // Quando o jogador sai da área
        if (outro.CompareTag("Player"))
        {
            jogadorDentroDaArea = false;

            // Esconde o texto
            if (textoPressioneF != null)
            {
                textoPressioneF.enabled = false;
            }
        }
    }
}
