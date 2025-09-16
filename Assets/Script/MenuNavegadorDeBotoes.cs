using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavegadorDeBotoes : MonoBehaviour
{
    [Header("Lista de Botões que aparecem no centro")]
    public List<GameObject> botoesCentrais;

    [Header("Botões de Navegação")]
    public Button botaoEsquerda;
    public Button botaoDireita;
    public string sceneName;
    private int indiceAtual = 0;
    public Transferir transferir;

    void Start()
    {
        transferir.Transition(sceneName);
        AtualizarBotoes();

        botaoEsquerda.onClick.AddListener(Anterior);
        botaoDireita.onClick.AddListener(Proximo);
    }

    void AtualizarBotoes()
    {
        for (int i = 0; i < botoesCentrais.Count; i++)
        {
            botoesCentrais[i].SetActive(i == indiceAtual);
        }
    }

    void Proximo()
    {
        if (botoesCentrais.Count == 0) return;

        indiceAtual++;
        if (indiceAtual >= botoesCentrais.Count)
            indiceAtual = 0;

        AtualizarBotoes();
    }

    void Anterior()
    {
        if (botoesCentrais.Count == 0) return;

        indiceAtual--;
        if (indiceAtual < 0)
            indiceAtual = botoesCentrais.Count - 1;

        AtualizarBotoes();
    }
}
