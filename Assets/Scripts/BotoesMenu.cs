using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenu : MonoBehaviour
{

public string nomeDoFilho = "SampleScene";
public string fase2;

void Start()
    {}

    public void IniciarJogo()
    {
       SceneManager.LoadScene("SampleScene");
    }

      public void VoltarAoMenu()
      {
        SceneManager.LoadScene("MenuPrincipal");
      }

       public void Configuração()
      {
        SceneManager.LoadScene("Configurações");
      }

      public void SairDoJogo()
      {
        
        Application.Quit();
      }

       public void OnCollisionEnter(Collision collision)
      {
       if (collision.gameObject.CompareTag("teleporte"))
       {
        SceneManager.LoadScene("Fase2");
        }
      }


  }