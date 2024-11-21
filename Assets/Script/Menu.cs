using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public PlayerController player;
   //public Animator transicao;

   private void Start()
   {
      player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
      //transicao = GameObject.FindWithTag("Transicao").GetComponent<Animator>(); 
   }

   /*private void Update() 
   {
      AtivaTransicao();   
   }/*/
   public void PlayGame()
   {
      SceneManager.LoadScene("SelectFase");
   }
   public void Creditos()
   {
      SceneManager.LoadScene("Creditos");
   }

   public void Voltar()
   {
      SceneManager.LoadScene("Menu");
   }
   
   public void InicioEgito()
   {
      SceneManager.LoadScene("Cutscene0");
   }

   public void Cutscene()
   {
      SceneManager.LoadScene("Cutscene1");
   }

   public void Cutscene1()
   {
      SceneManager.LoadScene("Cutscene2");
   }
   
   public void Cutscene2()
   {
      SceneManager.LoadScene("Cutscene3");
   }

   public void Cutscene3()
   {
      SceneManager.LoadScene("Cutscene4");
   }
     
   public void Cutscene4()
   {
      SceneManager.LoadScene("Cutscene5");
   }
     
   public void Cutscene5()
   {
      SceneManager.LoadScene("Cutscene6");
   }
     
   public void Cutscene6()
   {
      SceneManager.LoadScene("Cutscene7");
   }
     
   public void Cutscene7()
   {
      SceneManager.LoadScene("Cutscene8");
   }

   public void Cutscene8()
   {
      SceneManager.LoadScene("Cutscene9");
   }

   public void Cutscene9()
   {
      SceneManager.LoadScene("Cutscene10");
   }

   public void Cutscene10()
   {
      SceneManager.LoadScene("Cutscene11");
   }

   public void Cutscene11()
   {
      SceneManager.LoadScene("Cutscene12");
   }

   public void Cutscene12()
   {
      SceneManager.LoadScene("Cutscene13");
   }
   
   public void Egito()
   {
      SceneManager.LoadScene("GameEgito");
   }

   public void MudarRoupa()
   {
      SceneManager.LoadScene("MudandoDeRoupaEgito");
   }

   public void TesteAudio()
   {
      SceneManager.LoadScene("GameEgito");
   }

   public void RoupaNova()
   {
      SceneManager.LoadScene("RoupaEgito");
   }

   public void Descer()
   {
      SceneManager.LoadScene("Cenario4");
   }

   public void Respawn()
   {
      SceneManager.LoadScene("Cenario6");
   }

   public void Respawn2()
   {
      SceneManager.LoadScene("Cenario7");
   }
   public void Respawn3()
   {
      SceneManager.LoadScene("Cenario5");
   }

   public void Agradecimentos()
   {
      SceneManager.LoadScene("Agradecimentos");
   }

   public void Final()
   {
      SceneManager.LoadScene("Continua");
   }

   public void Sair()
   {
      Application.Quit();
   }

   public void MudarCena()
   {
      if (player.VerificaSeEstaComRoupa())
      {
         SceneManager.LoadScene("Menu");
      }

   }

   /* public void AtivaTransicao()
   {
      if(player.VerificaSeEstaComRoupa())
      {
         transicao.Play("Transicao",1);
         transicao.SetLayerWeight(1, 1);
      }
   }*/
}
