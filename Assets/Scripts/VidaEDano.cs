using UnityEngine;
using TMPro;
public class VidaEDano : MonoBehaviour
{
// Lógica explicada pelo aluno:
// quando o colisor do jogador colidir com o colisor do inimigo ele receberá 10 de dano
    public TextMeshProUGUI quantidadeVida;

    public int vida = 100;

    public void ReceberDano(int quantidade)
    {
        vida -= quantidade;
        Debug.Log(gameObject.name + " recebeu " + quantidade + " de dano. Vida atual: " + vida);
        quantidadeVida.text=vida.ToString("0");
    }
     void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("vida"))
        {
            vida += 10;
            Debug.Log("vida atual: " + vida);
            Destroy(outro.gameObject);
        }
        quantidadeVida.text=vida.ToString("0");
    }
    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu.");
    }

    void Update ()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
            Morrer();
        }
    }

    void OnCollisionEnter(Collision coliDano)
    {
        if (coliDano.gameObject.CompareTag("Inimigo"))
        {
            ReceberDano(10);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag ("void"))
        {
            ReceberDano(100);
        }
    }

}