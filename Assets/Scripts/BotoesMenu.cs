using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenu : MonoBehaviour
{

public string nomeDoFilho = "Menu";
//public string fase2;

void Start()
    {}

    public void IniciarJogo()
    {
       SceneManager.LoadScene("TelasDeFases");
    }

      public void VoltarAoMenu()
      {
        SceneManager.LoadScene("Menu");
      }

       public void Configuração()
      {
        SceneManager.LoadScene("Configurações");
      }

      public void tutorial()
      {
        SceneManager.LoadScene("Tutorial");
      }

      public void fase1()
      {
        SceneManager.LoadScene("Fase1");
      }
      public void fase2()
      {
        SceneManager.LoadScene("Fase2");
      }

      public void fase3()
      {
        SceneManager.LoadScene("Fase3");
      }

      public void SairDoJogo()
      {

        Application.Quit();
      }

       //public void OnCollisionEnter(Collision collision)
      //{
       //if (collision.gameObject.CompareTag("teleporte"))
       //{
        //SceneManager.LoadScene("Fase2");
        //}
      //}


  }