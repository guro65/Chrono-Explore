using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeJogo : MonoBehaviour
{
    [Header("Áudio")]
    public AudioMixer mixer;
    public Slider barraDeVolume;
     public Slider outrosDeVolume;

    [Header("Brilho")]
    public Image painelBrilho;
    public Slider barraDeBrilho;
    public float brilho = 1f;

    void Start()
    {
        // Carregar valores salvos (se existirem)
        if (PlayerPrefs.HasKey("musicaVolume"))
        {
            CarregarVolume();
        }
        else
        {
            definirVolume();
        }

        if (PlayerPrefs.HasKey("brilhoTela"))
        {
            CarregarBrilho();
        }
        else
        {
            definirBrilho();
        }
    }

    // (SET) = a definir
    public void definirVolume()
    {
        float volume = barraDeVolume.value;
        mixer.SetFloat("musica", Mathf.Log10(volume) * 20); 
        PlayerPrefs.SetFloat("musicaVolume", volume); 
    }
    public void CarregarVolume()
    {
        float volume = PlayerPrefs.GetFloat("musicaVolume");
        barraDeVolume.value = volume;
        mixer.SetFloat("musica", Mathf.Log10(volume) * 20);
    }

    public void definirBrilho()
    {
        brilho = barraDeBrilho.value;
        if (painelBrilho != null)
        {
            Color cor = painelBrilho.color;
            cor.a = 1 - brilho; 
            painelBrilho.color = cor;
        }
        PlayerPrefs.SetFloat("brilhoTela", brilho);
    }

    public void CarregarBrilho()
    {
        brilho = PlayerPrefs.GetFloat("brilhoTela");
        barraDeBrilho.value = brilho;

        if (painelBrilho != null)
        {
            Color cor = painelBrilho.color;
            cor.a = 1 - brilho;
            painelBrilho.color = cor;
        }
    }
}
