using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //private static AudioManager instance;
    public AudioClip trilhaSonora;
    public AudioClip trilhaCaverna;
    public AudioClip trilhaMaquina;
    public AudioClip trilhaCutscene;
    private AudioSource player;
    void Start()
    {
        player = GetComponent<AudioSource>();
        //if(instance == null)
        //{
        //  instance = this;
        DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //  Destroy(gameObject);
        //}

        player.clip = trilhaMaquina;
        player.Play();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Cutscene0")
        {
            player.Stop();
            player.clip = trilhaCutscene;
            player.Play();
        }
        if(SceneManager.GetActiveScene().name == "GameEgito")
        {
            player.Stop();
            player.clip = trilhaSonora;
            player.Play();
        }if(SceneManager.GetActiveScene().name == "Cenario4")
        {
            player.Stop();
            player.clip = trilhaCaverna;
            player.Play();
        }
    }
}
