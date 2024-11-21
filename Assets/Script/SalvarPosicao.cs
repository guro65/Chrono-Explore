using UnityEngine;
using UnityEngine.SceneManagement;

public class SalvarPosicao : MonoBehaviour
{
    public Vector3 posicaoInicialPersonalizada;
    public Vector3[] posicoesFinaisPersonalizadas = new Vector3[4];

    string nomeCenaAtual;
    bool carregouPosicaoInicial = false;

    void Awake()
    {
        nomeCenaAtual = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        if (!carregouPosicaoInicial)
        {
            CarregarPosicaoInicial();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Carrega a posição inicial sempre que uma nova cena é carregada
        CarregarPosicaoInicial();
    }

    void OnDisable()
    {
        // Certifique-se de remover o delegate quando o objeto for destruído
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Salva a posição atual do jogador ao desativar o script (normalmente ao mudar de cena)
        SalvarLocalizacao();
    }

    public void CarregarPosicaoInicial()
    {
        if (PlayerPrefs.HasKey(nomeCenaAtual + "InicialX"))
        {
            posicaoInicialPersonalizada = new Vector3(
                PlayerPrefs.GetFloat(nomeCenaAtual + "InicialX"),
                PlayerPrefs.GetFloat(nomeCenaAtual + "InicialY"),
                PlayerPrefs.GetFloat(nomeCenaAtual + "InicialZ")
            );
        }
        else
        {
            posicaoInicialPersonalizada = transform.position;
        }

        transform.position = posicaoInicialPersonalizada;
        carregouPosicaoInicial = true;
    }

    public void SalvarLocalizacao()
    {
        // Salva a posição final se for uma das posições finais personalizadas, caso contrário, salva como posição normal
        bool posicaoFinal = false;
        for (int i = 0; i < posicoesFinaisPersonalizadas.Length; i++)
        {
            if (transform.position == posicoesFinaisPersonalizadas[i])
            {
                posicaoFinal = true;
                PlayerPrefs.SetFloat(nomeCenaAtual + "FinalX" + i, transform.position.x);
                PlayerPrefs.SetFloat(nomeCenaAtual + "FinalY" + i, transform.position.y);
                PlayerPrefs.SetFloat(nomeCenaAtual + "FinalZ" + i, transform.position.z);
                break;
            }
        }

        if (!posicaoFinal)
        {
            PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.x);
            PlayerPrefs.SetFloat(nomeCenaAtual + "Y", transform.position.y);
            PlayerPrefs.SetFloat(nomeCenaAtual + "Z", transform.position.z);
        }
    }

    void SalvarPosicaoInicial()
    {
        PlayerPrefs.SetFloat(nomeCenaAtual + "InicialX", transform.position.x);
        PlayerPrefs.SetFloat(nomeCenaAtual + "InicialY", transform.position.y);
        PlayerPrefs.SetFloat(nomeCenaAtual + "InicialZ", transform.position.z);
    }
}