using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesDeTeleporte : MonoBehaviour
{
    void Start()
    {}
    public void OnCollisionEnter(Collision collision)
      {
        if (collision.gameObject.CompareTag("teleporte"))
       {
        SceneManager.LoadScene("Fase1");
       }
       if (collision.gameObject.CompareTag("teleporte2"))
       {
        SceneManager.LoadScene("Fase2");
       }
       if (collision.gameObject.CompareTag("teleporte3"))
       {
        SceneManager.LoadScene("Fase3");
       }
      }
}
