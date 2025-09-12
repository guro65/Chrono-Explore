using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class BotaoMenu : MonoBehaviour
{
    public Button botaoDireito;
    public Button botaoEsquerdo;
    private Animation Animation;
    [Header("Botões do menu")]
    public List<Button> Botoes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Botoes = new List<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
