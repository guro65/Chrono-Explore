using UnityEngine;
using UnityEngine.UI;  // Certifique-se de que você está usando o namespace correto para UI

public class TextDisplayManager : MonoBehaviour
{
    public Text displayText;  // Referência ao componente Text da UI
    public string[] messages;  // Lista de mensagens para exibir
    private int currentIndex = 0;  // Índice da mensagem atual

    void Start()
    {
        if (messages.Length > 0)
        {
            displayText.text = messages[currentIndex];  // Exibir a primeira mensagem
        }
    }

    void Update()
    {
        // Avançar para a próxima mensagem quando o jogador pressionar uma tecla
        /*if (Input.anyKeyDown)
        {
            ShowNextMessage();
        }*/
    }

    void ShowNextMessage()
    {
        if (currentIndex < messages.Length - 1)
        {
            currentIndex++;
            displayText.text = messages[currentIndex];
        }
        else
        {
            // Se todas as mensagens foram exibidas, limpar o texto ou executar outra ação
            displayText.text = "";
        }
    }
}